namespace UI;
internal class UIWindow
{
    internal static string initScreen =
                """
                +-------------------------------+
                |  Expense Reimbursement System |
                +===============================+
                |   What would you like to do?  |
                |   [1] Login                   |
                |   [2] Create an account       |
                |   [X] Exit                    |
                +-------------------------------+
                """;
    internal static string[] accountScreen = {
                """
                +-------------------------------+
                |    Employee Service Portal    |
                +===============================+
                |   What would you like to do?  |
                |   [1] Submit a ticket         |
                |   [2] View previous tickets   |
                |   [3] View/Edit profile       |
                |   [X] Log out                 |
                +-------------------------------+
                """,
                """
                +-------------------------------+
                |     Manager Service Portal    |
                +===============================+
                |   What would you like to do?  |
                |   [1] Manage Tickets          |
                |   [2] Manage Users            |
                |   [3] View/Edit profile       |
                |   [X] Log out                 |
                +-------------------------------+
                """
    };
}