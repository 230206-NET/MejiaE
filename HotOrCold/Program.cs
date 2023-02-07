using System;

namespace HotOrCold {
        public class HOC {
            public static void Main(string[] args) {
                var random = new Random();
                int target = random.Next(21); //generate a random number between 0 and 20

                Console.WriteLine(target);
                
                int guess;
                
                Console.WriteLine("Please guess a number between 0 and 20: ");
                guess = int.Parse(Console.ReadLine());

                while (guess != target) {
                    if (guess > target) {
                        Console.WriteLine("OOPS, That was too high! Try again: ");
                    }else {
                        Console.WriteLine("Oh no, too low! Try again: ");
                    }

                    guess = int.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Congratulations, you guessed it! The number was: {target}. Thanks for playing.");     
        }
    }
}