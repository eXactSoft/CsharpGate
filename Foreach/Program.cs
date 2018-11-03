using System;
using System.Collections.Generic;

namespace Foreach
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_1-------------------------------------------------------------");
            //Usage of the foreach statement with an instance of the List<T> type 
            //that implements the IEnumerable<T> interface
            var fibNumbers = new List<int> { 0, 1, 1, 2, 3, 5, 8, 13 };
            int count = 0;
            foreach (int element in fibNumbers)
            {
                count++;
                Console.WriteLine($"Element #{count}: {element}");
            }
            Console.WriteLine($"Number of elements: {count}");

            Console.WriteLine("_2-------------------------------------------------------------");
            //Usage the foreach statement with an instance of the System.Span<T> type, which doesn't 
            //implement any interfaces
            Span<int> numbers = new int[] { 3, 14, 15, 92, 6 };
            foreach (int number in numbers)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();

            Console.WriteLine("_3-------------------------------------------------------------");
            /* Use a ref iteration variable to set the value of each item in a stackalloc 
             * array. The ref readonly version iterates the collection to print all the values. 
             * The readonly declaration uses an implicit local variable declaration.
             */ 
            Span<int> storage = stackalloc int[10];
            int num = 0;

            //Set the value of each item in a stackalloc array
            foreach (ref int item in storage)
            {
                item = num++;//Increase 1 after the assignment operation
            }

            //Iterates the collection to print all the values
            foreach (ref readonly var item in storage)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
/*
 * The foreach statement executes a statement or a block of statements for each element in 
 * an instance of the type that implements the System.Collections.IEnumerable or 
 * System.Collections.Generic.IEnumerable<T> interface. 
 * The foreach statement is not limited to those types and can be applied to an instance of 
 * any type that satisfies the following conditions:
 *      has the public parameterless GetEnumerator method whose return type is either class, 
 *      struct, or interface type,
 *      & the return type of the GetEnumerator method has the public Current property 
 *      and the public parameterless MoveNext method whose return type is Boolean.
 * 
 * At any point within the foreach statement block, you can break out of the loop by using 
 * the break statement, or step to the next iteration in the loop by using the continue 
 * statement. You also can exit a foreach loop by the goto, return, or throw statements.
 * 
 * Beginning with C# 7.3, if the enumerator's Current property returns a reference return 
 * value (ref T where T is the type of the collection element), you can declare the iteration 
 * variable with the ref or ref readonly modifier. 
 * 
 * Implicit variable declarations can be used with either ref or 
 * ref readonly declarations, as can explicitly typed variable declarations.
 * 
 * 
 */
