using System;
using System.Collections;

namespace CollectionsNonGenericSortedList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare & initialize sortedList1 SortedList, add elements later
            SortedList sortedList1 = new SortedList();
            //Add key-value pairs into the sortedList1.
            sortedList1.Add(3, "Three");
            sortedList1.Add(4, "Four");
            sortedList1.Add(1, "One");
            sortedList1.Add(5, "Five");
            sortedList1.Add(2, "Two");

            SortedList sortedList2 = new SortedList();
            sortedList2.Add("one", 1);
            sortedList2.Add("two", 2);
            sortedList2.Add("three", 3);
            sortedList2.Add("four", "Ok");

            SortedList sortedList3 = new SortedList();
            sortedList3.Add(1.5, 100);
            sortedList3.Add(3.5, 200);
            sortedList3.Add(2.4, 300);
            sortedList3.Add(2.3, null);
            sortedList3.Add(1.1, null);

            //Access SortedList elements
            int n = (int)sortedList2["one"];
            string m = (string)sortedList2["four"];
            int str = (int)sortedList3[3.5];

            Console.WriteLine("_1-------------------------------------------------------------");
            //Access values using for loop
            for (int i = 0; i < sortedList2.Count; i++)
            {
                Console.WriteLine("key: {0}, value: {1}",
                        sortedList2.GetKey(i), sortedList2.GetByIndex(i));
            }

            Console.WriteLine("_2-------------------------------------------------------------");
            //Access values using foreach loop
            foreach (DictionaryEntry kvp in sortedList2)
                Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value);

            Console.WriteLine("_3-------------------------------------------------------------");
            //Removes element whose key is 'one'
            sortedList2.Remove("one");

            foreach (DictionaryEntry kvp in sortedList2)
                Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value);

            Console.WriteLine("_4-------------------------------------------------------------");
            //Removes element at zero index i.e first element
            sortedList2.RemoveAt(0);

            foreach (DictionaryEntry kvp in sortedList2)
                Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value);

            Console.WriteLine("_5-------------------------------------------------------------");
            //Determine whether the specified key exists in the SortedList collection or not.
            Console.WriteLine( sortedList2.ContainsKey("three") ); // returns true

            //Determines whether the specified value exists in the SortedList or not.
            Console.WriteLine( sortedList2.ContainsValue(9) ); // returns false
        }
    }
}
/*
 * C# includes two types of SortedList, generic SortedList and non-generic SortedList. 
 * Here, we will learn about non-generic SortedList.
 * The SortedList collection stores key-value pairs in the ascending order of key by default. 
 * SortedList class implements IDictionary & ICollection interfaces, so elements can 
 * be accessed both by key and index.
 * 
 * Important Properties of SortedList
        Capacity:	Gets or sets the number of elements that the SortedList instance can store.
        Count:	    Gets the number of elements actually contained in the SortedList.
        IsFixedSize:Gets a value indicating whether the SortedList has a fixed size.
        IsReadOnly:	Gets a value indicating whether the SortedList is read-only.
        Item:	    Gets or sets the element at the specified key in the SortedList.
        Keys:	    Get list of keys of SortedList.
        Values: 	Get list of values in SortedList.
 * 
 * Note : Internally, SortedList maintains two object[] array, one for keys and another for 
 * values. So when you add key-value pair, it runs a binary search using the key to find an 
 * appropriate index to store a key and value in respective arrays. It re-arranges the 
 * elements when you remove the elements from it.
 * SortedList collection sorts the elements everytime you add the elements. 
 * So if you debug the above example, you will find keys in ascending order even 
 * if they are added randomly.
 * SortedList key can be of any data type, but you cannot add keys of different data types 
 * in the same SortedList.
 * 
 * Key cannot be null but value can be null. Also, datatype of all keys must be same, 
 * so that it can compare otherwise it will throw runtime exception.
 * 
 * SortedList can be accessed by index or key. Unlike other collection, SortedList requires 
 * key instead of index to access a value for that key.
 * 
 * Points to Remember :
 *      C# has generic and non-generic SortedList.
 *      SortedList stores the key-value pairs in ascending order of the key. Key must be unique and cannot be null whereas value can be null or duplicate.
 *      Non-generic SortedList stores keys and values of any data types. So values needs to be cast to appropriate data type.
 *      Key-value pair can be cast to DictionaryEntry.
 *      Access individual value using indexer. SortedList indexer accepts key to return value associated with it.
 * 
 */
