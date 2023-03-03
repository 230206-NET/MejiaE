using Microsoft.AspNetCore.Mvc;
using Data;
using Services;
using Models;
using Models.CustomException;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddScoped<IRepository, DBRepository>();
builder.Services.AddScoped<AccountService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/tickets", ([FromQuery] bool? pending, [FromQuery] int? UserId, AccountService service) =>
{
    if (pending ?? false)
    {
        if (UserId.HasValue)
        {
            return service.GetPendingTicketsForUser(UserId.Value);
        }
        else
        {
            return service.GetPendingTickets();
        }

    }
    else if (UserId.HasValue)
    {
        return service.GetTicketsForUser(UserId.Value);
    }

    return service.GetAllTickets();
});

app.MapPost("/tickets", ([FromBody] Ticket ticket, AccountService service) =>
{
    try
    {
        return Results.Created("/tickets", service.CreateNewTicket(ticket));
    }
    catch (Exception ex)
    {

        return Results.BadRequest(new { ErrorMessage = ex.Message });
    }
});

app.MapPut("/tickets", ([FromBody] TicketEditorParams parameters, AccountService service) =>
{
    Ticket? ticket = service.UpdateTicketStatusWithAuthorId(parameters.editorId, parameters.TicketId, parameters.TicketStatus);
    if (ticket != null)
    {
        return Results.Accepted("/tickets", ticket);
    }
    else
    {
        return Results.BadRequest("You either lack the permissions to edit this ticket or there's no pending ticket with such ID.");
    }
});

app.MapGet("/users", (AccountService service) =>
{
    return service.GetAllUsers();
});

app.MapPost("/users", ([FromBody] User user, AccountService service) =>
{
    try
    {
        return Results.Created("/users", service.CreateNewUser(user));
    }
    catch (ArgumentLengthException ex)
    {
        return Results.BadRequest(new { ErrorMessage = ex.Message });
    }
    catch (UserAlreadyExistsException ex)
    {
        return Results.Conflict(new { ErrorMessage = ex.Message });
    }
});

app.MapPost("/login", ([FromBody] LoginCredentials credentials, AccountService service) =>
{
    if (service.AttemptLogin(credentials.username, credentials.password))
    {
        return Results.Ok("Your account has been validated successfully.");
    }
    else
    {
        return Results.Unauthorized();
    }
});

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("../logs/logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    Log.Information("Application Starting...");

    app.Run();
}
catch (Exception ex)
{
    Log.Error("Something fatal happened, {0}", ex);
}
finally
{
    Log.CloseAndFlush();
}