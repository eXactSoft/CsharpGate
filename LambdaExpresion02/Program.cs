using System;

namespace LambdaPropertyGet
{
    class Program
    {
        static void Main(string[] args)
        {
            Lambda obj = new Lambda();
            Console.WriteLine(obj.MyVar1);
            Console.WriteLine(obj.MyVar2);
        }
    }

    class Lambda
    {
        private int myVar = 5;

        //getter property or read only property using lambda expression
        public int MyVar1 => myVar * 10; 

        // The above code is equivilant to:-
        public int MyVar2
        {
            get { return myVar * 10; }
        }
    }

}
