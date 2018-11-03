using System;

namespace LambdaDelegate
{
    class Program
    {
        //Delegate definition to do some logic with the age
        delegate bool AgeDelegate(float age);

        //Named method with the same signature of the AgeDelegate
        static bool IsRetired(float yourAge)
        {
            return yourAge > 60.0;
        }

        //Named method with the same signature of the AgeDelegate
        static bool IsMature(float yourAge)
        {
            return yourAge >= 21.0;
        }

        //A method that take your age and do some logics with it return the result
        static bool AgeLogicResult(float age, AgeDelegate AgeLogic)
        {
            bool isResult = AgeLogic(age);
            return isResult;
        }

        static void Main(string[] args)
        {
            //Enter your age
            Console.WriteLine("Enter your age: ");
            string stringAge = Console.ReadLine();
            float floatAge = float.Parse(stringAge);
            bool result;

            //Using a named method delegate, check your age is retired or not
            result = AgeLogicResult(floatAge, IsRetired);
            Console.WriteLine($"IsRetired: {result}");

            //Initialize the AgeLogic delegate using a named method
            //, check your age is mature or not
            result = AgeLogicResult(floatAge, IsMature);
            Console.WriteLine($"IsMature: {result}");

            //Initialize the AgeLogic delegate using an anonymous method delegate
            //, check your age is teenager or not
            result = AgeLogicResult(floatAge, delegate(float n) {
                if( n > 12 && n < 20)
                    return true;
                else
                    return false;
                }
             );
            Console.WriteLine($"IsTeenager: {result}");

            //Initialize the AgeLogic delegate using an anonymous method delegate & lambda expression, 
            //Lambda expression with multiple statements in the body
            //check your age is teenager or not
            result = AgeLogicResult(floatAge,  n=> {
                if (n > 12 && n < 20)
                    return true;
                else
                    return false;
            }
             );
            Console.WriteLine($"IsTeenager: {result}");

            //Initialize the AgeLogic delegate using an anonymous method delegate
            //& lambda expression with the most compact form, 
            //Lambda expression with single statement in the body
            //check your age is teenager or not
            result = AgeLogicResult(floatAge, n => (n > 12 && n < 20)
             );
            Console.WriteLine($"IsTeenager: {result}");
        }
    }
}
/*
 *Delegate is a type, as we have other types like: int, char or class.
 * But instead of describing a class like most of our objects are, 
 * it describes a method signature.
 * 
 */
