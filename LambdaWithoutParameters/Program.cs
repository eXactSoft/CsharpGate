using System;

namespace LambdaWithoutParameters
{
    class Program
    {

        //Delegate definition
        delegate void Display();

        static void Main(string[] args)
        {
            //Declare a delegate object of type Display.
            Display display;

            //Initialize the delegate object display with an anynoumus method and lambda expression
            display = () => Console.WriteLine("This is parameter less lambda expression");

            //Execute, call, or invoke the delegate
            display();

            //The classical way to Initialize the delegate object display with a named method Print()
            display = Print;

            //Execute, call, or invoke, 
            //with the same result as previous call
            display();
        }

        //Function definition that has the same signature as the delegate Display
        static void Print()
        {
            Console.WriteLine("This is using named method");
        }

        //The following definition of a function is frobidden, only permitted as an anynoumus method for a delegate
        //() => Console.WriteLine("This is parameter less lambda expression");
    }
}
