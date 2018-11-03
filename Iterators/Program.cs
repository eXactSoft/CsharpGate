using System;
using System.Collections;

namespace Iterators
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_1-------------------------------------------------------------");
            /*
             * In the following example, the first iteration of the foreach loop causes 
             * execution to proceed in the SomeNumbers iterator method until the first 
             * yield return statement is reached. This iteration returns a value of 3, 
             * and the current location in the iterator method is retained. On the next 
             * iteration of the loop, execution in the iterator method continues from 
             * where it left off, again stopping when it reaches a yield return statement. 
             * This iteration returns a value of 5, and the current location in the iterator 
             * method is again retained. The loop completes when the end of the iterator 
             * method is reached.
             * The return type of an iterator method or get accessor can be IEnumerable, 
             * IEnumerable<T>, IEnumerator, or IEnumerator<T>.
             * You can use a yield break statement to end the iteration.
             * 
             */
            foreach (int number in SomeNumbers())
             {
                Console.WriteLine(number.ToString() + " ");
             }
            // Output: 3 5 8

            Console.WriteLine("_2-------------------------------------------------------------");
            /*
             * The following example uses an iterator method. The iterator method has a 
             * yield return statement that is inside a for loop. In the ListEvenNumbers method, 
             * each iteration of the foreach statement body creates a call to the iterator method, 
             * which proceeds to the next yield return statement.
             * 
             * The following example has a single yield return statement that is inside a for loop. 
             * In Main, each iteration of the foreach statement body creates a call to the iterator 
             * function, which proceeds to the next yield return statement.
             * 
             */
            foreach (int number in EvenSequence(5, 18))
             {
                Console.WriteLine(number.ToString() + " ");
             }
            // Output: 6 8 10 12 14 16 18

            Console.WriteLine("_3-------------------------------------------------------------");
            /*
             * In the following example, the DaysOfTheWeek class implements the IEnumerable 
             * interface, which requires a GetEnumerator method. The compiler implicitly 
             * calls the GetEnumerator method, which returns an IEnumerator.
             */
             DaysOfTheWeek days = new DaysOfTheWeek();

             foreach (string day in days)
             {
                Console.WriteLine(day + " ");
             }
             // Output: Sun Mon Tue Wed Thu Fri Sat
        }

        public static System.Collections.IEnumerable SomeNumbers()
        {
            yield return 3;
            yield return 5;
            yield return 8;
        }

        public static System.Collections.Generic.IEnumerable<int> EvenSequence(int firstNumber, int lastNumber)
        {
            // Yield even numbers in the range.
            for (int number = firstNumber; number <= lastNumber; number++)
            {
                if (number % 2 == 0)
                {
                    yield return number;
                }
            }
        }

        public class DaysOfTheWeek : IEnumerable
        {
            private string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            public IEnumerator GetEnumerator()
            {
                for (int index = 0; index < days.Length; index++)
                {
                    // Yield each day of the week.
                    yield return days[index];
                }
            }
        }


    }
}
/*
 * An iterator can be used to step through collections such as lists and arrays.
 * 
 * An iterator method or get accessor performs a custom iteration over a collection. 
 * An iterator method uses the yield return statement to return each element one at a time. 
 * When a yield return statement is reached, the current location in code is remembered. 
 * Execution is restarted from that location the next time the iterator function is called.
 * 
 * You consume an iterator from client code by using a foreach statement or by using 
 * a LINQ query.
 * 
 * An iterator is used to perform a custom iteration over a collection. An iterator can be 
 * a method or a get accessor. An iterator uses a yield return statement to return each 
 * element of the collection one at a time.
 * 
 * You call an iterator by using a foreach statement. Each iteration of the foreach loop 
 * calls the iterator. When a yield return statement is reached in the iterator, 
 * an expression is returned, and the current location in code is retained. Execution is 
 * restarted from that location the next time that the iterator is called.
 * 
 * The return type of an iterator method or get accessor can be IEnumerable, IEnumerable<T>, 
 * IEnumerator, or IEnumerator<T>.
 * 
 * You can use a yield break statement to end the iteration.
 * 
 * 
 * 
 * 
 * 
 * 
 */
