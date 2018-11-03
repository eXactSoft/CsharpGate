using System;

namespace DelegateWithMultipleMethods
{
    class Program
    {
        //Definition of the calculation delegate
        delegate double CalculationDelegate(double param1, double param2);

        //Multiply method with the same signature as CalculationDelegate
        static double Multiply(double param1, double param2)
        {
            Console.WriteLine("Multiply called");//Only for Test purpose
            return param1 * param2;
        }

        //Divide method with the same signature as CalculationDelegate
        static double Divide(double param1, double param2)
        {
            Console.WriteLine("Divide called");//Only for Test purpose
            return param1 / param2;
        }

        static void DisplayResultOfMultiplyDivideOf(double param1, double param2)
        {
            // Declare a delegate object calculateDelegate of type CalculationDelegate
            CalculationDelegate calculateDelegate;

            //Add the 2 listeners to the calculateDelegate delegate (Multiply & Divide)
            calculateDelegate = Multiply;
            calculateDelegate += Divide;

            //calculateDelegate(param1, param2); //Wow Execute both multiply & divide calculations only with just one line

            //Get the delegateList of the calDelegate
            Delegate[] delegateList= calculateDelegate.GetInvocationList();

            //delegateList.Length; //To get the number of list member on the delegateList

            //return all delegate of type CalculationDelegate from the delegateList
            foreach (CalculationDelegate calculate in delegateList)
            {

                Console.WriteLine("The {0} {1} by {2} = {3}",
                    param1,
                    calculate.Method.Name, //get the name of the current method that subscribed in calculate
                    param2,
                    calculate(param1, param2) //Execute or call the calculate delegate for the current method of the delegate calculate
                    );
            }
        }
        static void Main(string[] args)
        {
            //Enter the 1st & 2nd numbers
            Console.WriteLine("Enter 1st number for multiply & divide calculations: ");
            string firstStringNumber = Console.ReadLine();
            Console.WriteLine("Enter 2nd number for multiply & divide calculations: ");
            string secondStringNumber = Console.ReadLine();

            //Displaying the result of multiplication and division of the 2 numbers
            DisplayResultOfMultiplyDivideOf(float.Parse(firstStringNumber), float.Parse(secondStringNumber));
         }
    }
}
/*
 * Delegate is a type, as we have other types like: int, char or class.
 * But instead of describing a class like most of our objects are, 
 * it describes a method signature
 * 
 */
