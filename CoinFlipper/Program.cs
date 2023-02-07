using System;

namespace CoinFlipper {
    public class Flipper {
        public static void Main(string[] args) {
            Console.WriteLine("Coin Flipper starting...");

            string[] coinFaces = {"Heads", "Tails"};

            var random = new Random();
            string result = coinFaces[random.Next(coinFaces.Length)];

            Console.WriteLine($"Your coin was flipped, it was: {result}");
        }
    }
}