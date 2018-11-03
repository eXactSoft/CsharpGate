using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsGenericSortedList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate a SortedList<int, string> object sortedList1
            SortedList<int, string> sortedList1 = new SortedList<int, string>();
            //Add items to the sortedList1
            sortedList1.Add(3, "Three");
            sortedList1.Add(4, "Four");
            sortedList1.Add(1, "One");
            sortedList1.Add(5, "Five");
            sortedList1.Add(2, "Two");

            //Instantiate a SortedList<string, int> object sortedList2
            SortedList<string, int> sortedList2 = new SortedList<string, int>();
            //Add items to the sortedList2
            sortedList2.Add("one", 1);
            sortedList2.Add("two", 2);
            sortedList2.Add("three", 3);
            sortedList2.Add("four", 4);
            // Compile time error: cannot convert from <null> to <int>
            // sortedList2.Add("Five", null);

            //Instantiate a SortedList<double, int?> object sortedList3
            SortedList<double, int?> sortedList3 = new SortedList<double, int?>();
            //Add items to the sortedList2, int value accept null as i declaration int?
            sortedList3.Add(1.5, 100);
            sortedList3.Add(3.5, 200);
            sortedList3.Add(2.4, 300);
            sortedList3.Add(2.3, null);
            sortedList3.Add(1.1, null);

            Console.WriteLine("_1-------------------------------------------------------------");

            //SortedList can be accessed by the key. 
            //make sure that key exists in the SortedList, otherwise it will throw KeyNotFoundException.
            Console.WriteLine(sortedList2["one"]);
            Console.WriteLine(sortedList2["two"]);
            Console.WriteLine(sortedList2["three"]);

            //Following will throw runtime exception: KeyNotFoundException
            //Console.WriteLine(sortedList2["ten"]);

            Console.WriteLine("_2-------------------------------------------------------------");

            //SortedList accessed by the index. 
            //Indexer of SortedList requires key and returns value for that key.
            for (int i = 0; i < sortedList2.Count; i++)
                Console.WriteLine("key: {0}, value: {1}", sortedList2.Keys[i], sortedList2.Values[i]);

            Console.WriteLine("_3-------------------------------------------------------------");

            //foreach statement to access generic SortedList
            //SortedList element includes both key and value pair. so, the type of element would 
            //be KeyValuePair structure rather than type of key or value.
            foreach (KeyValuePair<string, int> kvp in sortedList2)
                Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value);

            Console.WriteLine("_4-------------------------------------------------------------");
            int val;

            //TryGetValue method retrieves the value of specified key. 
            //If key doesn't exists than it will return false
            if (sortedList2.TryGetValue("ten", out val))
                Console.WriteLine("value: {0}", val);
            else
                Console.WriteLine("Key is not valid.");

            if (sortedList2.TryGetValue("one", out val))
                Console.WriteLine("value: {0}", val);

            Console.WriteLine("_5-------------------------------------------------------------");
            
            //Checks whether the specified key exists in the SortedList or not.
            Console.WriteLine( sortedList2.ContainsKey("one") ); // returns true
            Console.WriteLine( sortedList2.ContainsKey("ten") ); // returns false

            //Determines whether the specified value exists in the SortedList or not.
            Console.WriteLine( sortedList2.ContainsValue(2) ); // returns true
            Console.WriteLine( sortedList2.ContainsValue(6) ); // returns false

            Console.WriteLine("_6-------------------------------------------------------------");

            //LINQ Where() method syntax to access SortedList collection with 
            //a Func< KeyValuePair<sting,int>, bool> delegate using lambda expression 
            //as a parameter to the method Where()
            var result1 = sortedList2.Where(kvp => kvp.Key == "two").FirstOrDefault();

            Console.WriteLine("key: {0}, value: {1}", result1.Key, result1.Value);

            //LINQ query syntax to access SortedList collection using certain criteria.
            var query = from kvp in sortedList2
                        where kvp.Key == "two"
                        select kvp;

            var result2 = query.FirstOrDefault();

            Console.WriteLine("key: {0}, value: {1}", result2.Key, result2.Value);

            Console.WriteLine("_7-------------------------------------------------------------");

            //removes the element whose key is 'one'
            sortedList2.Remove("one");

            //removes the element at zero index i.e first element: four
            sortedList2.RemoveAt(0);

            foreach (KeyValuePair<string, int> kvp in sortedList2)
                Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value);

        }
    }
}
/*
 * A generic SortedList SortedList<TKey,TValue> represents a collection of key-value pairs 
 * that are sorted by key based on associated IComparer<T> A SortedList collection stores 
 * key and value pairs in ascending order of key by default. Generic SortedList implements 
 * IDictionary<TKey,TValue> & ICollection<KeyValuePair<TKey,TValue>> interfaces so elements 
 * can be access by key and index both.
 * 
 * C# includes two type of SortedList, generic SortedList and non-generic SortedList. 
 * Generic SortedList denotes with angel bracket: SortedList<TKey,TValue> where TKey is for 
 * type of key and TValue is for type of value. Non-generic type do not specify the type 
 * of key and values.
 * 
 * Internally, SortedList maintains a two object[] array, one for keys and another for values. 
 * So when you add key-value pair, it does binary search using key to find an appropriate 
 * index to store a key and value in respective arrays. It also re-arranges the elements 
 * when you remove the elements from it.
 * 
 * Important Properties Generic SortedList
        Capacity:	Gets or sets the number of elements that the SortedList<TKey,TValue> can store.
        Count:	    Gets the total number of elements exists in the SortedList<TKey,TValue>.
        IsReadOnly:	Returns a boolean indicating whether the SortedList<TKey,TValue> is read-only.
        Item:	    Gets or sets the element with the specified key in the SortedList<TKey,TValue>.
        Keys:	    Get list of keys of SortedList<TKey,TValue>.
        Values:	    Get list of values in SortedList<TKey,TValue>.
 * Important Methods of Generic SortedList
        Add:	        Add key-value pairs into SortedList<TKey, TValue>.
        Remove:	        Removes element with the specified key.
        RemoveAt:	    Removes element at the specified index.
        ContainsKey:	Checks whether the specified key exists in SortedList<TKey, TValue>.
        ContainsValue:	Checks whether the specified key exists in SortedList<TKey, TValue>.
        Clear:	        Removes all the elements from SortedList<TKey, TValue>.
        IndexOfKey:	    Returns an index of specified key stored in internal array 
                        of SortedList<TKey, TValue>.
        IndexOfValue:	Returns an index of specified value stored in internal array of 
                        SortedList<TKey, TValue>
        TryGetValue:	Returns true and assigns the value with specified key, 
                        if key does not exists then return false.
 * 
 * SortedList collection sorts the elements everytime you add the elements. 
 * So the keys will be in ascending order even if they are added randomly.
 * 
 * The SortedList can be accessed by the index or key. Unlike other collection types, 
 * Indexer of SortedList requires key and returns value for that key. However, 
 * please make sure that key exists in the SortedList, otherwise it will throw 
 * KeyNotFoundException.
 * 
 * The foreach statement in C# can be used to access the SortedList collection. 
 * SortedList element includes both key and value pair. so, the type of element 
 * would be KeyValuePair structure rather than type of key or value.
 * 
 * If you are not sure that particular key exists or not than use TryGetValue method 
 * to retrieve the value of specified key. If key doesn't exists than it will return 
 * false instead of throwing exception.
 * 
 * You can use LINQ query syntax or method syntax to access SortedList collection using 
 * different criteria
 * 
 * Points to Remember :
 *      C# has a generic and non-generic SortedList.
 *      SortedList stores the key-value pairs in ascending order of the key. 
 *        The key must be unique and cannot be null whereas value can be null or duplicate.
 *      Generic SortedList stores keys and values of specified data types. 
 *        So no need for casting.
 *      Key-value pair can be cast to a KeyValuePair<TKey,TValue>.
 *      An individual value can be accessed using an indexer. SortedList indexer 
 *        accepts key to return value associated with it.
 * 
 */
