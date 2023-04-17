using System;

namespace StringManipulationChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            string userInputString; //this will hold your users message
            int elementNum;         //this will hold the element number within the messsage that your user indicates
            char char1;             //this will hold the char value that your user wants to search for in the message.
            string fName;           //this will hold the users first name
            string lName;           //this will hold the users last name
            string userFullName;    //this will hold the users full name;

            //
            //
            //implement the required code here and within the methods below.
            //
            //
            Console.WriteLine("Please enter your message and press enter: ");
            userInputString = Console.ReadLine();

            Console.WriteLine("Please enter a number LESS THAN the length of your string and press enter: ");
            elementNum = int.Parse(Console.ReadLine());

            Console.WriteLine(StringToUpper(userInputString));
            Console.WriteLine(StringToLower(userInputString));
            Console.WriteLine(StringTrim(userInputString));
            Console.WriteLine(StringSubstring(userInputString, elementNum));

            Console.WriteLine("For which character should I search in your original message?");
            char1 = Char.Parse(Console.ReadLine());
            Console.WriteLine(SearchChar(userInputString, char1));

            Console.WriteLine("What is your first name?");
            fName = Console.ReadLine();

            Console.WriteLine("What is your last name?");
            lName = Console.ReadLine();

            Console.WriteLine(ConcatNames(fName, lName));


        }

        // This method has one string parameter. 
        // It will:
        // 1) change the string to all upper case, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringToUpper(string x)
        {
            string tempString = x.ToUpper();
            Console.WriteLine(tempString);
            return tempString;
        }

        // This method has one string parameter. 
        // It will:
        // 1) change the string to all lower case, 
        // 2) print the result to the console and 
        // 3) return the new string.        
        public static string StringToLower(string x)
        {
            string tempString = x.ToLower();
            Console.WriteLine(tempString);
            return tempString;
        }

        // This method has one string parameter. 
        // It will:
        // 1) trim the whitespace from before and after the string, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringTrim(string x)
        {
            string tempString = x.Trim();
            Console.WriteLine(tempString);
            return tempString;
        }

        // This method has two parameters, one string and one integer. 
        // It will:
        // 1) get the substring based on the integer received, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringSubstring(string x, int elementNum)
        {
            string tempString = x[elementNum..];
            Console.WriteLine(tempString);
            return tempString;
        }

        // This method has two parameters, one string and one char.
        // It will:
        // 1) search the string parameter for the char parameter
        // 2) return the index of the char.
        public static int SearchChar(string userInputString, char x)
        {
            return userInputString.IndexOf(x);
        }

        // This method has two string parameters.
        // It will:
        // 1) concatenate the two strings with a space between them.
        // 2) return the new string.
        public static string ConcatNames(string fName, string lName)
        {
            string newString = $"{fName} {lName}";
            return newString;
        }

    }//end of program
}
