using System;

namespace HotOrCold {
        public class HOC {
            public static void Main(string[] args) {
                var random = new Random(); //new Random object which will be used to generate our pseudo-randomness
                int target = random.Next(21); //generate a random number between 0 and 20
                
                Console.WriteLine("Please guess a number between 0 and 20: "); //ask the user for input
                int guess = int.Parse(Console.ReadLine()); //parse the user's first input from string to int

                while (guess != target) { //loop through this code while the user's guess is different from the target
                    if (guess > target) { //let the user know if their guess was too high and ask them to try again
                        Console.WriteLine("OOPS, That was too high! Try again: ");
                    }else { //let the user know if their guess was too low and ask them to try again
                        Console.WriteLine("Oh no, too low! Try again: ");
                    }

                    guess = int.Parse(Console.ReadLine()); //grab the user's new guess
                }
                Console.WriteLine($"Congratulations, you guessed it! The number was: {target}. Thanks for playing."); //this message is displayed once the loop is broken, which means the user has guessed the number correctly    
        }
    }
}