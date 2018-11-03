using System;

namespace LambdaFinalizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Destroyer dest = new Destroyer();
        }
}
    /* An expression body definition for a finalizer typically contains cleanup statements,
     * such as statements that release unmanaged resources.
     * The following example defines a finalizer that uses an finalizer lambda expression body definition 
     * to indicate that the finalizer has been called.
     */
    public class Destroyer
    {
        //Overriding the ToString method
        public override string ToString()
        {
            return GetType().Name;
        }

        //Finalizer method using lambda expression
        ~Destroyer() => Console.WriteLine($"The {ToString()} destructor is executing.");

/*      The following is equivelant to the above line of code
        ~Destroyer()
        {
            Console.WriteLine($"The {ToString()} destructor is executing.");
        }
*/
    }
}
