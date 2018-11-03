using System;

namespace TernaryOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 20, y = 10;

            Console.WriteLine("_1-------------------------------------------------------------");
            //Using if else
            string result1="";
            if (x > y)
                result1 = "x is greater than y";
            else if (x < y)
                result1 = "x is less than or equal to y";

            Console.WriteLine(result1);

            Console.WriteLine("_2-------------------------------------------------------------");
            //Use Trenary Operator ==> the same result as above
            result1 = x > y ? "x is greater than y" : "x is less than or equal to y";
            Console.WriteLine(result1);

            Console.WriteLine("_3-------------------------------------------------------------");
            //Nested ternary operator
            x =  y;
            var result2 = x > y ? "x is greater than y" : x < y ?
                "x is less than y" : x == y ?
                "x is equal to y" : "No result";
            Console.WriteLine(result2);
        }
    }
}
/*
 *C# includes a special type of decision making operator '?:' called the ternary operator.
 * Boolean Expression ? First Statement : Second Statement;
 * 
 * Ternary operator returns a value or expression included in the second or third part of it. 
 * It does not execute the statements.
 * 
 * The ternary operator can return a value of any data type. So it is advisable 
 * to store it in implicitly typed variable - var.
 * 
 * Ternary operator can also be used instead of if-else statement.
 * 
 * A nested ternary operator is allowed. It will be evaluted from right to left.
 */
