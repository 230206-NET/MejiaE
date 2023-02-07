// See https://aka.ms/new-console-template for more information
Console.WriteLine("Starting Program...");

string userInput = Console.ReadLine(); //reads user input

Console.WriteLine(userInput); //prints user input

// two if statements which check if the conditions are true.
if (5 > 4) {
    Console.WriteLine("Five is greater than four!"); // printed if true
}

if (4 > 5) { //unreachable due to 4 never being greater than 5
    Console.WriteLine("Four is greater than five!"); // printed if true
}

int balance = 100; //hardcoded balance value for the purpose of giving an example.

if (balance <= 0) { //comparing the variable to the zero integer.
    Console.WriteLine("Account balance must not have a negative balance!");
} else if (balance > 0) { // 'else if' ONLY runs if the conditional statement above it is not true.
    Console.WriteLine(balance); //prints the balance value
} else { // if none of the previous conditions are true then 'else' will be the default code that runs.
    Console.WriteLine("Your balance somehow is neither positive, negative, nor zero."); //This should never be printed by the console since the previous lines of code handle all the conditions. 
}

Console.WriteLine("Ending Program.");