using System;

namespace PasssingVariablesToMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            //1)- Passing value type which by default passed by value
            int paramInt = 100;
            PassIntByValue(paramInt);
            Console.WriteLine($"int value passed by value paramInt= {paramInt}");

            //2)(a)- Passing value type passed by ref
            int paramIntRef1 = 100;
            PassIntByReferenceRef(ref paramIntRef1);
            Console.WriteLine($"int value passed by reference (ref) paramIntRef= {paramIntRef1}");

            //2)(b)- Passing value type passed by out
            int paramIntOut1;
            PassIntByReferenceOut(out paramIntOut1);
            Console.WriteLine($"int value passed by reference (out) paramIntOut= {paramIntOut1}");

            //3)- Passing Array reference type.
            int[] paramArrayInt1 = { 50, 100 };
            PassArrayIntByReference(paramArrayInt1);
            Console.WriteLine($"int array reference type passed by reference paramArrayInt1[1]= {paramArrayInt1[1]}");

            //3)- Passing class reference type.
            Book bk1 = new Book();
            bk1.NumberOfPages = 100;
            PassClassByReference(bk1);
            Console.WriteLine($"Book class reference type passed by reference NumberOfPages= {bk1.NumberOfPages}");

            //4)- Passing string type which passed by value
            string paramString1 = "First";
            PassStringByValue(paramString1);
            Console.WriteLine($"string immutable reference type passed by value paramString1= {paramString1}");

            //5)(a)- Passing string type which passed by ref
            string paramStringRef1 = "First";
            PassStringByReferenceRef(ref paramStringRef1);
            Console.WriteLine($"string immutable reference type passed by ref paramStringRef1= {paramStringRef1}");

            //5)(b)- Passing string type which passed by out
            string paramStringOut1;
            PassStringByReferenceOut(out paramStringOut1);
            Console.WriteLine($"string immutable reference type passed by out paramStringOut1= {paramStringOut1}");
        }

        static void PassIntByValue(int paramInt2)
        {
            paramInt2 = 200;
        }

        static void PassIntByReferenceRef( ref int paramIntRef2)
        {
            paramIntRef2 = 200;
        }

        static void PassIntByReferenceOut(out int paramIntOut2)
        {
            paramIntOut2 = 200;
        }

        static void PassArrayIntByReference(int[] paramArrayInt2)
        {
            paramArrayInt2[1] = 200;
        }

        public class Book
        {
            public int NumberOfPages { get; set; }
        }

        static void PassClassByReference(Book bk2)
        {
            bk2.NumberOfPages = 200;
        }

        static void PassStringByValue(string paramString2)
        {
            paramString2 = "Second";
        }

        static void PassStringByReferenceRef(ref string paramStringRef2)
        {
            paramStringRef2 = "Second";
        }

        static void PassStringByReferenceOut(out string paramStringOut2)
        {
            paramStringOut2 = "Second";
        }
    }
}
/*
 * There are the following cases:
 * 1) Passing value type.
 * 2) Passing value type by reference:
 *                              a)by ref keyword
 *                              b)by out keyword
 * 3) Passing reference type except string type.
 * 4) Passing string type.
 * 5) Passing string type by reference:
 *                              a)by ref keyword
 *                              b)by out keyword
 */


/* 
 * Value type stores the value in its memory space, 
 * whereas reference type stores the address of the value where it is stored.
 * 
 * Primitive data types (sbyte, byte, short, ushort, int, uint, long, ulong, float, double
 * , decimal, char, bool,& DateTime) are all of the 'Value' type and passed by value. 
 * strut data type is of the 'Value' type and passed by value.
 * 
 * Class objects, array, delegates are reference types and passed by reference 
 * (without the need of ref or out).
 * 
 * string is immutable reference objects. This means that reference to string is passed 
 * around (by value), and once a string is created, you cannot modify it. 
 * Methods that produce modified versions of the string (substrings, trimmed versions, etc.) 
 * create modified copies of the original string.
 * So string is immutable reference type passed by value.
 * If you want to pass string by reference, you should use (ref, out) as value type.
 * 
 * Value type passes by value by default. 
 * Immutable Reference type passes by reference by default.
 * Reference type passes byref by default.
 * 
 * Value types and reference types stored in Stack and Heap in the memory 
 * depends on the scope of the variable.
 * 
 * ref/out are like pointers in C/C++, they deal with the memory location of the object 
 * (indirectly in C#) instead of the direct object.
 * The difference that ref tells the compiler that the object must be initialized before passed 
 * to the method, 
 * while out tells the compiler that the object not a must to be initialized before passed
 * to the method.
*/
