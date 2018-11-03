using System;

namespace Strut
{
    class Program
    {
        static void Main(string[] args)
        {
            Discounts saleDiscounts = new Discounts();

            saleDiscounts.Cloths = 10;
            saleDiscounts.HomeDecor = 5;
            saleDiscounts.Grocery = 2;
        }
    }

    public struct Discounts
    {
        public int Cloths { get; set; }
        public int HomeDecor { get; set; }
        public int Grocery { get; set; }
    }
}
/*
 * A structure is a value type that can contain constructors, constants, fields, methods, 
 * properties, indexers, operators, events and nested types. 
 * 
 * A struct is a value type so it is faster than a class object. Use struct whenever you want 
 * to just store the data. Generally structs are good for game programming. However, 
 * it is easier to transfer a class object than a struct. 
 * So do not use struct when you are passing data across the wire or to other classes.
 * 
 * Please note that if you want to use properties, methods or events, 
 * you MUST initialize the struct with the new keyword. The following will give 
 * a compile time error:
        Point pto;
        pto.XPoint = 100; // compile time error
 * 
 * Characteristics of Structure:
 *      Structure can include constructors, constants, fields, methods, properties, 
 *          indexers, operators, events & nested types.
 *      Structure cannot include default constructor or destructor.
 *      Structure can implement interfaces.
 *      A structure cannot inherit another structure or class.
 *      Structure members cannot be specified as abstract, virtual, or protected.
 *      Structures must be initialized with new keyword in order to use it's properties, 
 *          methods or events.
 * 
 * Difference between Struct and Class:
 *      Class is reference type whereas struct is value type
 *      Struct cannot declare a default constructor or destructor. However, 
 *        it can have parametrized constructors.
 *      Struct can be instasntiated without the new keyword. However, you won't be able 
 *        to use any of its methods, events or properties if you do so.
 *      Struct cannot be used as a base or cannot derive another struct or class.
 * 
 * Points to Remember :
 *      Structure is a value type and defined using struct keyword.
 *      Structure can be initialized with or without new keyword.
 *      Structure must be initialized with new keyword to use its' properties, 
 *        methods and events.
 * 
 */
