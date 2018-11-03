using System;

namespace DelegateAnonymousAndNamedMethod
{
    /*The following example demonstrates two ways of instantiating a delegate:
     * Associating the delegate with an anonymous method.
     * Associating the delegate with a named method (DoWork).
     * In each case, a message is displayed when the delegate is invoked.
     */
     
    // Define a delegate.
    delegate void Printer(string s);

    class Program
    {
        static void Main(string[] args)
        {
            // Declare (Instantiate) a delegate of type Printer 
            Printer p;

            //Initialize the delegate p to an anonymous method.
            p = delegate (string j)
            {
                System.Console.WriteLine(j);
            };

            // Results from the anonymous delegate call.
            p("The delegate using the anonymous method is called.");

            //Initialize the delegate p to a named method "DoWork".
            p = DoWork;

            // Results from the named method delegate call.
            p("The delegate using the named method is called.");
        }

        // The method associated with the named delegate.
        static void DoWork(string k)
        {
            System.Console.WriteLine(k);
        }
    }
}

/*In versions of C# before 2.0, the only way to declare a delegate was to use named methods.
 * C# 2.0 introduced anonymous methods and in C# 3.0 and later, lambda expressions supersede 
 * anonymous methods as the preferred way to write inline code. However, the information 
 * about anonymous methods in this topic also applies to lambda expressions. 
 * There is one case in which an anonymous method provides functionality not found in lambda 
 * expressions. Anonymous methods enable you to omit the parameter list. 
 * This means that an anonymous method can be converted to delegates with
 * a variety of signatures. This is not possible with lambda expressions.
 * 
 * Creating anonymous methods is essentially a way to pass a code block as a delegate parameter. 
 * 
 * By using anonymous methods, you reduce the coding overhead in instantiating delegates because 
 * you do not have to create a separate method.
 * The scope of the parameters of an anonymous method is the anonymous-method-block.
 * 
 * It is an error to have a jump statement, such as goto, break, or continue, 
 * inside the anonymous method block if the target is outside the block. 
 * It is also an error to have a jump statement, such as goto, break, or continue, 
 * outside the anonymous method block if the target is inside the block.
 * The local variables and parameters whose scope contains an anonymous method 
 * declaration are called outer variables of the anonymous method. For example, 
 * in the following code segment, n is an outer variable:-

            int n = 0;
            Del d = delegate() { System.Console.WriteLine("Copy #:{0}", ++n); };

  * A reference to the outer variable n is said to be captured when the delegate is created. 
  * Unlike local variables, the lifetime of a captured variable extends until the delegates 
  * that reference the anonymous methods are eligible for garbage collection.

  * An anonymous method cannot access the in, ref or out parameters of an outer scope.
  * No unsafe code can be accessed within the anonymous-method-block.
  * Anonymous methods are not allowed on the left side of the is operator.
  * 
  * C# - Anonymous Method:-
  * As the name suggests, an anonymous method is a method without a name. 
  * Anonymous methods in C# can be defined using the delegate keyword and 
  * can be assigned to a variable of delegate type.
  * Anonymous methods can access variables defined in an outer function.
  * Anonymous methods can also be passed to a method that accepts the delegate as a parameter.
  * Anonymous methods can be used as event handlers
  * It cannot contain jump statement like goto, break or continue.
  * It cannot access ref or out parameter of an outer method.
  * It cannot have or access unsafe code.
  * It cannot be used on the left side of the is operator.
  * Anonymous method can be defined using the delegate keyword
  * Very Very important to note that:- Anonymous method must be assigned to a delegate.
  * 
  */
