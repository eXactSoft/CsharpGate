using System;
using System.Collections;

namespace CollectionsNonGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
/*
 * For many applications, you want to create and manage groups of related objects. 
 * There are two ways to group objects: by creating arrays of objects, and by creating 
 * collections of objects.
 * Arrays are most useful for creating and working with a fixed number of strongly-typed 
 * objects. For information about arrays, see Arrays.
 * Collections provide a more flexible way to work with groups of objects. Unlike arrays, 
 * the group of objects you work with can grow and shrink dynamically as the needs of 
 * the application change. For some collections, you can assign a key to any object that 
 * you put into the collection so that you can quickly retrieve the object by using the key.
 * A collection is a class, so you must declare an instance of the class before you can add 
 * elements to that collection.
 * 
 * 
 * There are 6 kinds of collections as follows:-
 * 1)-Non-Generic collection: at System.Collections namespace contains interfaces 
 *   and classes that define various collections of objects, such as lists, queues, 
 *   bit arrays, hash tables and dictionaries.
 *  
 * 2)-Generic collection: at System.Collections.Generic namespace contains interfaces 
 *   and classes that define generic collections, which allow users to create strongly typed 
 *   collections that provide better type safety and performance than non-generic strongly 
 *   typed collections.
 *   Many of the generic collection types are direct analogs of nongeneric types. 
 *   Dictionary<TKey,TValue> is a generic version of Hashtable; it uses the generic 
 *   structure KeyValuePair<TKey,TValue> for enumeration instead of DictionaryEntry. 
 *   List<T> is a generic version of ArrayList. There are generic Queue<T> and Stack<T> 
 *   classes that correspond to the nongeneric versions. 
 *   There are generic and nongeneric versions of SortedList<TKey,TValue>. 
 *   Both versions are hybrids of a dictionary and a list. The SortedDictionary<TKey,TValue> 
 *   generic class is a pure dictionary and has no nongeneric counterpart. 
 *   The LinkedList<T> generic class is a true linked list and has no nongeneric counterpart.
 * 
 * 3)-Concurrent collection: at System.Collections.Concurrent namespace provides several 
 *   thread-safe collection classes that should be used in place of the corresponding types 
 *   in the System.Collections and System.Collections.Generic namespaces whenever multiple 
 *   threads are accessing the collection concurrently.
 *   However, access to elements of a collection object through extension methods or through 
 *   explicit interface implementations are not guaranteed to be thread-safe and may need to 
 *   be synchronized by the caller.
 *   In the .NET Framework 4 or newer, the collections in the System.Collections.Concurrent 
 *   namespace provide efficient thread-safe operations for accessing collection items from 
 *   multiple threads.
 *   The classes in the System.Collections.Concurrent namespace should be used instead of 
 *   the corresponding types in the System.Collections.Generic and System.Collections 
 *   namespaces whenever multiple threads are accessing the collection concurrently. 
 *   Some classes included in the System.Collections.Concurrent namespace are 
 *   BlockingCollection<T>, ConcurrentDictionary<TKey,TValue>, ConcurrentQueue<T>, 
 *   and ConcurrentStack<T>.
 *  
 * 4)-Immutable collection at System.Collections.Immutable contains interfaces and classes that 
 *   define immutable collections. These classes are supported starting with .NET 
 *   Framework 4.5. Use them to build apps that target the desktop, Windows Store, 
 *   Portable Class Library and Windows Phone 8.
 *   With immutable collections, you can:
 *   Share a collection in a way that its consumer can be assured that the collection never 
 *   changes.
 *   Provide implicit thread safety in multi-threaded applications (no locks required to 
 *   access collections).
 *   Follow functional programming practices.
 *   Modify a collection during enumeration, while ensuring that the original collection 
 *   does not change.
 *   The immutable collection classes are available with .NET Core, however they're 
 *   not part of the core class library distributed with the .NET Framework. They're 
 *   available starting with the .NET Framework 4.5 via NuGet.
 * 
 * 5)-Specialized collection at System.Collections.Specialized namespace contains specialized 
 *   and strongly-typed collections; for example, a linked list dictionary, a bit vector, 
 *   and collections that contain only strings.
 *   Specialized collections are collections with highly specific purposes. 
 *   NameValueCollection is based on NameObjectCollectionBase; however, NameValueCollection 
 *   accepts multiple values per key, whereas NameObjectCollectionBase accepts only one 
 *   value per key.
 *   Some strongly typed collections in the System.Collections.Specialized namespace are 
 *   StringCollection and StringDictionary, both of which contain values that are exclusively 
 *   strings.
 *   The CollectionsUtil class creates instances of case-insensitive collections.
 *   Some collections transform. For example, the HybridDictionary class starts as 
 *   a ListDictionary and becomes a Hashtable when it becomes large. 
 *   The KeyedCollection<TKey,TItem> is a list but it also creates a lookup dictionary 
 *   when the number of elements reaches a specified threshold.
 * 
 * 6)-ObjectModel collection at System.Collections.ObjectModel namespace contains classes 
 *   that can be used as collections in the object model of a reusable library. 
 *   Use these classes when properties or methods return collections.
 *   
 * 
 * There are two main types of collections available in C#: non-generic collections and generic 
 * collections. Non-generic collections is concerned in this project.
 * 
 * Non-generic collections store items as Object, require casting, and most are not supported 
 * for Windows Store app development. However, you may see non-generic collections in older code.
 * 
 * Non-generic collection could contain elements of multiple data type.
 * 
 * All Non-generic collections are implements one of the following interfaces: the ICollection interface
 * , the IList interface, or the IDictionary interface.
 * 
 * Collections based on the IList interface (such as Array, or ArrayList)
 * 
 * Collections based on the ICollection interface (such as Queue, or Stack)
 * 
 * Collections based on the  IDictionary interface (such as the Hashtable or SortedList classes)
 * 
 * The IList interface and the IDictionary interface are both derived from the ICollection 
 * interface; therefore, all collections are based on the ICollection interface either directly 
 * or indirectly.
 * The ICollection interface is the base interface for classes in the System.Collections namespace.
 * ICollection Interface: Defines size, enumerators, and synchronization methods for all nongeneric collections.
 *                        Methods: CopyTo(Array, Int32).
 *                        Properties: Count, IsSynchronized, & SyncRoot.
 * ICollection implements System.Collections.IEnumerable.
 * IEnumerable  Interface exposes an enumerator, which supports a simple iteration over a non-generic collection.
 * IEnumerable  Interface has only one method GetEnumerator() that returns IEnumerator Interface.
 * IEnumerator Interface: Supports a simple iteration over a non-generic collection.
 * IEnumerator Interface has 2 methods:
 *      MoveNext(): Advances the enumerator to the next element of the collection.
 *      Reset()	  :Sets the enumerator to its initial position, which is before 
 *                  the first element in the collection.
 *  
 * Every collection class implements the IEnumerable interface so values from the collection 
 * can be accessed using a foreach loop.
 * 
 * The Non-Generic collections can store any type of items. For example, 
 * ArrayList can store items of different data types:
 *          ArrayList arList = new ArrayList();
 *          arList.Add(1);
 *          arList.Add("Two");
 *          arList.Add(true);
 *          arList.Add(100.45);
 *          arList.Add(DateTime.Now);
 * The limitation of these collections is that while retrieving items, you need to cast 
 * into the appropriate data type, otherwise the program will throw a runtime exception. 
 * It also affects on performance, because of boxing and unboxing.
 * 
 * The System.Collections namespace includes following non-generic collections:
 *  ArrayList:	ArrayList stores objects of any type like an array. However, there is no need 
 *              to specify the size of the ArrayList like with an array as it grows automatically.
 *  SortedList:	SortedList stores key and value pairs. It automatically arranges elements in 
 *              ascending order of key by default. C# includes both, generic and non-generic 
 *              SortedList collection.
 *              
 *  Stack:	    Stack stores the values in LIFO style (Last In First Out). It provides a Push() 
 *              method to add a value and Pop() & Peek() methods to retrieve values. C# includes 
 *              both, generic and non-generic Stack.
 *              
 *  Queue:	    Queue stores the values in FIFO style (First In First Out). It keeps the order in 
 *              which the values were added. It provides an Enqueue() method to add values and 
 *              a Dequeue() method to retrieve values from the collection. C# includes generic 
 *              and non-generic Queue.
 *              
 *  Hashtable:	Hashtable stores key and value pairs. It retrieves the values by comparing 
 *              the hash value of the keys.
 *              
 *  BitArray:	BitArray manages a compact array of bit values, which are represented as Booleans, 
 *              where true indicates that the bit is on (1) and false indicates the bit 
 *              is off (0).
 * 
 * The classes in the System.Collections namespace do not store elements as specifically typed objects, 
 * but as objects of type Object.
 * 
 * Collections can vary, depending on how the elements are stored, how they are sorted, 
 * how searches are performed, and how comparisons are made. 
 * The Queue class provides first-in-first-out lists, 
 * while the Stack class provides last-in-first-out lists. 
 * The SortedList class provides sorted versions of the Hashtable class. 
 * The elements of a Hashtable are accessible only by the key of the element, 
 * but the elements of a SortedList are accessible either by the key or by the index of the element. 
 * The indexes in all collections are zero-based, except Array, which allows arrays that are not zero-based.
 * 
 * The LINQ to Objects feature allows you to use LINQ queries to access in-memory objects 
 * as long as the object type implements IEnumerable or IEnumerable<T>. LINQ queries provide 
 * a common pattern for accessing data; are typically more concise and readable than standard 
 * foreach loops; and provide filtering, ordering and grouping capabilities. LINQ queries can 
 * also improve performance. 
 * 
 * PLINQ provides a parallel implementation of LINQ to Objects that can offer faster query execution 
 * in many scenarios.
 * 
 * Common collection features
 * All collections provide methods for adding, removing or finding items in the collection. 
 * In addition, all collections that directly or indirectly implement the 
 * ICollection interface or the ICollection<T> interface share these features:
        1)-The ability to enumerate the collection:
            .NET Framework collections either implement System.Collections.IEnumerable 
            or System.Collections.Generic.IEnumerable<T> to enable the collection to be 
            iterated through. An enumerator can be thought of as a movable pointer to any 
            element in the collection. The foreach, in statement and the For Each...Next 
            Statement use the enumerator exposed by the GetEnumerator method and hide 
            the complexity of manipulating the enumerator. In addition, any collection 
            that implements System.Collections.Generic.IEnumerable<T> is considered 
            a queryable type and can be queried with LINQ. LINQ queries provide a common 
            pattern for accessing data. They are typically more concise and readable than 
            standard foreach loops, and provide filtering, ordering and grouping capabilities. 
            LINQ queries can also improve performance. For more information, see LINQ to Objects, 
            Parallel LINQ (PLINQ) and Introduction to LINQ Queries (C#).

        2)-The ability to copy the collection contents to an array:
            All collections can be copied to an array using the CopyTo method; however
            , the order of the elements in the new array is based on the sequence in which 
            the enumerator returns them. The resulting array is always one-dimensional with 
            a lower bound of zero.

* In addition, many collection classes contain the following features:

        3)-Capacity and Count properties:
            The capacity of a collection is the number of elements it can contain. 
            The count of a collection is the number of elements it actually contains. 
            Some collections hide the capacity or the count or both.
            Most collections automatically expand in capacity when the current capacity 
            is reached. The memory is reallocated, and the elements are copied from the 
            old collection to the new one. This reduces the code required to use the 
            collection; however, the performance of the collection might be negatively 
            affected. For example, for List<T>, If Count is less than Capacity, adding 
            an item is an O(1) operation. If the capacity needs to be increased to 
            accommodate the new element, adding an item becomes an O(n) operation, 
            where n is Count. The best way to avoid poor performance caused by multiple 
            reallocations is to set the initial capacity to be the estimated size of the 
            collection.
            A BitArray is a special case; its capacity is the same as its length, 
            which is the same as its count.

        4)-A consistent lower bound
            The lower bound of a collection is the index of its first element. 
            All indexed collections in the System.Collections namespaces have a lower 
            bound of zero, meaning they are 0-indexed. Array has a lower bound of zero 
            by default, but a different lower bound can be defined when creating an instance 
            of the Array class using Array.CreateInstance.

        5)-Synchronization for access from multiple threads (System.Collections classes only).
            Non-generic collection types in the System.Collections namespace provide some 
            thread safety with synchronization; typically exposed through the SyncRoot and 
            IsSynchronized members. These collections are not thread-safe by default. 
            If you require scalable and efficient multi-threaded access to a collection, 
            use one of the classes in the System.Collections.Concurrent namespace or consider 
            using an immutable collection. For more information, see Thread-Safe Collections.

 *
 * Choosing a collection
 * In general, you should use generic collections. The following describes some common collection 
 * scenarios and the collection classes you can use for those scenarios. The following will help you 
 * choose the generic collection that works the best for your task:
 * 
 * I want to…	        Generic collection options	    Non-generic collection options	    Thread-safe or immutable collection options
 * 
 * Store items as       Dictionary<TKey,TValue>	        Hashtable                           ConcurrentDictionary<TKey,TValue>
 * key/value pairs                                                                          , ReadOnlyDictionary<TKey,TValue>
 * for quick look-up                                                                        , ImmutableDictionary<TKey,TValue>
 * by key
 * 
 * Access items by      List<T>	                        Array                               ImmutableList<T>
 * index	                                            , ArrayList                         , ImmutableArray
 * 
 * Use items first-     Queue<T>                        Queue                               ConcurrentQueue<T>
 * in-first-out (FIFO)                                                                      , ImmutableQueue<T>
 * 
 * Use data Last-In     Stack<T>                        Stack                               ConcurrentStack<T>
 * -First-Out (LIFO)                                                                        ,ImmutableStack<T>
 * 
 * Access items         LinkedList<T>	                No recommendation	                No recommendation
 * sequentially	
 * 
 * Receive              ObservableCollection<T>	        No recommendation	                No recommendation
 * notifications 
 * when items are 
 * removed 
 * or added to the 
 * collection. (implements 
 * INotifyPropertyChanged 
 * and 
 * INotifyCollectionChanged)
 * 
 * A sorted collection	SortedList<TKey,TValue>	       SortedList	                        ImmutableSortedDictionary<TKey,TValue>
 *                                                                                          , ImmutableSortedSet<T>
 *
 * A set for            HashSet<T>                     No recommendation	                ImmutableHashSet<T>
 * mathematical         , SortedSet<T>                                                      , ImmutableSortedSet<T>
 * functions
 ****************************************************************************************************
 * 
 * Selecting a Collection Class
 *  Be sure to choose your collection class carefully. Using the wrong type can restrict 
 *  your use of the collection. In general, avoid using the types in the System.Collections 
 *  namespace unless you are specifically targeting .NET Framework version 1.1. The generic 
 *  and concurrent versions of the collections are to be preferred because of their greater 
 *  type safety and other improvements.
 *  
 *  Consider the following questions:
 *   Do you need a sequential list where the element is typically discarded after its 
 *   value is retrieved?
 *      If yes, consider using the Queue class or the Queue<T> generic class if you need 
 *      first-in, first-out (FIFO) behavior. Consider using the Stack class or the Stack<T> 
 *      generic class if you need last-in, first-out (LIFO) behavior. For safe access from 
 *      multiple threads, use the concurrent versions ConcurrentQueue<T> and ConcurrentStack<T>.
 *      If not, consider using the other collections.
 *  Do you need to access the elements in a certain order, such as FIFO, LIFO, or random?
 *      The Queue class and the Queue<T> or ConcurrentQueue<T> generic class offer FIFO access. 
 *      The Stack class and the Stack<T> or ConcurrentStack<T> generic class offer LIFO access. 
 *      The LinkedList<T> generic class allows sequential access either from the head to 
 *      the tail, or from the tail to the head.
 *  Do you need to access each element by index?
 *      The ArrayList and StringCollection classes and the List<T> generic class offer 
 *      access to their elements by the zero-based index of the element.
 *      The Hashtable, SortedList, ListDictionary, and StringDictionary classes, and 
 *      the Dictionary<TKey,TValue> and SortedDictionary<TKey,TValue> generic classes 
 *      offer access to their elements by the key of the element.
 *      The NameObjectCollectionBase and NameValueCollection classes, and the KeyedCollection<TKey
 *      ,TItem> and SortedList<TKey,TValue> generic classes offer access to their elements by either 
 *      the zero-based index or the key of the element.
 *  Will each element contain one value, a combination of one key and one value, or 
 *  a combination of one key and multiple values?
 *      One value: Use any of the collections based on the IList interface or the IList<T> 
 *      generic interface.
 *      One key and one value: Use any of the collections based on the IDictionary 
 *      interface or the IDictionary<TKey,TValue> generic interface.
 *      One value with embedded key: Use the KeyedCollection<TKey,TItem> generic class.
 *      One key and multiple values: Use the NameValueCollection class.
 *  Do you need to sort the elements differently from how they were entered?
 *      The Hashtable class sorts its elements by their hash codes.
 *      The SortedList class and the SortedDictionary<TKey,TValue> and SortedList<TKey,TValue> 
 *      generic classes sort their elements by the key, based on implementations of the IComparer 
 *      interface and the IComparer<T> generic interface.
 *      ArrayList provides a Sort method that takes an IComparer implementation as 
 *      a parameter. Its generic counterpart, the List<T> generic class, provides a Sort 
 *      method that takes an implementation of the IComparer<T> generic interface as 
 *      a parameter.
 *  Do you need fast searches and retrieval of information?
 *      ListDictionary is faster than Hashtable for small collections (10 items or fewer). 
 *      The Dictionary<TKey,TValue> generic class provides faster lookup than the 
 *      SortedDictionary<TKey,TValue> generic class. The multi-threaded implementation 
 *      is ConcurrentDictionary<TKey,TValue>. ConcurrentBag<T> provides fast multi-threaded 
 *      insertion for unordered data. For more information about both multi-threaded types
 *      , see When to Use a Thread-Safe Collection.
 *  Do you need collections that accept only strings?
 *      StringCollection (based on IList) and StringDictionary (based on IDictionary) are 
 *      in the System.Collections.Specialized namespace.
 *      In addition, you can use any of the generic collection classes in the 
 *      System.Collections.Generic namespace as strongly typed string collections by 
 *      specifying the String class for their generic type arguments.
 * 
 */

