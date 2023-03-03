using Models;
using Models.CustomException;

namespace Tests;

public class TicketEditorParamsTests
{
    [Fact]
    public void TicketEditorParamsShouldCreate()
    {
        TicketEditorParams tep = new TicketEditorParams(0, 3, 1);

        Assert.NotNull(tep);
        Assert.NotNull(tep.editorId);
        Assert.NotNull(tep.TicketId);
        Assert.NotNull(tep.TicketStatus);
    }
}