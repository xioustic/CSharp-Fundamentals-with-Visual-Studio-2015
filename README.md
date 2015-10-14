CSharp-Fundamentals-with-Visual-Studio-2015
===========================================
Projects and notes created during coursework for [Pluralsight's C# Fundamentals with Visual Studio 2015 by Scott Allen](http://www.pluralsight.com/courses/c-sharp-fundamentals-with-visual-studio-2015).

Notes
-----
- String Formatting
    + If a string has a "$" prepended to it, it's allowed to directly reference variables using handlebars.
    + Console.WriteLine allows reference using handlebars and numbered arguments.
    + String formatting allows references to have optional formatting parameters:
        * ":F2" means format as a float to two decimals
        * ":C" means format as currency
    + Examples:

        ``` c#
        static void writeResult(string description, float result)
        {
            Console.WriteLine("{0}: {1:F2}", description, result);
            Console.WriteLine($"{description}: {result:F2}");
            Console.WriteLine(description + ": " + result);
            Console.WriteLine("{0}: {1:C}", description, result);
        }
        ```

- Declaration Keywords
    + The static keyword means a class method that can be reached without creating an instance of the class.
    + The public keyword means a method or variable that can be accessed from the outside of a class instance.
    + The private keyword means a method or variable that can only be accessed internally of a class instance.
    + The internal keyword means a method or variable can only be used within the same project (?)
- Types
    + Struct vs Class
        * If small, logically immutable and there may be many instances of them, it makes sense to make them a struct.
        * Otherwise use class.
    + Value vs Reference Types
        * Structs are VALUE TYPES, which means by default when they are passed around copies are made. This is similar to primitive types like int, float, bool, and char.
        * Classes are REFERENCE TYPES, which means they are passed around by reference by default.
    + Ref & Out Keywords
        * You can use the 'ref' keyword to force something to be passed by reference. A class can be passed by reference through ref (resulting in a sort of pointer to a pointer of a class instance).
        * You can use the 'out' keyword to signify that the object will be initialized inside the function. Basically, the parameter will not be used, only set.
    + Casting
        * Types can be "casted" into other types and most explicitly do so when in a situation where precision will be lost, for example:

            ``` c#
            float testFloat = 6.21;
            int castedFloat = (int)testFloat; // 6
            ```

- Properties
    + A property can be created within a class by making it a public variable with body containing get and set bodies. get and set can be declared without bodies to use the default get and set methods. get or set can be excluded to not implement them. Example:

        ``` c#
        public class Person 
        {
            private string _privatestr;

            public Person()
            {
                _privatestr = "DON'T LOOK!";
            }

            public string GoAway
            {
                get
                {
                    Console.WriteLine("SOMEONE LOOKED!")
                    return _privatestr;
                }
                set
                {
                    Console.WriteLine("SOMEONE SET!");
                    _privatestr = value;
                }
            }
        }
        ```

- Delegates & Events
    + Delegates are a way of creating a type-safe function pointer.
    + Events are subsets of delegates but do not allow completely overwriting the list of listeners.
    + When calling events, the convention is that the first return value is itself (the sender; usually the keyword 'this' in context), and then second return value is an instance of a <something>EventArgs object (inherited from the EventArgs base class) containing all information about the event.
- Branching
    + "if (expression) {} else if (expression2) {} else {}" branching is available:

        ``` c#
        string result;
        if(AverageGrade >= 90 )
        {
            result = "A";
        }
        else if(AverageGrade >= 80)
        {
            result = "B";
        }
        else if (AverageGrade >= 70)
        {
            result = "C";
        }
        else if (AverageGrade >= 60)
        {
            result = "D";
        } else
        {
            result = "F";
        }
        return result;
        ```

    + Ternary operator available, eg:

        ``` c#
        // if age is greater than 20, pass is "pass", otherwise "nopass"
        string pass = age > 20 ? "pass" : "nopass";
        ```

    + switch statements are also available (don't forget to break!):

        ``` c#
        string result;
        switch (LetterGrade)
        {
            case "A":
                result = "Excellent";
                break;
            case "B":
                result = "Good";
                break;
            case "C":
                result = "Average";
                break;
            case "D":
                result = "Below Average";
                break;
            default:
                result = "Failing";
                break;
        }
        return result;
        ```

- Iterating
    + foreach keyword is available:
    
        ```c#
        int[] ages = {2, 21, 40, 72, 100};
        foreach (int value in age)
        {
            Console.WriteLine(value);
        }
        ```

    + standard for iterator is available; identical to c++ or javascript

        ```c#
        // for (initializer(s); test expression; iterator) {body}
        for (int i = 0; i < age; i++)
        {
            Console.WriteLine(i);
        }
        ```

    + while iterator is available (watch out for infinite loops):

        ```c#
        while (age > 0)
        {
            age -= 1;
            Console.WriteLine(age);
        }
        ```

    + do while is same as while but will always execute once:

        ```c#
        do
        {
            //stuff
        } while (age < 100);
        ```

- Jumping
    + break - leaves the current do, while, for, foreach, or switch
    + continue - skip to the next iteration of a loop
    + goto - basically don't use this, avoid at all costs, harder to follow. can jump immediately to a label in a program.
    + return - return a value for a method; voids can return with no arguments to explicitly exit a method
    + throw - used to raise an exception (an error condition exists)
- Exceptions
    + Used to provide type safe and structured error handling
    + Exceptions are objects of a known type (lots of Exception types built in to .NET)
    + Throw example:
    
        ```c#
        throw new ArgumentException("Invalid Argument!");
        ```

    + Unhandled exceptions terminate a program immediately; often print stack traces to help find the source of the runtime error.
    + Handling exceptions is done using a try/catch block; runtime searches for the closest matching catch statement. Example:

        ```c#
        try
        {
            ComputeStatistics();
        }
        catch(DivideByZeroException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
        ```

    + A try block can be followed by multiple catch statements (called chaining). Catch statements are evaluated from top-to-bottom and only one will execute, so it's important to put your most specific exceptions at the top of the chain.
    + A "finally" block can follow a try / catch block to ensure something runs even if control jumps out of scope; for example, releasing a file handle. Finally blocks always execute whether scope jumps out or not.
    + If an object has a Dispose method you can see in Intellisense, you can use the "using" statement to wrap a resource to ensure it is "finally" closed no matter what without using an explicit finaly block. Example:

        ```c#
        using(FileStream file1 = new FileStream("in.txt", FileMode.Open))
        using(FileStream file2 = new FileStream("out.txt", FileMode.Create))
        {
            // do stuff with file1 and file2
        }

        // file1 and file2 have been released at this point
        ```

- Visual Studio allows you to highlight statements within a method, hit Ctrl+., and then "extract" the statements into their own method relatively painlessly. Allows you to refactor and clean up your code quite quickly.