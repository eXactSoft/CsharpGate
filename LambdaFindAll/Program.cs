using System;
using System.Collections.Generic;

namespace LambdaFindAll
{
    class Program
    {
        /*
         * The following example loops through the entire collection of numbers and each 
         * element (named x) is checked to determine if the number is a multiple 
         * of 2 (using the Boolean expression (x % 2) == 0).
         */
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 };

            //Retrieve all the elements that match the condition defined by passing 
            //the delegate Predicate<int> object initialized using lambda expression,
            //as a parameter to the method FindAll()
            // x refers to each element of the List list.
            List<int> evenNumbers = list.FindAll(x => (x % 2) == 0);

            foreach (var num in evenNumbers)
            {
                Console.Write("{0} ", num);
            }
            Console.WriteLine();
        }
    }
}

/*Lambda expressions are how anonymous functions are created.

Lambda expressions are anonymous functions that contain expressions or 
sequence of operators. All lambda expressions use the lambda operator =>, 
that can be read as “goes to” or “becomes”. 

The left side of the lambda operator specifies the input parameters and the right 
side holds an expression or a code block that works with the entry parameters. 
Usually lambda expressions are used as predicates or 
instead of delegates (a type that references a method).

Expression Lambdas

Parameter => expression
Parameter-list => expression
Count => count + 2;
Sum => sum + 2;
n => n % 2 == 0

The lambda operator => divides a lambda expression into two parts. 
The left side is the input parameter and the right side is the lambda body.

*/
