using System;

namespace LambdaIndexer
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleCollection<string> stringCollection = new SampleCollection<string>();
            stringCollection[0] = "Hello, World";
            Console.WriteLine(stringCollection[0]);
        }
    }

    //Define a class with type T
    public class SampleCollection<T>
    {
        // Declare an array to store the data elements.
        private T[] arr = new T[100];

        /* Define the indexer to allow client code to use [] notation.
         * Indexer's get and set accessors could use lambda expression 
         * if the get accessor consists of a single statement that returns 
         * a value or the set accessor performs a simple assignment.
         * Indexer lambda expression is supported from C# 7.0
         */
        public T this[int i]
        {
            get => arr[i]; 
            set => arr[i] = value; 
        }

/*      The following code is equivellant to the above one
        public T this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }
*/
    }
}
