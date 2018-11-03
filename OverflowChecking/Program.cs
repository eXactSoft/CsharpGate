using System;

namespace OverflowChecking
{
    class Program
    {
        static void Main(string[] args)
        {
            byte destinationVar;
            short sourceVar = 281;
            Console.WriteLine($"sourceVar val: {sourceVar}");

            /* Without checked
             * 
             * What happened? Well, look at the binary representations of these two numbers, 
             * along with the maximum value that can be stored in a byte, which is 255:
                    281 = 100011001
                    25 = 000011001
                    255 = 011111111
             * You can see that the leftmost bit of the source data has been lost.
             */
            destinationVar = (byte)sourceVar;
            //Same result
            //destinationVar = unchecked((byte)sourceVar);
            Console.WriteLine($"destinationVar val without checked: {destinationVar}");

            //With checked ==> raises an OverflowException
            destinationVar = checked((byte)sourceVar);
            Console.WriteLine($"destinationVar val with checked: {destinationVar}");

            /* The Convert and Parse methods always do an overflow check
             * destinationVar = Convert.ToByte(sourceVar);
             * destinationVar = byte.Parse(sourceVar.ToString());
             */ 
        }
    }
}
