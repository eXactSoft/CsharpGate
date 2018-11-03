using System;
using System.Collections.Generic;

namespace CollectionsGenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate a List<int> object intList1
            List<int> intList = new List<int>();
            //Add items to the List
            intList.Add(10);
            intList.Add(20);
            intList.Add(30);
            intList.Add(40);

            //Another way to instantiate a List<string> object intList2
            IList<string> strList = new List<string>();
            //Add items to the List
            strList.Add("one");
            strList.Add("two");
            strList.Add("three");
            strList.Add("four");
            strList.Add("four");
            strList.Add(null);
            strList.Add(null);

            //Instantiate a List<Student> object studentList and add items at the same time,
            //using object initializer syntax
            IList<Student> studentList = new List<Student>() {
                new Student(){ StudentID=1, StudentName="Bill"},
                new Student(){ StudentID=2, StudentName="Steve"},
                new Student(){ StudentID=3, StudentName="Ram"},
                new Student(){ StudentID=1, StudentName="Moin"}
            };

            List<int> intList2 = new List<int>();
            //adds all the elements from another collection.
            intList2.AddRange(intList);

            Console.WriteLine("_1-------------------------------------------------------------");

            //Use a List<T> Built-In ForEach to iterate a List<T> collection.
            //Pass an Action delegate using lambda expresion as a parameter to ForEach() method
            //Instead here you can use for or foreach loop too
            intList.ForEach(el => Console.WriteLine(el));

            Console.WriteLine("_2-------------------------------------------------------------");

            //If you have initialized the List<T> with an IList<T> interface then use seperate 
            //foreach statement with implicitly typed variable
            foreach (var el in strList)
                Console.WriteLine(el);

            Console.WriteLine("_3-------------------------------------------------------------");

            //Iterates a List<T> or IList<T> collection using for loop
            for (int i = 0; i < strList.Count; i++)
                Console.WriteLine(strList[i]);

            //---------------------------------------------------------------------------------
            //Access individual items by using an indexer
            int elem = intList[1]; // returns 20

            Console.WriteLine("_4-------------------------------------------------------------");

            //List<T> implements IList<T>, so List<T> implicitly type cast to IList<T>
            Print(intList);

            Console.WriteLine("_5-------------------------------------------------------------");

            //Inserts an element into a List<T> collection at the specified index.
            intList.Insert(1, 11);// inserts 11 at 1st index: after 10.

            intList.ForEach(el => Console.WriteLine(el));

            Console.WriteLine("_6-------------------------------------------------------------");

            // removes the first occurence of 10 from a list
            intList.Remove(10);

            //removes the 3rd element (index starts from 0)
            intList.RemoveAt(2); 

            foreach (var el in intList)
                Console.WriteLine(el);

            Console.WriteLine("_7-------------------------------------------------------------");

            //TrueForAll()  returns true if the specified condition turns out to be true, 
            //otherwise false. This valid only for List<T> not IList<T>.
            // Predicate delegate is passed of type Predicate<T> to the TrueForAll() method as 
            // a parameter using named method or lambda expression
            //Pass the Predicate<int> delegate as named method
            bool res1 = intList.TrueForAll(isPositiveInt);

            //Pass the Predicate<int> delegate as lambda expression
            bool res2 = intList.TrueForAll(n => n>0);
            
            Console.WriteLine(res1);
            Console.WriteLine(res2);

        }

        //Method with the same signature as a Predicate<int> delegate
        static bool isPositiveInt(int i)
        {
            return i > 0;
        }

        static void Print(IList<int> list)
        {
            Console.WriteLine("Count: {0}", list.Count);
            foreach (int value in list)
            {
                Console.WriteLine(value);
            }
        }

        public class Student
        {
            public string StudentName { get; set; }
            public int StudentID { get; set; }
        }
    }
}
/*
 * An ArrayList resizes automatically as it grows. The List<T> collection is the same as 
 * an ArrayList except that List<T> is a generic collection whereas ArrayList is 
 * a non-generic collection.
 * 
 * List<T> is a concreate implementation of IList<T> interface. In the object-oriented 
 * programming, it is advisable to program to interface rather than concreate class. 
 * So use IList<T> type variable to create an object of List<T>.
 * 
 * List<T> includes more helper methods than IList<T> interface.
 * 
 * Important Propertis of List<T>:
 *      Items:	Gets or sets the element at the specified index
 *      Count:	Returns the total number of elements exists in the List<T>
 * Important Methods of List<T>:
        Add:	        Adds an element at the end of a List<T>.
        AddRange:	    Adds elements of the specified collection at the end of a List<T>.
        BinarySearch:	Search the element and returns an index of the element.
        Clear:	        Removes all the elements from a List<T>.
        Contains:	    Checks whether the speciied element exists or not in a List<T>.
        Find:	        Finds the first element based on the specified predicate function.
        Foreach:	    Iterates through a List<T>.
        Insert:	        Inserts an element at the specified index in a List<T>.
        InsertRange:	Inserts elements of another collection at the specified index.
        Remove:	        Removes the first occurence of the specified element.
        RemoveAt:	    Removes the element at the specified index.
        RemoveRange:	Removes all the elements that match with the supplied predicate function.
        Sort:	        Sorts all the elements.
        TrimExcess:	    Sets the capacity to the actual number of elements.
        TrueForAll:	    Determines whether every element in theÂ List<T> matches the conditions 
                        defined by the specified predicate.
 *
 * The AddRange() method will only be applicable if you initialized with a List<T> variable. IList<T> 
 * doesn't include the AddRange() method.
 * 
 * Points to Remember :
 *      List<T> stores elements of the specified type and it grows automatically.
 *      List<T> can store multiple null and duplicate elements.
 *      List<T> can be assigned to IList<T> or List<T> type of variable. 
 *        It provides more helper method When assigned to List<T> variable
 *      List<T> can be access using indexer, for loop or foreach statement.
 *      LINQ can be use to query List<T> collection.
 *      List<T> is ideal for storing and retrieving large number of elements.
 * 
 */
