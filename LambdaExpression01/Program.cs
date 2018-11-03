using System;

namespace LambdaSingleExpressionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Lambda Obj = new Lambda();

            Console.WriteLine( Obj.Multiply1(5 , 4) );
            Console.WriteLine( Obj.Multiply2(5, 4) );

            Obj.DisplayHello1();
            Obj.DisplayHello1();
        }

    }

    public class Lambda
    {
        /*Lambda expression/Expression bodied methods only used with
         * single expression method that return a value whose type matches 
         * the method's return type as Multiply1 method, or
         * for methods that return void, that performs some operation as DisplayHello1 method.
         * multiple expressions method used only with delegate
         */

        //Single expression method that return a value            
        public double Multiply1(double val1, double val2) => val1 * val2;

        // The Multiply2 method is equivelant to Multiply1
        public double Multiply2(double val1, double val2)
        {
            return val1 * val2;
        }

        //Single expression method that return void  
        public void DisplayHello1() => Console.WriteLine("Hello World");

        // The DisplayHello2 method is equivelant to DisplayHello1
        public void DisplayHello2()
        {
            Console.WriteLine("Hello World");
        }
    }
}
/* An expression-bodied method consists of a single expression that returns 
 * a value whose type matches the method's return type, or, for methods that return void,
 * that performs some operation. 
 * Supported from C# 6.0
 */
