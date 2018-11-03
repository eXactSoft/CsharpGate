using System;

namespace NullableType
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_1-------------------------------------------------------------");
            //Nullable Type using Nullable struct

            Nullable<int> i = null;

            //Console.WriteLine(i); //No Exception raised and display null which is empty space in the screen.
            //Console.WriteLine(i.Value); //raises InvalidOperationException

            // The HasValue returns true if the object has been assigned a value; if it has not been 
            // assigned any value or has been assigned a null value, it will return false.
            if (i.HasValue)
                Console.WriteLine(i.Value); // or Console.WriteLine(i)
                //Accessing the value using NullableType.value will throw a runtime exception if nullable type 
                //is null or not assigned any value. For example, i.Value will throw an exception if i is null.
            else
                Console.WriteLine("Null");

            //Use the GetValueOrDefault() method to get an actual value if it is not null and the default 
            //value if it is null.
            Console.WriteLine(i.GetValueOrDefault());

            Console.WriteLine("_2-------------------------------------------------------------");

            //Shorthand syntax (?) for Nullable types
            double? d = null;
            Console.WriteLine(d.GetValueOrDefault());

            //Use the '??' operator to assign a nullable type to a non-nullable type.
            //i is a nullable int and if you assign it to the non-nullable int j then it will throw a runtime 
            //exception if i is null. So to mitigate the risk of an exception, we have used the '??' operator 
            //to specify that if i is null then assign 0 to j.
            int j = i ?? 0;
            Console.WriteLine(j);

            Console.WriteLine("_3-------------------------------------------------------------");
            //Use a nullable type as a field of the class without assigning value
            MyClass mycls = new MyClass(); 

            if (mycls.i == null) //No Unassigned nullable compiler type-error
                Console.WriteLine("Null");
            /*
            int? f;
            if (f == null) //"Unassigned nullable compiler type-error"
                Console.WriteLine("Null");
            */

            Console.WriteLine("_4-------------------------------------------------------------");
            /* Null is considered to be less than any value. So comparison operators won't work against null. 
             * Consider the following example where i1 is neither less than j1, greater than j1 nor equal to j1
             */
            int? i1 = null;
            int j1 = 10;


            if (i1 < j1)
                Console.WriteLine("i1 < j1");
            else if (i1 > 10)
                Console.WriteLine("i1 > j1");
            else if (i1 == 10)
                Console.WriteLine("i1 == j1");
            else
                Console.WriteLine("Could not compare");

            Console.WriteLine("_5-------------------------------------------------------------");
            //Nullable static class is a helper class for Nullable types. It provides a compare 
            //method to compare nullable types.
            if (Nullable.Compare<int>(i1, j1) < 0)
                Console.WriteLine("i1 < j1");
            else if (Nullable.Compare<int>(i, j) > 0)
                Console.WriteLine("i1 > j1");
            else
                Console.WriteLine("i1 = j1");
        }
    }

    class MyClass
    {
        public Nullable<int> i;
        //Same as public int? i;
    }
}
/*
 * A value type cannot be assigned a null value. For example, int i = null will give you a compile time error.
 * C# 2.0 introduced nullable types that allow you to assign null to value type variables. 
 * You can declare nullable types using Nullable<t> where T is a type.
        Nullable<int> i = null;
 * 
 * A nullable type can represent the correct range of values for its underlying value type, plus an 
 * additional null value. For example, Nullable<int> can be assigned any value from -2147483648 to 2147483647, 
 * or a null value.
 * 
 * The Nullable types are instances of System.Nullable<T> struct. 
 * Think it as something like the following structure:
        [Serializable]
        public struct Nullable<T> where T : struct
        {        
            public bool HasValue { get; }
      
            public T Value { get; }
        
            // other implementation
        }
 * A nullable of type int is the same as an ordinary int plus a flag that says whether the int has a value 
 * or not (is null or not). All the rest is compiler magic that treats "null" as a valid value.
 * 
 * The HasValue returns true if the object has been assigned a value; if it has not been assigned any value 
 * or has been assigned a null value, it will return false.
 * 
 * Accessing the value using NullableType.value will throw a runtime exception if nullable type is null 
 * or not assigned any value.
 * 
 * Use the GetValueOrDefault() method to get an actual value if it is not null and the default value 
 * if it is null.
 * 
 * You can use the '?' operator to shorthand the syntax e.g. int?, long? instead of using Nullable<T>.
 * 
 * Use the '??' operator to assign a nullable type to a non-nullable type.
 * 
 * A nullable type has the same assignment rules as a value type. It must be assigned a value before using it 
 * if nullable types are declared in a function as local variables. If it is a field of any class then it will 
 * have a null value by default.
 * For example, the following nullable of int type is declared and used without assigning any value. 
 * The compiler will give "Use of unassigned local variable 'i'" error:
        int? i;
        Console.WriteLine(i); // "Use of unassigned local variable 'i'" compiler error
 * but if you use a nullable type as a field of the class without assigning value==> No Unassigned nullable type-error
 * 
 * Null is considered to be less than any value. So comparison operators won't work against null.
 * 
 * Nullable static class is a helper class for Nullable types. It provides a compare method to compare nullable types. 
 * It also has a GetUnderlyingType method that returns the underlying type argument of nullable types.
 * 
 * Characteristics of Nullable Types
 *  Nullable types can only be used with value types.
 *  The Value property will throw an InvalidOperationException if value is null; otherwise it will return 
 *    the value.
 *  The HasValue property returns true if the variable contains a value, or false if it is null.
 *  You can only use == and != operators with a nullable type. For other comparison use the Nullable 
 *    static class.
 *  Nested nullable types are not allowed. Nullable<Nullable<int>> i; will give a compile time error.
 * 
 * Points to Remember :
 *  Nullable<T> type allows assignment of null to value types.
 *  ? operator is a shorthand syntax for Nullable types.
 *  Use value property to get the value of nullable type.
 *  Use HasValue property to check whether value is assigned to nullable type or not.
 *  Static Nullable class is a helper class to compare nullable types.
 * 
 */
