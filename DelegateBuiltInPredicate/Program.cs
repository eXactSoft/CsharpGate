using System;

namespace DelegateBuiltInPredicate01
{
    class Program
    {
        //Predicate Delegate does not require declaration as it is Built in with .Net Framework

        static void Main(string[] args)
        {
            //Predicate Built in Delegate declaration and initialized with Named method IsTeenager()
            Predicate<int> predicateDelegateWithNamedMethod = IsTeenager;

            //Predicate Built in Delegate declaration and initialized with Anonymous method
            Predicate<int> predicateDelegateWithAnonymousMethod = delegate (int age)
            {
                return age >12 && age<20;
            };

            //Predicate Built in Delegate with Lambda Expression cannot be used without parameter

            //Predicate Built in Delegate declaration and initialized with Lambda Expression (For sure with 1 parameter)
            Predicate<int> predicateDelegateWithLambda = (age) => age > 12 && age < 20;

            //Invoke the delegate instances in turn
            Console.WriteLine("The person age is teenager ? :" + predicateDelegateWithNamedMethod(11));

            Console.WriteLine("The person age is teenager ? :" + predicateDelegateWithAnonymousMethod(15));

            Console.WriteLine("The person age is teenager ? :" + predicateDelegateWithLambda(21));
        }

        //Method with the same signature of delegate funcDelegateWithNamedMethod
        public static bool IsTeenager(int age)
        {
            return age>12 && age<20;
        }
    }
}
/*
 * C# 3.0 includes built-in generic delegate types Func, Action, & Predicate, 
 * so that you don't need to define or declare a custom delegates it is already 
 * declared in the .Net Framework System namespace.
 * 
 * A predicate is also a delegate like Func and Action delegates. 
 * It represents a method that contains a set of criteria and checks whether 
 * the passed parameter meets those criteria or not. A predicate delegate methods 
 * must take one input parameter and it then returns a boolean value - true or false.
 * The Predicate delegate is defined in the System namespace as shown below:
 * Predicate signature: public delegate bool Predicate<in T>(T obj);
 * Same as other delegate types, Predicate can also be used with any 
 * method, anonymous method or lambda expression.

 * Points to Remember :
 * 1)-Predicate is built-in delegate type.
 * 2)-Predicate delegate takes one input parameter and boolean return type.
 * 3)-Predicate delegate must contains some criateria to check whether supplied 
 * parameter meets those criateria or not.
 * 4)-Anonymous method and Lambda expression can be assigned to the predicate delegate.
 * 
 */
