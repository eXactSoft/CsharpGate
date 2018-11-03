using System;

namespace VAR
{
    class Program
    {
        static void Main(string[] args)
        {
            int ex = 100;// explicitly typed 
            var im = 100; // implicityly type

            var i = 10;
            Console.WriteLine("Type of i is {0}", i.GetType().ToString());

            var str = "Hello World!!";
            Console.WriteLine("Type of str is {0}", str.GetType().ToString());

            var d = 100.50d;
            Console.WriteLine("Type of d is {0}", d.GetType().ToString());

            var b = true;
            Console.WriteLine("Type of b is {0}", b.GetType().ToString());
        }
    }
}
/*
 * C# 3.0 introduced the implicit typed local variable "var". Var can only be defined in a method as a local
 * variable. The compiler will infer its type based on the value to the right of the "=" operator.
 * 
 * Var can be used in the following different contexts:
 *  Local variable in a function
 *  For loop
 *  Foreach loop
 *  Using statement
 *  As an anonymous type
 *  In a LINQ query expression
 * 
 * Points to Remember :
 *   var can only be declared and initialized in a single statement. Following is not valid:
 *   var i; i = 10;
 *   var cannot be used as a field type at the class level.
 *   var cannot be used in an expression like var i += 10;
 *   Multiple vars cannot be declared and initialized in a single statement. For example, var i=10, j=20; 
 *   is invalid.
 * 
 */
