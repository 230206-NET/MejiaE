using System;

namespace DataTypeAndVariables
{
    public class Program
    {
      public static void Main(string[] args)
      {
          Console.WriteLine("Hello World!");

          byte myByte = 225;
          sbyte mySbyte = 52;
          int myInt = 10;
          uint myUint = 3;
          short myShort = 6;
          ushort myUShort = 8;
          float myFloat = 15.0f;
          double myDouble = 20.0;
          char myCharacter = 'F';
          bool myBool = true;
          string myText = "I control text";
          string numText = "5";

          Console.WriteLine(myByte);
          Console.WriteLine(mySbyte);
          Console.WriteLine(myInt);
          Console.WriteLine(myUint);
          Console.WriteLine(myShort);
          Console.WriteLine(myUShort);
          Console.WriteLine(myFloat);
          Console.WriteLine(myDouble);
          Console.WriteLine(myCharacter);
          Console.WriteLine(myBool);
          Console.WriteLine(myText);
          Console.WriteLine(numText);
          Console.WriteLine(Text2Num(numText));
      }

      //No overload for method
      public static int Text2Num(string numText)
      {
        int tempInt;
        int.TryParse(numText, out tempInt);
        return tempInt;
      }
    }
}
