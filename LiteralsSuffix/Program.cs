using System;

namespace LiteralsSuffix
{
    class Program
    {
        static void Main(string[] args)
        {
            //float Alias for System.Single bet 1.5 × 10−45 and 3.4 × 1038, size: 32 bits
            float floatVar = -7.4f; //7.6 alone raises error;
            Console.WriteLine("float={0}",floatVar);
            //double Alias for System.Double 5.0 × 10−324 and 1.7 × 10308, size: 64 bits
            double doubleVar1 = -3.4, doubleVar2 = 5.1d;
            Console.WriteLine($"double1={doubleVar1},   double2={doubleVar2}");
            //decimal Alias for System.Decimal 1.0 × 10−28 and 7.9 × 1028, size: 128 bits
            decimal decimalVar1 = 3, decimalVar2 = -8.3m;  //8.3 alone raises error;
            Console.WriteLine($"decimal1={decimalVar1},   decimal2={decimalVar2}");

            //byte Alias for System.Byte integer bet 0 and 255, size: 8 bits
            byte byteVar = 200; //If exceed 255 gives compile time error
            Console.WriteLine($"sbyte={byteVar}");
            //sbyte Alias for System.SByte integer bet -128 and 127, size: 8 bits
            sbyte sbyteVar = -100;//If exceed the limits gives compile time error
            Console.WriteLine($"byte={sbyteVar}");
            //short Alias for System.Int16 integer bet -32768 and +32768, size: 16 bits
            short shortVar = -2000;
            Console.WriteLine($"short={shortVar}");
            //ushort Alias for System.UInt16 integer bet 0 and +65535, size: 16 bits
            ushort ushortVar = 20100;
            Console.WriteLine($"ushort={ushortVar}");
            //int Alias for System.Int32 integer bet 0 and +65535, size: 32 bits
            int intVar = -200500;
            Console.WriteLine($"int={intVar}");
            //uint Alias for System.UInt32 integer bet 0 and +4 294 967 295, size: 32 bits
            uint uintVar1 = 200500100, uintVar2 = 600400100u;
            Console.WriteLine($"uint1={uintVar1},   uint2={uintVar2}");
            //long Alias for System.Int64 integer 
            //bet −9 223 372 036 854 775 808 and +9 223 372 036 854 775 807, size: 64 bits
            long longVar1 = -200500100300, longVar2 = -300500400300L;
            Console.WriteLine($"long1={longVar1},   long2={longVar2}");
            //ulong Alias for System.UInt64 integer bet 0 and +18 446 744 073 709 551 615, size: 64 bits
            ulong ulongVar1 = 200500100300200, ulongVar2 = 700500100800200ul, ulongVar3 = 700700400900200Lu;
            Console.WriteLine($"long1={ulongVar1},   long2={ulongVar2},   long3={ulongVar3}");

            //char Alias for System.Char Single Unicode character, 
            //stored as integer bet 0 and 65 535, size: 16 bits
            char charVar = 'a';
            Console.WriteLine($"char={charVar}");
            //string Alias for System.String  A sequnece of characters.
            string stringVar = "Science";
            Console.WriteLine($"string={stringVar}");

            //bool Alias for System.Boolean Represents a boolean value, true or false, size: 8 bits
            bool boolVar = true;
            Console.WriteLine($"bool={boolVar}");

            //Note:- decimal is base 10, binary is base 2, octal is base 8, & hexadicemal is base 16
            //Hexadecimal litral prefixes with 0x
            int hexVar = 0x4F3A;
            Console.WriteLine($"hexToDecimal={hexVar}");
            //Octal litral prefixes with 0
            int octalVar = 0x4F3A;
            Console.WriteLine($"octalToDecimal={octalVar}");
            //Binary litral prefixes with 0b
            int binaryVar = 0b00110010;
            Console.WriteLine($"binaryToDecimal={binaryVar}");
        }
    }
}
/*C# Literals suffix samll or capital letters
  100.72f //float
  10.15 //double
  1.45d //double
  100 //decimal 
  1.44m //decimal
  e23 //exponent. Means 1023

  0x123d //hexadecimal
  072 //octal
  0b1011 //binary
  1000 //integer
  100u //uint
  1000L //long
  10ul //ulong
  100lu //ulong
 */

//A variable storing N bits enables you to represent any number between 0 and(2N − 1). 
//Any numbers above this value are too big to fit into this variable.

/*
    Implicit Numeric Conversions, TYPE CAN SAFELY BE CONVERTED TO:-
    byte==> short, ushort, int, uint, long, ulong, float, double, decimal
    sbyte==> short, int, long, float, double, decimal
    short==> int, long, float, double, decimal
    ushort==> int, uint, long, ulong, float, double, decimal
    int==> long, float, double, decimal
    uint==> long, ulong, float, double, decimal
    long==> float, double, decimal
    ulong==> float, double, decimal
    float==> double
    char==> ushort, int, uint, long, ulong, float, double, decimal
*/

/* sbyte, byte, short, ushort, int, uint, long, ulong, float, double, decimal, char, bool,
 * & DateTime are all struct type defined in System namespace.
 * string & object are calsss type defined in System namespace.
 */
