using System;
using System.Collections.Generic;

namespace DelegateAnonymousMethod
{
    /*
     * This example uses the FindAll method on the List type, which requires 
     * a delegate instance that receives one integer and returns a boolean. 
     * The argument to FindAll here demonstrates the anonymous method syntax.
     * A boolean expression is evaluated, causing the anonymous method to 
     * return true if the argument is greater than one.
     */
    class Program
    {
        static void Main(string[] args)
        {
            List<int> values = new List<int>() { 1, 1, 1, 2, 3 };
            List<int> res;

            // Embed multiple statements using the anonymous method procedure.
            res = values.FindAll(delegate (int element)
            {
                if (element > 10)
                {
                    throw new ArgumentException("element");
                }
                if (element == 8)
                {
                    throw new ArgumentException("element");
                }
                return element > 1;
            });

            Console.WriteLine("Display results based on the anonymous method procedure.");
            // Display results based on the anonymous method procedure.
            foreach (int val in res)
            {
                Console.WriteLine(val);
            }

            // Embed multiple statements in an using lambda expression procedure.
            res = values.FindAll( element =>
                    {
                        if (element > 10)
                        {
                            throw new ArgumentException("element");
                        }
                        if (element == 8)
                        {
                            throw new ArgumentException("element");
                        }
                        return element > 1;
                    }
                 );

            Console.WriteLine("Display results based on the lambda expression procedure.");
            // Display results based on the lambda expression procedure.
            foreach (int val in res)
            {
                Console.WriteLine(val);
            }
        }
    }
}
/*
 * Anonymous Methods. An anonymous method has no name. 
 * By using the delegate keyword, you can add multiple statements inside your 
 * anonymous function. It can use if-statements and loops.
 * 
 * The same result can be gotten using lambda expresion.
 * 
 * An interesting point about anonymous methods is that they are effectively local to the code 
 * block that contains them, and they have access to local variables in this scope. 
 * If you use such a variable, then it becomes an outer variable. Outer variables are not 
 * disposed of when they go out of scope as other local variables are; instead, they live on 
 * until the anonymous methods that use them are destroyed. This might be some time later 
 * than you expect, so it’s definitely something to be careful about. 
 * If an outer variable takes up a large amount of memory, or if it uses resources that 
 * are expensive in other ways (for example, resources that are limited in number), 
 * then this could cause memory or performance problems.
 */
