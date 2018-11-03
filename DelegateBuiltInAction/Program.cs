using System;

namespace DelegateBuiltInAction
{
    class Program
    {
        //Action Delegate does not require defintion as it is Built in with .Net Framework

        static void Main(string[] args)
        {
            //Action Built in Delegate declaration and initialized to Named method
            Action<int, int> actionDelegateWithNamedMethod = Sum;

            //Action Built in Delegate declaration and initialized to Anonymous method
            Action<int, int> actionDelegateWithAnonymousMethod = delegate (int x, int y)
            {
                int sum = x + y;
                Console.WriteLine("The sum of 10 & 20 is: " + sum);
            };

            //Action Built in Delegate declaration and initialized to Lambda Expression without parameters
            Action actionDelegateWithLambdaWithoutParams = () => Console.WriteLine("This is a delegate without parameters");

            //Action Built in Delegate declaration and initialized to Lambda Expression with 2 parameters
            Action<int, int> actionDelegateWithLambdaWith2Params = (x, y) => Console.WriteLine("The sum of 10 & 20 is: " + (x+y));

            //Invoke or call the delegate instances in turn
            actionDelegateWithNamedMethod(10, 20);

            actionDelegateWithAnonymousMethod(10, 20);

            actionDelegateWithLambdaWithoutParams();

            actionDelegateWithLambdaWith2Params(10, 20);

        }

        //Method with the same signature of delegate funcDelegateWithNamedMethod
        public static void Sum(int x, int y)
        {
            int sum = x + y;
            Console.WriteLine("The sum of 10 & 20 is: " + sum);
        }
    }
}
/*
 * C# 3.0 includes built-in generic delegate types Func, Action, & Predicate, 
 * so that you don't need to define or declare a custom delegates it is already 
 * declared in the .Net Framework System namespace.
 * 
 * An Action type delegate is the same as Func delegate except that 
 * the Action delegate doesn't return a value. In other words, an Action delegate 
 * can be used with a method that has a void return type.
 * 
 * Like any other delegate you can initialize an Action delegate using the new keyword 
 * or by directly assigning a method:

        Action<int> printActionDel = ConsolePrint;

        //Or

        Action<int> printActionDel = new Action<int>(ConsolePrint);

 * An Action delegate can take up to 16 input parameters of different types.
 * An Anonymous method can also be assigned to an Action delegate
 * You can use any method that doesn't return a value with Action delegate types.
 * It is possible to use Action as the value in a Dictionary instance. 
 * This makes it possible to call functions by a string key.
 * 
 * Points to Remember :
 * 1)-Action is built-in delegate type.
 * 2)-Action delegate type can have from 0 to 16 input parameters.
 * 3)-Action delegate type can be used with an anonymous method or lambda expression.
 * 
 */
