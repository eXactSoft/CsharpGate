using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsNonGenericHashtable
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate a Hashtable object ht
            Hashtable ht = new Hashtable();

            //Adds an item with a key and value into the Hashtable. Key and value can be 
            //of any data type. Key cannot be null whereas value can be null.
            ht.Add(1, "One");
            ht.Add(2, "Two");
            ht.Add(3, "Three");
            ht.Add(4, "Four");
            ht.Add(5, null);
            ht.Add("Fv", "Five");
            ht.Add(8.5F, 8.5);

            //Another way to add values into the Hashtable at the same line of instantiation.
            //using object initializer syntax.
            Hashtable ht2 = new Hashtable()
                {
                    { 1, "One" },
                    { 2, "Two" },
                    { 3, "Three" },
                    { 4, "Four" },
                    { 5, null },
                    { "Fv", "Five" },
                    { 8.5F, 8.5 }
                };

            //Hashtable can include all the elements of Dictionary
            Dictionary<int, string> dict = new Dictionary<int, string>();

            dict.Add(1, "one");
            dict.Add(2, "two");
            dict.Add(3, "three");

            Hashtable ht3 = new Hashtable(dict);


            Console.WriteLine("_1-------------------------------------------------------------");

            //iterate the Hashtable by casting each element in Hashtable to DictionaryEntry.
            foreach (DictionaryEntry item in ht2)
                Console.WriteLine("key:{0}, value:{1}", item.Key, item.Value);


            Console.WriteLine("_2-------------------------------------------------------------");

            //Retrives the value of an existing key from the Hashtable using indexer.
            string strValue1 = (string)ht[2];
            string strValue2 = (string)ht["Fv"];
            float fValue = (float)ht[8.5F];

            Console.WriteLine(strValue1);
            Console.WriteLine(strValue2);
            Console.WriteLine(fValue);

            Console.WriteLine("_3-------------------------------------------------------------");

            //Gets the keys and values.
            foreach (var key in ht.Keys)
                Console.WriteLine("Key:{0}, Value:{1}", key, ht[key]);

            Console.WriteLine("***All Values***");
            //Get all values
            foreach (var value in ht.Values)
                Console.WriteLine("Value:{0}", value);

            Console.WriteLine("_4-------------------------------------------------------------");

            //Checks whether the specified key exists in the Hashtable collection.
            Console.WriteLine( ht.Contains(2) );// returns true
            Console.WriteLine( ht.ContainsKey(2) );// returns true
            Console.WriteLine( ht.Contains(5) ); //returns false
            Console.WriteLine( ht.ContainsValue("One") ); // returns true

            Console.WriteLine("_5-------------------------------------------------------------");

            //Removes the item with the specified key from the hashtable.
            ht.Remove("Fv"); // removes {"Fv", "Five"}

            foreach (DictionaryEntry item in ht)
                Console.WriteLine("key:{0}, value:{1}", item.Key, item.Value);

            Console.WriteLine("_6-------------------------------------------------------------");

            Console.WriteLine("Total Elements: {0}", ht.Count);

            //Removes all the key-value pairs in the Hashtable.
            ht.Clear(); // removes all elements

            Console.WriteLine("Total Elements: {0}", ht.Count);
        }
    }
}
/*
 * C# includes Hashtable collection in System.Collections namespace, which is similar 
 * to generic Dictionary collection. The Hashtable collection stores key-value pairs. 
 * It optimizes lookups by computing the hash code of each key and stores it in a different 
 * bucket internally and then matches the hash code of the specified key at the time of 
 * accessing values.
 * 
 * Important Propertis of Hashtable
        Count:	    Gets the total count of key/value pairs in the Hashtable.
        IsReadOnly:	Gets boolean value indicating whether the Hashtable is read-only.
        Item:	    Gets or sets the value associated with the specified key.
        Keys:	    Gets an ICollection of keys in the Hashtable.
        Values:	    Gets an ICollection of values in the Hashtable.
 * Important Methods of Hashtable
        Add:	        Adds an item with a key and value into the hashtable.
        Remove:	        Removes the item with the specified key from the hashtable.
        Clear:	        Removes all the items from the hashtable.
        Contains:	    Checks whether the hashtable contains a specific key.
        ContainsKey:	Checks whether the hashtable contains a specific key.
        ContainsValue:	Checks whether the hashtable contains a specific value.
        GetHash:	    Returns the hash code for the specified key.
 *
 * Add() will throw an exception if you try to add a key that already exists in the Hashtable.
 * So always check the key using the Contains() or ContainsKey() method before 
 * adding a key-value pair into the Hashtable.
 * 
 * You can retrive the value of an existing key from the Hashtable using indexer. 
 * Please note that the hashtable indexer requires a key.
 * 
 * Hashtable is a non-generic collection so it can contains a key and a value of any data type. 
 * So values must be cast to an appropriate data type otherwise it will give compile-time 
 * error.
 * 
 * Hashtable elements are key-value pairs stored in DictionaryEntry. So you cast each element in 
 * Hashtable to DictionaryEntry. Use the foreach statement to iterate the Hashtable.
 * 
 * Points to Remember :
 *      Hashtable stores key-value pairs of any datatype where the Key must be unique.
 *      The Hashtable key cannot be null whereas the value can be null.
 *      Hashtable retrieves an item by comparing the hashcode of keys. 
 *        So it is slower in performance than Dictionary collection.
 *      Hashtable uses the default hashcode provider which is object.GetHashCode(). 
 *        You can also use a custom hashcode provider.
 *      Use DictionaryEntry with foreach statement to iterate Hashtable.
 * 
 */
