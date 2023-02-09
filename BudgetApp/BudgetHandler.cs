using System;

namespace BudgetApp {
    public class BudgetHandler { 
        //TO-DO: get rid of the static methods and variables and handle possible null references
        static decimal startingBudget, totalExpense;

        
        static List<Expense> expenses = new List<Expense>();
        
        public static void Main(string[] args) {
            

            Console.WriteLine("Welcome to the Budget App: Helping you track your expenses to survive in this economy!");
            InitPrompt();
            ShowResults();
        }

        static void InitPrompt() {
            string tempDescription = "";
            decimal tempCost = 0.0m;
            bool isProcessedExpense = false;
            while(true){
                if (startingBudget <= 0.0m) {
                    Console.WriteLine("Please enter your starting budget:");
                    try{
                        startingBudget = decimal.Parse(Console.ReadLine());
                    }catch (Exception) {
                        Console.WriteLine("An error occured while reading your starting budget, try again!");
                        continue;
                    }

                    if (startingBudget <= 0.0m) {
                        Console.WriteLine("Your starting budget must be a number higher than zero, try again!");
                        continue;
                    }
                }

                if (string.IsNullOrEmpty(tempDescription) || string.IsNullOrWhiteSpace(tempDescription)) {
                    if (expenses.Count.Equals(0)) {
                        Console.WriteLine("Next, we're going to record your expenses.");
                    }
                    Console.WriteLine("Describe your expense:");
                    tempDescription = Console.ReadLine();

                    if (string.IsNullOrEmpty(tempDescription) || string.IsNullOrWhiteSpace(tempDescription)){
                        Console.WriteLine("ERROR: You must provide a description! Try again.");
                        continue;
                    }
                }

                if (tempCost <= 0.0m) {
                    Console.WriteLine("Now, please enter the cost as a positive value:");
                    try{
                        tempCost = decimal.Parse(Console.ReadLine());
                    }catch (Exception) {
                        Console.WriteLine("An error occured while reading the cost of the expense, try again!");
                        continue;
                    }

                    if (tempCost <= 0.0m) {
                        Console.WriteLine("The cost of the expense must be a number higher than zero, try again!");
                        continue;
                    }
                }

                if (!isProcessedExpense){
                    expenses.Add(new Expense() { description = tempDescription, amount = tempCost });
                    isProcessedExpense = true;
                }
                
                Console.WriteLine("Your expense has been added successfully! Would you like to add another one? (Y = YES / N = NO)");
                string response = Console.ReadLine();

                switch (response.ToUpper()) {
                    case "Y":
                    case "YES":
                        tempDescription = "";
                        tempCost = 0.0m;
                        isProcessedExpense = false;
                        continue;
                    case "N":
                    case "NO":
                        return;
                    default: 
                        Console.WriteLine("Invalid input! Please reply with either Y or N.");
                        continue;
                }
            }

        }

        static void CalculateTotalExpense () {
            totalExpense = expenses.Sum(expense => expense.amount);
        }
        
        static decimal CalculateRemainingBudget() {
            return startingBudget - totalExpense;
        }

        static void ShowExpenses () {
            foreach (Expense expense in expenses) {
                Console.WriteLine(expense.ToString());
            }
        }

        static void ShowResults (){
            CalculateTotalExpense();
            decimal remainingBudget = CalculateRemainingBudget();
            Console.WriteLine("==========================");
            Console.WriteLine("BUDGET STATS");
            Console.WriteLine("==========================");
            Console.WriteLine($"STARTING BUDGET: ${startingBudget} | TOTAL EXPENSE: ${totalExpense} | ENDING BUDGET: ${remainingBudget}");
            Console.WriteLine("===");
            Console.WriteLine("EXPENSES:");
            ShowExpenses();
            Console.WriteLine("===");
            if (remainingBudget > 0.0m) {
                Console.WriteLine("After taking all expenses into account, you still have money left in your budget.");
            } else if (remainingBudget < 0.0m) {
                Console.WriteLine("You've gone over your budget! Perhaps try better money management practices.");
            } else {
                Console.WriteLine("You've completely exhausted your budget. There is no money left to spend!");
            }
        }

    }

}