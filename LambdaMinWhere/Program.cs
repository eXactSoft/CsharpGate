using System;
using System.Linq;

namespace LambdaMin
{
    class Program
    {
        /*The following example shows two ways to find and display the length of the shortest
         * string in an array of strings. The first part of the example applies a lambda 
         * expression (w => w.Length) to each element of the words array and then uses 
         * the Min method to find the smallest length. For comparison, the second part of 
         * the example shows a longer solution that uses query syntax to do the same thing.
         */
        static void Main(string[] args)
        {
            string[] words = { "cherry", "apple", "blueberry" };

            //Applying a lambda expression to each element of the words array.
            //to return the shortest word length from the array words,
            //by passing Func<string, int> delegate object initialized using lambda expression,
            //as a parameter to the method Min()
            // w refers to each element of the array words, w.Length is the length of each element of the array words.
            int shortestWordLength = words.Min(w => w.Length);

            Console.WriteLine(shortestWordLength);

            // Compare the following code that uses query syntax.  
            // Get the lengths of each word in the words array.  
            var query = from w in words
                        select w.Length;

            // Apply the Min method to execute the query and get the shortest length.  
            int shortestWordLength2 = query.Min();

            Console.WriteLine(shortestWordLength2);

            // Output:   
            // 5  
            // 5  
        }
    }
}
