using System;
using System.Collections;

namespace CollectionsNonGenericArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare, initialize ArrayList arrList1, and add items all in the same line
            ArrayList arrList1 = new ArrayList() { 100, "Two", 3, 4.5 };

            //Declare, & initialize ArrayList arrList2, add items later
            ArrayList arrList2 = new ArrayList();
            //Add elements into arryList2
            arrList2.Add(100);
            arrList2.Add(200);

            //adding entire arrList2 into arrList1
            //arrList1.AddRange(arrList2);

            //Access individual item using indexer
            int firstElement = (int) arrList1[0]; //returns 1
            string secondElement = (string) arrList1[1]; //returns "Two"
            int thirdElement = (int) arrList1[2]; //returns 3
            double fourthElement = (double) arrList1[3]; //returns 4.5

            //use var keyword
            var firstVarElement = arrList1[0]; //returns 1

            Console.WriteLine("1-------------------------------------------------------------");

            //Loop through the ArrayList arrList1 using foreach loop
            foreach (var val in arrList1)
                Console.WriteLine(val);

            //Loop through the ArrayList arrList1 using for loop
            for (int i = 0; i < arrList1.Count; i++)
                Console.WriteLine(arrList1[i]);

            Console.WriteLine("2-------------------------------------------------------------");

            //Insert a single item at the specified index
            arrList1.Insert(1, "Second Item");

            foreach (var val in arrList1)
                Console.WriteLine(val);

            Console.WriteLine("3-------------------------------------------------------------");

            //Insert all the values from another collection into ArrayList at the specfied index.
            arrList2.InsertRange(2, arrList1);

            foreach (var val in arrList2)
                Console.WriteLine(val);

            Console.WriteLine("4-------------------------------------------------------------");

            //Removes the element with index 1 from arrList2
            arrList2.RemoveAt(1);

            //Removes the first element with value=100 from arrList2
            arrList2.Remove(100); 

            foreach (var item in arrList2)
                Console.WriteLine(item);

            Console.WriteLine("5-------------------------------------------------------------");

            //Removes two elements starting from 1st item (0 index)
            arrList2.RemoveRange(0,2);

            foreach (var item in arrList2)
                Console.WriteLine(item);

            Console.WriteLine("6-------------------------------------------------------------");

            //Check for an Existing Elements with value=100 in arrList2
            Console.WriteLine( arrList2.Contains(100) );

            Console.WriteLine("7-------------------------------------------------------------");

            //Sort re-arranges elements of arrList2 in ascending order.
            //However, all the elements should have same data type so that it can compare 
            //with default comparer otherwise it will throw runtime exception.
            //arrList2.Sort();

            //Reverse re-arranges elements of arrList2 in reverse order.
            arrList2.Reverse();

            foreach (var item in arrList2)
                Console.WriteLine(item);

        }
    }
}
/*
 * ArrayList is a non-generic type of collection in C#. It can contain elements of any 
 * data types. It is similar to an array, except that it grows automatically as you add 
 * items in it. Unlike an array, you don't need to specify the size of ArrayList. 
 * 
 * Important Properties and Methods of ArrayList
        Capacity:	Gets or sets the number of elements that the ArrayList can contain.
        Count:	    Gets the number of elements actually contained in the ArrayList.
        IsFixedSize:Gets a value indicating whether the ArrayList has a fixed size.
        IsReadOnly:	Gets a value indicating whether the ArrayList is read-only.
        Item:	    Gets or sets the element at the specified index.
 *
 * Points to Remember :
 *      ArrayList can store items(elements) of any datatype.   
 *      ArrayList resizes automatically as you add the elements.
 *      ArrayList values must be cast to appropriate data types before using it.
 *      ArrayList can contain multiple null and dulplicate items.
 *      ArrayList can be accessed using foreach or for loop or indexer.
 *      
 */
