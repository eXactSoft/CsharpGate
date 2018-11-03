using System;
using System.Collections;

namespace CollectionsNonGenericQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate a Queue object myQueue
            Queue myQueue = new Queue();
            //Adds values into the Queue. It allows value of any datatype.
            myQueue.Enqueue(3);
            myQueue.Enqueue(2);
            myQueue.Enqueue(1);
            myQueue.Enqueue("Four");

            Console.WriteLine("_1-------------------------------------------------------------");
            //Number of elements in the Queue
            Console.WriteLine("Number of elements in Queue: {0}", myQueue.Count);

            //Iterate a Queue without removing elements of it by converting in to an Array
            foreach (var i in myQueue.ToArray())
                Console.WriteLine(i);

            Console.WriteLine("Number of elements in Queue: {0}", myQueue.Count);

            Console.WriteLine("_2-------------------------------------------------------------");

            //Returns the first item from a queue collection without removing it from the queue.
            Console.WriteLine(myQueue.Peek());
            Console.WriteLine(myQueue.Peek());//Same result 

            Console.WriteLine("_3-------------------------------------------------------------");

            //checks whether an item exists in a queue. It returns true if the specified item exists;
            //otherwise it returns false.
            Console.WriteLine( myQueue.Contains(2) ); // true
            Console.WriteLine( myQueue.Contains(100) ); //false

            Console.WriteLine("_4-------------------------------------------------------------");

            //Number of elements in the Queue
            Console.WriteLine("Number of elements in the Queue: {0}", myQueue.Count);

            //Dequeue(): Removes and returns a first element from a queue
            while (myQueue.Count > 0)
                Console.WriteLine(myQueue.Dequeue());

            Console.WriteLine("Number of elements in the Queue: {0}", myQueue.Count);

            Console.WriteLine("_5-------------------------------------------------------------");

            myQueue.Enqueue(5);

            Console.WriteLine("Number of elements in the Queue: {0}", myQueue.Count);

            //Removes all the items from a queue.
            myQueue.Clear();

            Console.WriteLine("Number of elements in the Queue: {0}", myQueue.Count);

        }
    }
}
/*
 *C# includes a Queue collection class in the System.Collection namespace. 
 * Queue stores the elements in FIFO style (First In First Out), exactly opposite of the 
 * Stack collection. It contains the elements in the order they were added.
 * 
 * Queue collection allows multiple null and duplicate values. Use the Enqueue() method 
 * to add values and the Dequeue() method to retrieve the values from the Queue. 
 * 
 * Important Property of Queue:
        Count:	Returns the total count of elements in the Queue.
 * Important Methods of Queue:
        Enqueue:	Adds an item into the queue.
        Dequeue:	Removes and returns an item from the beginning of the queue.
        Peek:	    Returns an first item from the queue
        Contains:	Checks whether an item is in the queue or not
        Clear:	    Removes all the items from the queue.
        TrimToSize:	Sets the capacity of the queue to the actual number of items in the queue.
 * 
 * Queue is a non-generic collection. So you can add elements of any datatype into a queue using 
 * the Enqueue() method.
 * 
 * Dequeue() method is used to retrieve the top most element in a queue collection.
 * Dequeue() removes and returns a first element from a queue because the queue stores
 * elements in FIFO order. Calling Dequeue() method on empty queue will throw InvalidOperation 
 * exception. So always check that the total count of a queue is greater than zero before 
 * calling the Dequeue() method on a queue.
 * 
 * The Peek() method always returns the first item from a queue collection without 
 * removing it from the queue. Calling Peek() and Dequeue() methods on an empty queue 
 * collection will throw a run time exception "InvalidOperationException".
 * 
 * Points to Remember :
 *      The Queue stores the values in FIFO (First in First out) style. The element 
 *        which is added first will come out First.
 *      Use the Enqueue() method to add elements into Queue
 *      The Dequeue() method returns and removes elements from the beginning 
 *         of the Queue. Calling the Dequeue() method on an empty queue will throw an exception.
 *      The Peek() method always returns top most element.
 */
