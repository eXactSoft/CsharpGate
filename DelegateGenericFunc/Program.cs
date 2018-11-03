using System;

namespace DelegateBuiltInFunc
{
    class Program
    {
        //Func Delegate does not require declaration as it is Built in with .Net Framework

        static void Main(string[] args)
        {
            //Func Built in Delegate declaration and initialized with Named method Sum()
            Func<int, int, int> funcDelegateWithNamedMethod = Sum;

            //Func Built in Delegate declaration and initialized with Anonymous method
            Func<int> funcDelegateWithAnonymousMethod = delegate ()
            {
                Random rnd = new Random();
                return rnd.Next(1, 100);
            };

            //Func Built in Delegate declaration and initialized with Lambda Expression without parameters
            Func<int> funcDelegateWithLambdaWithoutParam = () => new Random().Next(1, 100);

            //Func Built in Delegate declaration and initialized with Lambda Expression with 2 parameters
            Func<int, int, int> funcDelegateWithLambdaWith2Params = (x, y) => x + y;

            //Execute, invoke, or call the delegate instances in turn
            Console.WriteLine("The sum of 10 & 20 is: " + funcDelegateWithNamedMethod(10, 20));

            Console.WriteLine("The random number bet 1 & 100 is: " + funcDelegateWithAnonymousMethod());

            Console.WriteLine("The random number bet 1 & 100 is: " + funcDelegateWithLambdaWithoutParam());

            Console.WriteLine("The sum of 10 & 20 is: " + funcDelegateWithLambdaWith2Params(10, 20));
        }

        //Method with the same signature of delegate funcDelegateWithNamedMethod
        public static int Sum(int x, int y)
        {
            return x + y;
        }
    }
}
/*
 * C# 3.0 includes built-in generic delegate types Func, Action, & Predicate, 
 * so that you don't need to define or declare a custom delegates it is already 
 * declared in the .Net Framework System namespace.
 * 
 * You can use the Func type as a field, return value, local variable, 
 * or parameter in your C# programs. You must specify the full type name 
 * with the type parameters. In this way we can store delegates by their signatures.
 * For Example: You can add the Func<int, string> as a field, and give it an identifier.
 * 
 * Func is a generic delegate included in the System namespace. 
 * It has zero or more input parameters and one out parameter. 
 * The last parameter is considered as an out parameter.
 * 
 * For example, a Func delegate that takes one input parameter and one out parameter 
 * is defined in the System namespace as below:

            namespace System
            {    
                public delegate TResult Func<in T, out TResult>(T arg);
            }

 * The last parameter in the angle brackets <> is considered as the return type and 
 * remaining parameters are considered as input parameter types.
 * The following Func type delegate, where it takes two input parameters of int type 
 * and returns a value of long type:

            Func<int, int, long> sum;

 * A Func delegate type can include 0 to 16 input parameters of different types. 
 * However, it must include one out parameter for result.
 * You can assign an anonymous method to the Func delegate by using the delegate keyword.


            Func<int> getRandomNumber = delegate()
                                        {
                                            Random rnd = new Random();
                                            return rnd.Next(1, 100);
                                        };

 * A Func delegate can also be used with a lambda expression, as shown below:

        Func<int> getRandomNumber = () => new Random().Next(1, 100);

        //Or 

        Func<int, int, int>  Sum  = (x, y) => x + y;

 * Points to Remember :
 * 1)-Func is built-in delegate type.
 * 2)-Func delegate type must return a value.
 * 3)-Func delegate type can have zero to 16 input parameters.
 * 4)-Func delegate type can be used with an anonymous method or lambda expression.
 * 
 */
