using System;
using System.Linq;

namespace LambdaEnumerableWhere
{
    class Program
    {
        /*The following example shows how to write a lambda expression for the overload 
         * of the standard query operator Enumerable.Where that takes two arguments. 
         * Because the lambda expression has more than one parameter, the parameters 
         * must be enclosed in parentheses. The second parameter, index, represents 
         * the index of the current element in the collection. The Where expression 
         * returns all the strings whose lengths are less than their index positions 
         * in the array.
         */ 
        static void Main(string[] args)
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five",
            "six", "seven", "eight", "nine" };

            Console.WriteLine("Example that uses a lambda expression:");

            //Filters the digits array by passing a Func<string, int, bool> delegate,
            //initialized by an anynoums method with 2 parameters, and lambda expression 
            //passed as a parameter to the method Where().
            //digit refers to each element of the array digits, 
            //index is the index of the digit of each element of the array digits.
            var shortDigits = digits.Where((digit, index) => digit.Length < index);

            foreach (var sD in shortDigits)
            {
                Console.WriteLine(sD);
            }

            // Output:-
            // five  
            // six  
            // seven  
            // eight  
            // nine  
        }
    }
}
