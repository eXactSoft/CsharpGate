using System;

namespace LambdaPrpertyGetSet
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
        //Lambda Expression/Getter properties
        private int myVar = 5;

        //get & set property by lambda expression
        //property get lambda expression supported from C# 6.0
        //property set lambda expression supported from C# 7.0
        public int MyVar1
        {
            get => myVar * 10; 
            set => myVar = value; 
        }

        // The above code is equivilant to:-
        public int MyVar2
        {
            get { return myVar * 10; }
            set {  myVar=value; }
        }

    }

}
