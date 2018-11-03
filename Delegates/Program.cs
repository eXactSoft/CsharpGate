using System;

namespace DelegateWithSingleMethod
{
    class Program
    {
        //Defination of the delegate CalculationDelegate
        delegate double CalculationDelegate(double param1, double param2);

        //Multiply method with the same signature as CalculationDelegate
        static double Multiply(double param1, double param2)
        {
            return param1 * param2;
        }

        //Divide method with the same signature as CalculationDelegate
        static double Divide(double param1, double param2)
        {
            return param1 / param2;
        }

        static void Main(string[] args)
        {
            //Declaration of delegate object calculateDelegate of type CalculationDelegate
            CalculationDelegate calculateDelegate;

            Console.WriteLine("Enter m to multiply or d to divide (10,5):");
            string input = Console.ReadLine();

            //Add the 1 listener to that calculateDelegate delegate (Multiply or Divide)
            if (input == "m")
                calculateDelegate = new CalculationDelegate(Multiply);
                //The following is equivelant
                //calculateDelegate = Multiply;
            else
                calculateDelegate = Divide;
                //The following is equivelant
                //calculateDelegate = new CalculationDelegate(Divide);

            //Execute, invoke, or call the calculateDelegate delegate
            Console.WriteLine($"Result: {calculateDelegate(10.0, 5.0)}");
        }
    }
}
/*
 * Delegate is a type, as we have other types like: int, char or class.
 * But instead of describing a class like most of our objects are, 
 * it describes a method signature
 * 
 */
