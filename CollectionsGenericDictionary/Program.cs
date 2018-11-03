using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsGenericDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiates Dictionary object dict using a IDictionary<int, string> interface
            IDictionary<int, string> dict = new Dictionary<int, string>();

            //Add items to the dict using TKey, & TValue
            dict.Add(1, "One");
            dict.Add(2, "Two");
            //Add items to the dict KeyValuePair<TKey,TValue> strut
            dict.Add(new KeyValuePair<int, string>(3, "Three"));

            //Instantiates Dictionary object dict2 using a Dictionary<int, string> class
            Dictionary<int, string> dict1 = new Dictionary<int, string>();

            //It can also be initialized using collecton initializer syntax 
            //with keys and values as shown below.
            IDictionary<int, string> dict2 = new Dictionary<int, string>()
                                            {
                                                {1,"One"},
                                                {2, "Two"},
                                                {3,"Three"}
                                            };

            Console.WriteLine("_1-------------------------------------------------------------");

            //Use foreach or for loop to iterate access all the elements of dictionary. 
            //The dictionary stores key-value pairs. So you can use a KeyValuePair<TKey, TValue> type 
            //or an implicitly typed variable var in foreach loop as shown here.
            foreach (KeyValuePair<int, string> item in dict)
                Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);

            Console.WriteLine("_2-------------------------------------------------------------");

            //Use for loop to access all the elements with the help of LINQ method ElementAt().
            //Use Count property of dictionary to 
            //get the total number of elements in the dictionary.     
            for (int i = 0; i < dict.Count; i++)
            {
                Console.WriteLine("Key: {0}, Value: {1}",
                                                        dict.Keys.ElementAt(i),
                                                        dict[dict.Keys.ElementAt(i)]);


            }

            Console.WriteLine("_3-------------------------------------------------------------");

            //Dictionary can be used like an array to access its individual elements. 
            //Specify key (not index) to get a value from a dictionary using indexer like 
            //an array.
            Console.WriteLine(dict[1]); //returns One
            Console.WriteLine(dict[2]); // returns Two

            Console.WriteLine("_4-------------------------------------------------------------");

            //If you are not sure about the key then use the TryGetValue() method.
            //The TryGetValue() method will return false if it could not found keys 
            //instead of throwing an exception.
            string result;

            if (dict.TryGetValue(4, out result))
                Console.WriteLine(result);
            else
                Console.WriteLine("Could not find the specified key.");

            Console.WriteLine("_5-------------------------------------------------------------");

            //Checks whether a specified key exists in the dictionary or not.
            Console.WriteLine( dict.ContainsKey(1) ); // returns true
            Console.WriteLine( dict.ContainsKey(4) ); // returns false

            //Checks whether a specified KeyValuePair<int, string> exists in the dictionary or not.
            Console.WriteLine(  dict.Contains(new KeyValuePair<int, string>(1, "One")) ); // returns true

            Console.WriteLine("_6-------------------------------------------------------------");

            //Another overload of the Contains() method takes IEqualityComperer as a second 
            //parameter. An instance of IEqualityComparer is used when you want to customize 
            //the equality comparison. For example, consider the following example of 
            //a dictionary that stores a Student objects.
            IDictionary<int, Student> studentDict = new Dictionary<int, Student>()
                    {
                        { 1, new Student(){ StudentID =1, StudentName = "Bill"}},
                        { 2, new Student(){ StudentID =2, StudentName = "Steve"}},
                        { 3, new Student(){ StudentID =3, StudentName = "Ram"}}
                    };

            Student std = new Student() { StudentID = 1, StudentName = "Bill" };

            KeyValuePair<int, Student> elementToFind = new KeyValuePair<int, Student>(1, std);

            bool result3 = studentDict.Contains(elementToFind, new StudentDictionaryComparer()); // returns true

            Console.WriteLine(result3);

            Console.WriteLine("_7-------------------------------------------------------------");

            // Removes the item which has 1 as a key
            dict.Remove(1);

            // Removes item with KeyValuePair<int, string>(2, "Two")
            dict.Remove(new KeyValuePair<int, string>(2, "Two"));

            // Removes nothing because value Two2 is not matching
            dict.Remove(new KeyValuePair<int, string>(2, "Two2"));

            foreach (KeyValuePair<int, string> item in dict)
                Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
        }

    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
    }

    //Uses StudentDictionaryComparer which derives IEqualityComparer to compare Student 
    //objects in the dictionary. The default comparer will only work with primitive data types.
    class StudentDictionaryComparer : IEqualityComparer<KeyValuePair<int, Student>>
    {
        public bool Equals(KeyValuePair<int, Student> x, KeyValuePair<int, Student> y)
        {
            if (x.Key == y.Key && (x.Value.StudentID == y.Value.StudentID) && (x.Value.StudentName == y.Value.StudentName))
                return true;

            return false;
        }

        public int GetHashCode(KeyValuePair<int, Student> obj)
        {
            return obj.Key.GetHashCode();
        }
    }
}
/*
 * Dictionary in C# is same as English dictionary. English dictionary is a collection 
 * of words and their definitions, often listed alphabetically in one or more specific 
 * languages. In the same way, the Dictionary in C# is a collection of Keys and Values, 
 * where key is like word and value is like definition.
 * 
 * Dictionary<TKey, TValue> is a generic collection included in the System.Collection.Generics namespace. 
 * TKey denotes the type of key and TValue is the type of TValue.
 * 
 * A Dictionary can be initialized with a variable of IDictionary<Tkey, TValue> interface as well as with a 
 * Dictionary<TKey, Tvalue> class
 * 
 * Important Properties and Methods of IDictionary
        Count:	    Gets the total number of elements exists in the Dictionary<TKey,TValue>.
        IsReadOnly:	Returns a boolean indicating whether the Dictionary<TKey,TValue> is read-only.
        Item:	    Gets or sets the element with the specified key in the Dictionary<TKey,TValue>.
        Keys:	    Returns collection of keys of Dictionary<TKey,TValue>.
        Values: 	Returns collection of values in Dictionary<TKey,TValue>.
 * Important Properties and Methods of IDictionary
        Add:	        Adds an item to the Dictionary collection.
        Add:	        Add key-value pairs in Dictionary<TKey, TValue> collection.
        Remove:	        Removes the first occurance of specified item from the Dictionary<TKey, TValue>.
        Remove:	        Removes the element with the specified key.
        ContainsKey:	Checks whether the specified key exists in Dictionary<TKey, TValue>.
        ContainsValue:	Checks whether the specified key exists in Dictionary<TKey, TValue>.
        Clear:	        Removes all the elements from Dictionary<TKey, TValue>.
        TryGetValue:	Returns true and assigns the value with specified key, if key does not 
                        exists then return false.
 * 
 * You can use any valid C# data type for keys and values.
 * 
 * It is recommended to program to the interface rather than to the class. 
 * So, use IDictionary<TKey, TValue> type variable to initialize a dictionary object.
 * 
 * Dictionary cannot include duplicate or null keys, where as values can be duplicated or set as null. 
 * Keys must be unique otherwise it will throw a runtime exception.
 * 
 * Check whether a dictionary already stores specified key before adding a key-value pair.
 * 
 * The IDictionary type instance 2 overload for the Add() method. 
 * The first accepts TKey, & TValue as a parameter,
 * & the second accepts a KeyValuePair<TKey, TValue> struct as a parameter.
 * 
 * Indexer takes the key as a parameter. If the specified key does not exist then 
 * a KeyNotFoundException will be thrown.
 * 
 * Dictionary includes various methods to determine whether a dictionary contains specified 
 * elements or keys. Use the ContainsKey() method to check whether a specified key exists 
 * in the dictionary or not.
 * Use the Contains() method to check whether a specified Key and Value pair exists in the 
 * dictionary or not.
 * 
 * Points to Remember :
 *      A Dictionary stores Key-Value pairs where the key must be unique.
 *      Before adding a KeyValuePair into a dictionary, check that the key does not exist 
 *        using the ContainsKey() method.
 *      Use the TryGetValue() method to get the value of a key to avoid possible runtime exceptions.
 *      Use a foreach or for loop to iterate a dictionary.
 *      Use dictionary indexer to access individual item.
 *      Use custom class that derives IEqualityComparer to compare object of custom class with 
 *        Contains() method.
 *        
 */
