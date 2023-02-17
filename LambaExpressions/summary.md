# Lambda Expressions and Expression Body

### Shorter code, faster results! - A 'sales pitch' on why you should use them

# ```> ~/Presentation/Expression_Body```

Tired of curly braces and returns?
Ever find yourself spending too much time writing out code that should just be shorter?
Are you looking to make your code even more READABLE?
Well look no more! because _Expression-Bodied Members_ got you covered!

Expression-Bodied Members have a short, 'straight to the point', syntax to help you define members such as properties and methods. We use the ```=>``` operator to define the body of the method or property.

> Note: This is only possible when a member's body consists of a single expression.

The general usage of the syntax is as follows:

```csharp
member => expression;
```

Now, let's see some examples on how this could improve your code...

### Methods

Here's an example of a regular method:

```csharp
int AddTwoNumbers(int x, int y)
{
    return x + y;
}
```

And now here it is using expression-bodied syntax:

```csharp
int AddTwoNumbers(int x, int y) => x + y;
```

As you can see, using expression-bodied syntax, we were able to omit the curly braces as well as the _return_ statement.

Similarly, here is an example using a _void_ method:

```csharp
void PrintMessage(string message)
{
    Console.WriteLine(message);
}
```

Here it is using expression-bodied syntax:

```csharp
void PrintMessage(string message) => Console.WriteLine(message);
```

### Properties

You're able to use expression-bodied members for your properties as well. Starting with ```C# 6.0```, it was made possible to have expression-bodied accessors on _Read-only_ properties (_get_). As of ```C# 7.0``` however, non-read-only properties can also have expression-bodied accessors (_get_ & _set_).
> Note: As of November 2022, the most recent stable version of the language is ```C# 11.0```, which was released in 2022 in ```.NET 7.0```

Regular property:

```csharp
public class MyFile
{
    private string _fileName;
    
    public string fileName
    {
        get 
        {
            return _fileName;
        }
        set 
        {
           _fileName = value;
        }
    }
}
```

Using expression-bodied accessors:

```csharp
public class MyFile
{
    private string _fileName;
    
    public string fileName
    {
        get => _fileName;
        set => _fileName = value;
    }
}
```

### Constructors & Finalizers

You can also use expression-bodied members for constructors and finalizers (destructors) as long as they only contain a single statement:

```csharp
public class Location
{
   private string locationName;
    
    /* Constructor using expression-bodied syntax...
     * The name argument is passed through the constructor
     * which then uses the accessors below to initialize locationName.
    */
   public Location(string name) => Name = name;
   
   // Finalizer using expression-bodied syntax to indicate that it has been invoked.
    ~Location() => Console.WriteLine("Location finalizer is executing.");

   public string Name
   {
      get => locationName;
      set => locationName = value;
   }
}
```

### Indexers

Indexers can also use the expression-bodied syntax for the _get_ & _set_ accessors just like properties if they consist of a single expression:

```csharp
using System;
using System.Collections.Generic;

public class Sports
{
   private string[] types = { "Baseball", "Basketball", "Football",
                              "Hockey", "Soccer", "Tennis",
                              "Volleyball" };

   public string this[int i]
   {
      get => types[i]; //returning the value of index i.
      set => types[i] = value; //setting the value of index i.
   }
}
```

# ```> ~/Presentation/Lambda_Expressions```

Lambda expressions allow you to create anonymous functions with the ```=>``` operator. As you can see, it uses the same operator as expression-bodied members. This is because, in reality, lambda expressions are ```expression-bodied lambdas```. Lambda expressions are blocks of codes that are treated as objects. They can be passed as arguments into methods, as well as returned by method calls. If this is something that interests you, then you should also check out LINQ as you can use the queries together with lambda. A lambda expression can be converted to a delegate type; If it doesn't return a value it can be converted to one of the Action delegate types, otherwise it can be converted to one of the func delegate types.

> Note: This can actually **impact** readability in cases where you use multiple lambda expressions to achieve what you're looking for. In that case, you might just be better off writing out the code and/or creating a method for it.

The general usage of the syntax is as follows:

```csharp
//Expression lambda that has an expression as its body:
(input-parameters) => expression

//Statement lambda that has a statement block as its body:
(input-parameters) => { <sequence-of-statements> }
```

To create a lambda expression, you specify input parameters (if any) on the left side of the lambda operator and an expression or a statement block on the other side.

### Expression Lambdas (Expression-bodied Lambdas)

Here's example code which using lambda expressions:

```csharp

// C# program to illustrate the
// Lambda Expression
using System;
using System.Collections.Generic;
using System.Linq;
 
// User defined class Student
class Student {
     
    // properties rollNo and name
    public int rollNo
    {
        get;
        set;
    }
     
    public string name
    {
        get;
        set;
    }
}
 
class GFG {
     
    // Main Method
    static void Main(string[] args)
    {
        // List with each element of type Student
        List<Student> details = new List<Student>() {
            new Student{ rollNo = 1, name = "Liza" },
                new Student{ rollNo = 2, name = "Stewart" },
                new Student{ rollNo = 3, name = "Tina" },
                new Student{ rollNo = 4, name = "Stefani" },
                new Student { rollNo = 5, name = "Trish" }
        };
 
        /*given each student in details, we'd like to get the name of the student
         * and use that name to order the list.
        */
        var newDetails = details.OrderBy(student => student.name);
        
        /*instead of using a regular foreach loop, we shrink it down using a lambda expression
         * for each student in newDetails, we'd like to give the student object as a parameter
         * and then, we want to use that to print the student's rollNo and name to console.
        */
        newDetails.ForEach(student => Console.WriteLine(student.rollNo + " " + student.name));
    }
}
/* Output - remember we're using the NAMES to order them, not the numbers
 * 1 Liza
 * 4 Stefani
 * 2 Stewart
 * 3 Tina
 * 5 Trish
*/
```

Example converting to a delegate:

```csharp
Func<int, int> square = x => x * x; //example converting to Func delegate type since it returns a value
Console.WriteLine(square(5));
/* Output:
 * 25
 */
```

### Statement Lambas (Using Block Body Instead Of Expression Body)

A statement lambda is similar to an expression lambda except that its statements are enclosed in braces. The body of a statement lambda can consist of any number of statements. However, in practice, there are typically no more than two or three.

```csharp
/* For the argument 'name', we'd like to insert the argument into
 * the 'greeting' string. Then, we'll print 'greeting' on the console. 
*/
Action<string> greet = name => //example converting to Action delegate type since it doesn't return a value
{
    string greeting = $"Hello {name}!";
    Console.WriteLine(greeting);
};
greet("World"); //passing "World" as an argument
/* Output:
 * Hello World!
*/
```

# ```> ~/Presentation/Closing_Remarks```

After all this, hopefully the benefits and use cases of expression-bodied syntax and lambda expressions persuade you to try them. With both Lambda expressions and expression body you're able to shrink code and improve readability. However when using lambdas, make sure you're careful about **overusing** them; This could actually have a negative effect by making your code harder to read.

# ```> ~/Presentation/Relevant_Links_And_References```

- [Use expression body for lambdas (IDE0053)](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0053)
- [Language Integrated Query (LINQ) (C#) - Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)
- [System.Linq Namespace - Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/api/system.linq?view=net-7.0)
- [Lambda expressions and anonymous functions - Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions#statement-lambdas)
- [Lambda Expressions in C# - Geeks For Geeks](https://www.geeksforgeeks.org/lambda-expressions-in-c-sharp/)
- [Expression-bodied members (C# programming guide) - Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members)
- [Expression-Bodied Members in C# - Geeks For Geeks](https://www.geeksforgeeks.org/expression-bodied-members-in-c-sharp/)
