using System;
using System.Collections.Generic;
using System.Collections;

namespace IEnumerableIEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> years = new List<int>() { 1991, 1992, 1993, 2001, 2002, 2003};

            Console.WriteLine("_1-------------------------------------------------------------");
            IEnumerable<int> ienumerable = (IEnumerable<int>)years;

            //Access the years List collection elements using IEnumerable
            foreach (int i in ienumerable)
                Console.WriteLine(i);

            Console.WriteLine("_2-------------------------------------------------------------");
            IEnumerator<int> ienumerator = years.GetEnumerator();

            //Access the years List collection elements using IEnumerator
            while (ienumerator.MoveNext() )
                Console.WriteLine( ienumerator.Current.ToString() );

            Console.WriteLine("_3-------------------------------------------------------------");
            //Position of IEnumerable is rest to initial position auto at each foreach loop call
            IterateThroughAll(ienumerable);

            Console.WriteLine("_4-------------------------------------------------------------");
            //Position of IEnumerator is maintained to last position and no auto reset is c/o at 
            //each MoveNext() method call
            IterateThroughAll(ienumerator);

            Console.WriteLine("_5-------------------------------------------------------------");
            Person[] peopleArray = new Person[3]
            {
            new Person("John", "Smith"),
            new Person("Jim", "Johnson"),
            new Person("Sue", "Rabon"),
            };

            //Iterate through custom class that implements IEnumerable
            People peopleList = new People(peopleArray);
            foreach (Person p in peopleList)
                Console.WriteLine(p.firstName + " " + p.lastName);

            Console.WriteLine("_6-------------------------------------------------------------");
            DynamicArray<int> array = new DynamicArray<int>();
            array.Append(3);
            array.Append(2);
            array.Append(5);
            array.Append(1);
            array.Append(4);

            //Iterate using MoveNext() method
            IEnumerator<int> enumerator = array.GetForwardEnumerator();
            while (enumerator.MoveNext())
                Console.Write("{0,3}", enumerator.Current);
            Console.WriteLine("\n~~~~~~~~~~~~~~");

            //Iterate using foreach loop
            foreach (int value in array.GetForwardSequence())
                Console.Write("{0,3}", value);

            Console.WriteLine();

            Console.WriteLine("_7-------------------------------------------------------------");
            Animal animal = new Animal(new string[] { "cat", "dog", "bird" });

            // The foreach-loop calls the generic GetEnumerator method.
            // ... It then uses the List's Enumerator.
            foreach (string element in animal)
                Console.WriteLine(element);
        }


        //Iterate through all values using IEnumerable
        static void IterateThroughAll(IEnumerable<int> ienumerable)
        {
            foreach (int i in ienumerable)
            {
                if (i < 2000)
                    Console.WriteLine(i);
                else
                {
                    IterateThrough20(ienumerable);
                    break;
                }
            }
        }

        //Iterate through values from 2000 to 2999 using IEnumerable
        static void IterateThrough20(IEnumerable<int> ienumerable)
        {
            Console.WriteLine("~~~~~~~~~~~~~~");
            foreach (int i in ienumerable)
                Console.WriteLine(i);
        }

        //Iterate through all values using IEnumerator
        static void IterateThroughAll(IEnumerator<int> ienumerator)
        {
            //Sets the enumerator to its initial position, which is before the 1st element 
            //in the collection
            ienumerator.Reset();

            while (ienumerator.MoveNext())
            {

                if (Convert.ToInt16(ienumerator.Current.ToString()) < 2000)
                    Console.WriteLine(ienumerator.Current.ToString());
                else
                    IterateThrough20(ienumerator);
            }
        }

        //Iterate through values from 2000 to 2999 using IEnumerator
        static void IterateThrough20(IEnumerator<int> ienumerator)
        {
            Console.WriteLine("~~~~~~~~~~~~~~");
            do
            {
                Console.WriteLine(ienumerator.Current.ToString());
            }
            while (ienumerator.MoveNext());
        }
    }

    //***** The follwoing to implement IEnumerable for a custom class *****//

    // Simple business object.
    public class Person
    {
        public Person(string fName, string lName)
        {
            this.firstName = fName;
            this.lastName = lName;
        }

        public string firstName;
        public string lastName;
    }

    // Collection of Person objects. This class
    // implements IEnumerable so that it can be used
    // with ForEach syntax.
    public class People : IEnumerable
    {
        private Person[] _people;
        public People(Person[] pArray)
        {
            _people = new Person[pArray.Length];

            for (int i = 0; i < pArray.Length; i++)
            {
                _people[i] = pArray[i];
            }
        }

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public PeopleEnum GetEnumerator()
        {
            return new PeopleEnum(_people);
        }
    }

    // When you implement IEnumerable, you must also implement IEnumerator.
    public class PeopleEnum : IEnumerator
    {
        public Person[] _people;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public PeopleEnum(Person[] list)
        {
            _people = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _people.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Person Current
        {
            get
            {
                try
                {
                    return _people[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

    //***** The follwoing to implement IEnumerator<T> for a custom class *****//

    class ArrayEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] array;
        private readonly int count;
        private int pos;

        public ArrayEnumerator(T[] array, int count)
        {
            this.array = array;
            this.count = count;
            this.pos = -1;  // Invalid position
        }

        public T Current
        {
            get
            {
                if (this.pos < 0 || this.pos >= count)
                    throw new InvalidOperationException();
                return this.array[this.pos];
            }
        }

        public void Dispose()
        {
        }

        object System.Collections.IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        public bool MoveNext()
        {
            this.pos++;
            return this.pos < this.count;
        }

        public void Reset()
        {
            this.pos = -1;
        }
    }

    class DynamicArray<T>
    {
        private T[] array;
        private int count;

        public DynamicArray()
        {
            this.array = new T[0];
        }

        public void Append(T value)
        {
            this.ResizeToFit(this.count + 1);
            this.array[this.count] = value;
            this.count++;
        }

        private void ResizeToFit(int desiredCount)
        {

            int newSize = this.array.Length;
            while (newSize < desiredCount)
                newSize = Math.Max(1, newSize * 2);

            System.Array.Resize<T>(ref this.array, newSize);

        }

        //Returning IEnumerator (Cannot be used with foreach)
        public IEnumerator<T> GetForwardEnumerator()
        {
            return new ArrayEnumerator<T>(this.array, this.count);
        }

        //Returning IEnumerable instead. So use yield return/yield break keywords
        public IEnumerable<T> GetForwardSequence()
        {
            for (int i = 0; i < this.count; i++)
                yield return this.array[i];
        }

    }

    //***** The follwoing very simple implementation of IEnumerable<T> for a custom class *****//

    class Animal : IEnumerable<string>
    {
        List<string> _elements;

        public Animal(string[] array)
        {
            this._elements = new List<string>(array);
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            Console.WriteLine("HERE");
            return this._elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._elements.GetEnumerator();
        }
    }
}
/*
 * IEnumerable Interface: Exposes an enumerator, which supports a simple iteration over a 
 *                        non-generic collection.
 * 
 * IEnumerable is the base interface for all non-generic collections that can be enumerated. 
 * IEnumerable contains a single method, GetEnumerator, which returns an IEnumerator. 
 * IEnumerator provides the ability to iterate through the collection by exposing a Current 
 * property and MoveNext and Reset methods.
 * 
 * It is a best practice to implement IEnumerable and IEnumerator on your collection classes 
 * to enable the foreach syntax, however implementing IEnumerable is not required. 
 * If your collection does not implement IEnumerable, you must still follow 
 * the iterator pattern to support this syntax by providing a GetEnumerator method 
 * that returns an interface, class or struct. 
 * When developing with C# you must provide a class that contains a Current property, 
 * and MoveNext and Reset methods as described by IEnumerator, but the class does not 
 * have to implement IEnumerator.
 * 
 * IEnumerable<T> Interface: Exposes the enumerator, which supports a simple iteration over a collection 
 *                           of a specified type.
 *                           
 * IEnumerable<T> is the base interface for collections in the System.Collections.
 * Generic namespace such as List<T>, Dictionary<TKey,TValue>, and Stack<T> and other 
 * generic collections such as ObservableCollection<T> and ConcurrentStack<T>. 
 * Collections that implement IEnumerable<T> can be enumerated by using the foreach statement.
 * 
 * IEnumerable<T> contains a single method that you must implement when implementing this 
 * interface; GetEnumerator, which returns an IEnumerator<T> object. The returned IEnumerator<T> 
 * provides the ability to iterate through the collection by exposing a Current property.
 * 
 * IEnumerable<T> is included for parity with non-generic collections; implementing IEnumerable<T> 
 * allows a generic collection to be passed to a method that expects an IEnumerable object.
 * 
 * GetEnumerator(): Returns an enumerator that iterates through the collection.
 * 
 * IEnumerator Interface: Supports a simple iteration over a non-generic collection.
 * 
 * IEnumerator is the base interface for all non-generic enumerators.
 * 
 * The foreach statement of the C# language hides the complexity of the enumerators. 
 * Therefore, using foreach is recommended instead of directly manipulating the enumerator.
 * 
 * Enumerators can be used to read the data in the collection, but they cannot be used to 
 * modify the underlying collection.
 * 
 * The Reset method is provided for COM interoperability and does not need to be fully 
 * implemented; instead, the implementer can throw a NotSupportedException.
 * 
 * Initially, the enumerator is positioned before the first element in the collection. 
 * You must call the MoveNext method to advance the enumerator to the first element of 
 * the collection before reading the value of Current; otherwise, Current is undefined.
 * 
 * Current returns the same object until either MoveNext or Reset is called. 
 * MoveNext sets Current to the next element.
 * 
 * If MoveNext passes the end of the collection, the enumerator is positioned after the 
 * last element in the collection and MoveNext returns false. When the enumerator is at 
 * this position, subsequent calls to MoveNext also return false. If the last call 
 * to MoveNext returned false, Current is undefined.
 * 
 * To set Current to the first element of the collection again, you can call Reset, 
 * if it’s implemented, followed by MoveNext. If Reset is not implemented, 
 * you must create a new enumerator instance to return to the first element of the collection.
 * 
 * If changes are made to the collection, such as adding, modifying, or deleting elements, 
 * the behavior of the enumerator is undefined.
 * 
 * The enumerator does not have exclusive access to the collection; 
 * therefore, enumerating through a collection is intrinsically not a thread-safe procedure. 
 * Even when a collection is synchronized, other threads can still modify the collection, 
 * which causes the enumerator to throw an exception. To guarantee thread safety during 
 * enumeration, you can either lock the collection during the entire enumeration or catch 
 * the exceptions resulting from changes made by other threads.
 * 
 * IEnumerator<T> Interface: Supports a simple iteration over a generic collection.
 * 
 * Implementing IEnumerator<T> interface requires implementing the nongeneric IEnumerator 
 * interface. The MoveNext() and Reset() methods do not depend on T, and appear only on 
 * the nongeneric interface. The Current property appears on both interfaces, and has 
 * different return types. Implement the nongeneric Current property as an explicit interface 
 * implementation. This allows any consumer of the nongeneric interface to consume the generic 
 * interface.
 * 
 * In addition, IEnumerator<T> implements IDisposable, which requires you to implement the 
 * Dispose() method. This enables you to close database connections or release file handles 
 * or similar operations when using other resources. If there are no additional resources to 
 * dispose of, provide an empty Dispose() implementation.
 * 
 * IEnumerable internally uses IEnumerator but IEnumerable makes syntax shorter & more neat code.
 * 
 * https://www.youtube.com/watch?v=jd3yUjGc9M0
 * As you loop through IEnumerable with foreach loop ==> 
 * the foreach loop resets the IEnumerable position automatically to the initial position 
 * each time you iterate.
 * While as you iterate through IEnumerator with MoveNext() method the position is maintained
 * with the new iteration loop, because nothing automatically changes the position of IEnumerator, 
 * and if you want the initial position of the IEnumerator you must use Reset() method.
 * So, the technique used to iterate through IEnumerable rests the position automatically 
 * each time you iterate,
 * while The technique used to iterate through IEnumerator begins the iteration from the 
 * last IEnumerator position and no automatic reset is carried out in IEnumerator iteration. 
 * 
 * So usually use IEnumerable as its syntax is shorter, but if you want not to reset the position
 * then you could not use IEnumerable, but use IEnumerator instead even that
 * the IEnumerator is more complex to implement.
 * 
 * https://programmingwithmosh.com/csharp/ienumerable-and-ienumerator/
 * The beauty of IEnumerable and IEnumerator is that we’ll end up with a simple and consistent mechanism to 
 * iterate any objects, irrespective of their internal structure. 
 * Any changes in the internals of our enumerable classes will be protected from leaking 
 * outside. So the client code will not be affected, and this means: more loosely-coupled software.
 * IEnumerable is the implementation of the iterator pattern and 
 * is used to give the ability to iterate a class without knowing its internal structure.
 * 
 * The foreach statement executes a statement or a block of statements for each element in 
 * an instance of the type that implements the System.Collections.IEnumerable or 
 * System.Collections.Generic.IEnumerable<T> interface. 
 * The foreach statement is not limited to those types and can be applied to an instance of 
 * any type that satisfies the following conditions:
 *      has the public parameterless GetEnumerator method whose return type is either class, 
 *      struct, or interface type,
 *      & the return type of the GetEnumerator method has the public Current property 
 *      and the public parameterless MoveNext method whose return type is Boolean.
 *      
 * Use IEnumerable & IEnumerator to protect the elements of a collection from Clear, or Remove
 * , just permits the iteration.
 * 
 * IEnumerable is an interface that defines one method GetEnumerator which returns an 
 * IEnumerator interface, this allows readonly access to a collection then collection that 
 * implements IEnumerable can be used with a foreach loop.
 * 
 * Note that: When a class implements IEnumerable<T>, it is stating 
 * "I am a collection of things that can be enumerated."
 * & When a class implements IEnumerator<T>, it is stating 
 * "I am a thing that enumerates over something."
 * 
 * If you use a narrower interface type such as IEnumerable instead of IList, you protect 
 * your code against breaking changes. If you use IEnumerable, the caller of your method can 
 * provide any object which implements the IEnumerable interface. 
 * These are nearly all collection types of the base class library and in addition many 
 * custom defined types. The caller code can be changed in the future and your code won’t 
 * break that easily as it would if you had used ICollection or even worse IList.
 * 
 * If you use a wider interface type such as IList, you are more in danger of breaking code 
 * changes. If someone wants to call your method with a custom defined object which only 
 * implements IEnumerable, it simply won’t work and will result in a compilation error.
 * 
 * Generally you should always use that type that provides a contract for only the methods 
 * you really use.
 * 
 * http://www.claudiobernasconi.ch/2013/07/22/when-to-use-ienumerable-icollection-ilist-and-list/
 * The following  gives you an overview of how you can decide which type you should depend on:
 *      Interface	                    Scenario
 *      
 *      IEnumerable, IEnumerable<T>	    The only thing you want is to iterate over the elements in a collection. 
 *                                      You only need read-only access to that collection.
 *                                      
 *      ICollection, ICollection<T>	    You want to modify the collection or you care about its size.
 *      
 *      IList, IList<T>	                You want to modify the collection and you care about the ordering and / or 
 *                                      positioning of the elements in the collection.
 *                                      
 *      List, List<T>	                Since in object oriented design you want to depend on abstractions instead 
 *                                      of implementations, you should avoid to have a member of your own implementations 
 *                                      with the concrete type List/List<T>.
 * 
 */
