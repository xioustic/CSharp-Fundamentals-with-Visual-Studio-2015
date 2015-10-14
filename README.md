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
- Properties
    + A property can be created within a class by making it a public variable with body containing get and set bodies. get and set can be declared without bodies to use the default get and set methods. Example:
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