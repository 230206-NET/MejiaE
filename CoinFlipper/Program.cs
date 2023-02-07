using System;

namespace CoinFlipper {
    public class Flipper {
        public static void Main(string[] args) {
            Console.WriteLine("Coin Flipper starting...");

            string[] coinFaces = {"Heads", "Tails"}; //sets up an array containing the two faces of a coin

            var random = new Random(); //new Random object which will be used to generate our pseudorandomness
            string result = coinFaces[random.Next(coinFaces.Length)]; //get a 'random' number between the length of our coinFaces array (between 0 and 1) and use it to get the indexed value in the array.

            Console.WriteLine($"Your coin was flipped, it was: {result}"); //print our result.
        }
    }
}