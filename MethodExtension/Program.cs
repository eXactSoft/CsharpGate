using System;
using AllExtensionMethods;
// You can include the AllExtensionMethods namespace wherever you want to use IsGreaterThan extension method.

namespace MethodExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 900;

            /* The IsGreaterThan() method is not a method of int data type (Int32 struct). It is an extension 
             * method written by the programmer for the int data type. The IsGreaterThan() extension method 
             * will be available throughout the application by including the namespace in which it has been 
             * defined.
             */
            bool result = i.IsGreaterThan(100);

            Console.WriteLine(result);
        }
    }
}


namespace AllExtensionMethods
{
    public static class IntExtensions
    {   
        //We are going to use this extension method on int type. So the first parameter must be int 
        //preceded with the this modifier.
        //the IsGreaterThan() method operates on int, so the first parameter would be, this int i.
        public static bool IsGreaterThan(this int i, int value)
        {
            return i > value;
        }
    }
}
/*
 * Extension methods, as the name suggests, are additional methods. Extension methods allow you to inject additional 
 * methods without modifying, deriving or recompiling the original class, struct or interface. Extension methods can 
 * be added to your own custom class, .NET framework classes, or third party classes or interfaces. 
 * 
 * LINQ is built upon extension methods that operate on IEnumerable and IQeryable type.
 * 
 * An extension method is actually a special kind of static method defined in a static class. To define an extension 
 * method, first of all, define a static class.
 * 
 * define a static method as an extension method where the first parameter of the extension method specifies the type 
 * on which the extension method is applicable.
 * 
 * The only difference between a regular static method and an extension method is that the first parameter of the 
 * extension method specifies the type that it is going to operator on, preceded by the this keyword.
 * 
 * The extension methods have a special symbol in intellisense of the visual studio, so that you can easily 
 * differentiate between class methods and extension methods.
 * 
 * Points to Remember :
 *  Extension methods are additional custom methods which were originally not included with the class.
 *  Extension methods can be added to custom, .NET Framework or third party classes, structs or interfaces.
 *  The first parameter of the extension method must be of the type for which the extension method is applibable, 
 *    preceded by the this keyword.
 *  Extension methods can be used anywhere in the application by including the namespace of the extension method.
 * 
 */
