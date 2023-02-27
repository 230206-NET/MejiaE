using UI;
using Services;
using Data;


//MainMenu menu = new MainMenu();
//menu.Start();

IRepository repo = new DBRepository();
AccountService service = new AccountService(repo);
MainMenu menu = new MainMenu(service);
menu.Start();