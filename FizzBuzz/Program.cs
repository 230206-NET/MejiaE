/*
- Given a positive integer, print the following:
- If the number is divisible by 3, print "Fizz"
- If the number is divisible by 5, print "Buzz"
- If the number is divisible by both 3 and 5, print "FizzBuzz"
- Finally, if the number is not divisible by 3 or 5, print the number itself
*/

NumEnter:
Console.WriteLine("Please enter a positive number:");
string userInput = Console.ReadLine(); //grab user's input


int parsedInput = 0; //initialize parsedInput as 0 to use later in case of an exception.

try {
    parsedInput = int.Parse(userInput); //tries to convert the user input from string to int and set parsedInput to that value
} 
catch(FormatException){ //catches an exception where the user inputs something other than a number
    Console.WriteLine("Your input must only be a number...");
}
catch(ArgumentNullException){ //catches an exception where the user doesn't input anything
    Console.WriteLine("You didn't input anything...");
}
catch(OverflowException){ //catches an exception where the user's input is out of range
    Console.WriteLine("That value is out of range, please  try again...");
}

/*
Below we have a check to see if parseInput is less than or equal to 0.
If for some reason we have an exception and the value of  parseInput couldn't be changed
or the user themselves input 0 as their value, then this will throw the user back to the
beginning of the program and force them to input  a number again.
*/
if (parsedInput <= 0) {
    Console.WriteLine("Your input must be greater than zero.");
    goto NumEnter;
}

int[] numbers = {3, 5}; //array holding the two numbers the user's input is supposed to be divisible by

for(int i = 1; i <= parsedInput; i++){ // this loop checks every number starting from 1 to the user's input
    string result = ""; //init result as an empty string for each number
    foreach (int num in numbers) { //checks if the number is divisible by 3 or 5 (the numbers in our array)
        if (i % num == 0) {
            result = string.Concat(result, num == 3 ? "Fizz" : "Buzz"); // concatenates the word 'Fizz' or 'Buzz' for our current number depending on what number we're using from our 'numbers' array
        }
    }
    if (string.IsNullOrEmpty(result)) { //if the string value for 'result' is null/empty (meaning that nothing was concatenated to 'result' due to the number not being divisible by 3 or 5), then print the number
        Console.WriteLine(i);
    } else { //if our string value for 'result' is not null/empty (meaning it is divisible by at least one of the numbers), then print the value of 'result'
        Console.WriteLine(result);
    }
}
