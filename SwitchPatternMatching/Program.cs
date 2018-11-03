using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SwitchPatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_1-------------------------------------------------------------");
            //call switch case==> int
            ShowCollectionInformation(100);

            Console.WriteLine("_2-------------------------------------------------------------");
            //call switch case==> string with length < 5
            ShowCollectionInformation("Math");

            Console.WriteLine("_3-------------------------------------------------------------");
            //call switch case==> string 
            ShowCollectionInformation("School");

            Console.WriteLine("_4-------------------------------------------------------------");
            //call switch case==> Array
            ShowCollectionInformation(new double[]{ 2.5, 3.1, 4.4, 7.3});

            Console.WriteLine("_5-------------------------------------------------------------");
            //call switch case==> IEnumerable<int>
            ShowCollectionInformation(new List<bool> { true, false, true });

            Console.WriteLine("_6-------------------------------------------------------------");
            //call switch case==> IList
            ShowCollectionInformation(new List<int> { 10, 20, 30 });

            Console.WriteLine("_7-------------------------------------------------------------");
            //call switch case==> IEnumerable
            ShowCollectionInformation(new Hashtable() { { 10, "One" }, { 20, "Two" } });

            Console.WriteLine("_8-------------------------------------------------------------");
            //call switch case==> Null
            ShowCollectionInformation(null);

            Console.WriteLine("_9-------------------------------------------------------------");
            //call switch case==> default
            ShowCollectionInformation(10.0);
        }

        //Method that use switch case pattern matching 
        private static void ShowCollectionInformation(object coll)
        {
            switch (coll)
            {
                case int val:
                    Console.WriteLine($"An int with value: {val}");
                    break;
                case string str when str.Length < 5:
                    Console.WriteLine($"A string less than 5 char with value: {str}");
                    break;
                case string str:
                    Console.WriteLine($"A string with value: {str}");
                    break;
                case Array arr:
                    Console.WriteLine($"An array with {arr.Length} elements.");
                    break;
                case IEnumerable<int> ieInt:
                    Console.WriteLine($"Average: {ieInt.Average(s => s)}");
                    break;
                case IList list:
                    Console.WriteLine($"{list.Count} items");
                    break;
                case IEnumerable ie:
                    string result = "";
                    foreach (var item in ie)
                        result += $"{item} ,";
                    Console.WriteLine(result);
                    break;
                case null:
                    Console.WriteLine($"This is a null value");
                    break;
                default:
                    Console.WriteLine($"A instance of type {coll.GetType().Name}");
                    break;
            }
        }

        //Similar Method to the above without pattern matching using if else
        private static void ShowCollectionInformationWithoutSwitch(object coll)
        {
            if (coll is Array)
            {
                Array arr = (Array)coll;
                Console.WriteLine($"An array with {arr.Length} elements.");
            }
            else if (coll is IEnumerable<int>)
            {
                IEnumerable<int> ieInt = (IEnumerable<int>)coll;
                Console.WriteLine($"Average: {ieInt.Average(s => s)}");
            }
            else if (coll is IList)
            {
                IList list = (IList)coll;
                Console.WriteLine($"{list.Count} items");
            }
            else if (coll is IEnumerable)
            {
                IEnumerable ie = (IEnumerable)coll;
                string result = "";
                foreach (var item in ie)
                    result += "${e} ";
                Console.WriteLine(result);
            }
            else if (coll == null)
            {
                // Do nothing. 
            }
            else
            {
                Console.WriteLine($"An instance of type {coll.GetType().Name}");
            }
        }
    }

}
/*
 * In C# 7 it is possible to match patterns in a switch case based on the type of variable, 
 * for example a string or integer array. Then, because you know the type, you can access 
 * methods and properties exposed by that type.
 * 
 * When used with the switch statement to perform pattern matching, 
 * it tests whether an expression can be converted to a specified type and, if it can be, 
 * casts it to a variable of that type. Its syntax is:
 *                                                     case type varname
 * 
 * The case expression is true if any of the following is true:
 *  expr is an instance of the same type as type.
 *  expr is an instance of a type that derives from type. In other words, the result of 
 *  expr can be upcast to an instance of type.
 *  expr has a compile-time type that is a base class of type, and expr has a runtime 
 *   type that is type or is derived from type. The compile-time type of a variable is 
 *   the variable's type as defined in its type declaration. 
 *   The runtime type of a variable is the type of the instance that is assigned to 
 *   that variable.
 *  expr is an instance of a type that implements the type interface.
 *  
 * If the case expression is true, varname is definitely assigned and has local scope 
 *   within the switch section only.
 *  
 * Note that null does not match a type. To match a null, you use the following case label:
 *              case null:
 * 
 * The use of type pattern matching produces more compact, readable code by eliminating 
 * the need to test whether the result of a conversion is a null or to perform repeated casts.
 * 
 * Starting with C# 7.0, because case statements need not be mutually exclusive, you can add 
 * a when clause to specify an additional condition that must be satisfied for the case 
 * statement to evaluate to true. The when clause can be any expression that 
 * returns a Boolean value.
 * The when keyword modifier lets you expand out or add additional conditions required to execute the
 * code found within the case statement.
 * 
 * In addition to the switch case expression pattern, Pattern Matching can be 
 * implemented using the is keyword.
 * 
 */
