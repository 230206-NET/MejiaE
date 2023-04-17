using System;

namespace BudgetApp
{
    public class BudgetHandler
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Budget App: Helping you track your expenses to survive in this economy!");
            (decimal, List<Expense>) budgetInfo = CollectBudgetInformation();
            ShowResults(budgetInfo.Item1, budgetInfo.Item2);
        }

        static (decimal, List<Expense>) CollectBudgetInformation()
        {
            string tempDescription = "";
            decimal tempCost = 0.0m;
            bool isProcessedExpense = false;
            decimal startingBudget = 0.0m;
            List<Expense> expenses = new List<Expense>();
            while (true)
            {
                if (startingBudget <= 0.0m)
                {
                    Console.WriteLine("Please enter your starting budget:");
                    try
                    {
                        startingBudget = decimal.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("An error occured while reading your starting budget, try again!");
                        continue;
                    }

                    if (startingBudget <= 0.0m)
                    {
                        Console.WriteLine("Your starting budget must be a number higher than zero, try again!");
                        continue;
                    }
                }

                if (string.IsNullOrEmpty(tempDescription) || string.IsNullOrWhiteSpace(tempDescription))
                {
                    if (expenses.Count.Equals(0))
                    {
                        Console.WriteLine("Next, we're going to record your expenses.");
                    }
                    Console.WriteLine("Describe your expense:");
                    tempDescription = Console.ReadLine();

                    if (string.IsNullOrEmpty(tempDescription) || string.IsNullOrWhiteSpace(tempDescription))
                    {
                        Console.WriteLine("ERROR: You must provide a description! Try again.");
                        continue;
                    }
                }

                if (tempCost <= 0.0m)
                {
                    Console.WriteLine("Now, please enter the cost as a positive value:");
                    try
                    {
                        tempCost = decimal.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("An error occured while reading the cost of the expense, try again!");
                        continue;
                    }

                    if (tempCost <= 0.0m)
                    {
                        Console.WriteLine("The cost of the expense must be a number higher than zero, try again!");
                        continue;
                    }
                }

                if (!isProcessedExpense)
                {
                    expenses.Add(new Expense() { description = tempDescription, amount = tempCost });
                    isProcessedExpense = true;
                }

                Console.WriteLine("Your expense has been added successfully!");

                decimal totalExpense = expenses.Sum(expense => expense.amount);
                decimal remainingBudget = startingBudget - totalExpense;

                Console.WriteLine($"Your remaining budget is ${remainingBudget}. Would you like to add another one? (Y = YES / N = NO)");
                string response = Console.ReadLine();

                switch (response.ToUpper())
                {
                    case "Y":
                    case "YES":
                        tempDescription = "";
                        tempCost = 0.0m;
                        isProcessedExpense = false;
                        continue;
                    case "N":
                    case "NO":
                        return (startingBudget, expenses);
                    default:
                        Console.WriteLine("Invalid input! Please reply with either Y or N.");
                        continue;
                }
            }

        }

        static void ShowResults(decimal startingBudget, List<Expense> expenses)
        {
            decimal totalExpense = expenses.Sum(expense => expense.amount);
            decimal remainingBudget = startingBudget - totalExpense;
            Console.WriteLine("==========================");
            Console.WriteLine("BUDGET STATS");
            Console.WriteLine("==========================");
            Console.WriteLine($"STARTING BUDGET: ${startingBudget} | TOTAL EXPENSE: ${totalExpense} | ENDING BUDGET: ${remainingBudget}");
            Console.WriteLine("===");
            Console.WriteLine("EXPENSES:");
            expenses.ForEach(expense => Console.WriteLine(expense));
            Console.WriteLine("===");
            if (remainingBudget > 0.0m)
            {
                Console.WriteLine("After taking all expenses into account, you still have money left in your budget.");
            }
            else if (remainingBudget < 0.0m)
            {
                Console.WriteLine("You've gone over your budget! Perhaps try better money management practices.");
            }
            else
            {
                Console.WriteLine("You've completely exhausted your budget. There is no money left to spend!");
            }
        }

    }

}