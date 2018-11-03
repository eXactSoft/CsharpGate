using System;
using System.Collections;

namespace CollectionsNonGenericStack
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate a stack object myStack
            Stack myStack = new Stack();
            //Adds values into the Stack. It allows value of any datatype.
            myStack.Push("Hello!!");
            myStack.Push(null);
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            myStack.Push(5);

            Console.WriteLine("_1-------------------------------------------------------------");
            //Use a foreach statement to iterate the Stack collection and get all the elements in LIFO style.
            foreach (var itm in myStack)
                Console.WriteLine(itm);

            Console.WriteLine("_2-------------------------------------------------------------");
            //Returns the last (top-most) value from the stack.
            Console.WriteLine(myStack.Peek());
            Console.WriteLine(myStack.Peek());//same result

            Console.WriteLine("_3-------------------------------------------------------------");
            //checks whether the specified item exists in a Stack collection or not. 
            //It returns true if it exists; otherwise it returns false.
            Console.WriteLine(myStack.Contains(2)); // returns true
            Console.WriteLine(myStack.Contains(10)); // returns false

            Console.WriteLine("_4-------------------------------------------------------------");
            //Returns the Number of elements in Stack
            Console.WriteLine("Number of elements in Stack: {0}", myStack.Count);

            //Removes and returns the value that was added last to the Stack.
            while (myStack.Count > 0)
                Console.WriteLine(myStack.Pop());

            Console.WriteLine("Number of elements in Stack: {0}", myStack.Count);

            Console.WriteLine("_5-------------------------------------------------------------");
            //Removes all the values from the stack.
            myStack.Clear(); // removes all elements

            Console.WriteLine("Number of elements in Stack: {0}", myStack.Count);
        }
    }
}
/*
 * C# includes a special type of collection which stores elements in LIFO style(Last In First Out). 
 * C# includes a generic and non-generic Stack. Here, you are going to learn about the 
 * non-generic stack.
 * Stack allows null value and also duplicate values. It provides a Push() method to add 
 * a value and Pop() or Peek() methods to retrieve values.
 * 
 * Important Property of Stack:
        Count:	    Returns the total count of elements in the Stack.
 * Important Methods of Stack:
        Push:	    Inserts an item at the top of the stack.
        Peek:	    Returns the top item from the stack.
        Pop:	    Removes and returns items from the top of the stack.
        Contains:   Checks whether an item exists in the stack or not.
        Clear:	    Removes all items from the stack.
 *
 * The Peek() method returns the last (top-most) value from the stack. 
 * Calling Peek() method on empty stack will throw InvalidOperationException. 
 * So always check for elements in the stack before retrieving elements using the Peek() 
 * method.
 * 
 * The Pop() method removes and returns the value that was added last to the Stack. 
 * The Pop() method call on an empty stack will raise an InvalidOperationException. 
 * So always check for number of elements in stack must be greater than 0 before calling 
 * Pop() method.
 * 
 * Points to Remember :
 *      Stack stores the values in LIFO (Last in First out) style. 
 *        The element which is added last will be the element to come out first.
 *      Use the Push() method to add elements into Stack.
 *      The Pop() method returns and removes elements from the top of the Stack. 
 *        Calling the Pop() method on the empty Stack will throw an exception.
 *      The Peek() method always returns top most element in the Stack.
 * 
 */
