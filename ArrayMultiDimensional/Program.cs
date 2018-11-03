using System;

namespace ArrayMultiDimensional
{
    class Program
    {
        static void Main(string[] args)
        {
           
            // 1st method of istantiate (delare & initialize) an array with size 3*2. add values later on
            int[,] intArray1 = new int[3,2];

            // 2nd method of istantiate (delare & initialize) an array with size 3*2.
            int[,] intArray2 = new int[3, 2] { { 10, 1 }, { 20, 2 }, { 30, 3 } };

            // 3rd method of istantiate (delare & initialize) an array with size 3*2.
            int[,] intArray3 = { { 10, 1 }, { 20, 2 }, { 30, 3 } };

            Console.WriteLine("_1-------------------------------------------------------------");
            // You can loop through array elements by 2 for loops.
            // By using Array property Length.
            for (int row = 0; row < intArray3.GetLength(0); row++)
            {
                for (int col = 0; col < intArray3.GetLength(1); col++)
                    Console.WriteLine($"The element[{row}, {col}] is: {intArray3[row, col]}");
            }

            Console.WriteLine("_2-------------------------------------------------------------");

            // The easiest simplest syntax to loop through array elements is by foreach loop.
            foreach (int item in intArray3)
            {
                Console.WriteLine(item);
            }

            // To istantiate (delare & initialize) an array with size 3*2*2.
            int[,,] intArray4 = {
                                { { 10, 1 }, { 20, 2 }, { 30, 3 } },
                                { { 40, 4 }, { 50, 5 }, { 60, 6 } },
                                }; //or new int[3,2,2];
            // If you want to access elements of 3-dim array, it will required a 3 for loop 
            // or on foreach loop
        }
    }
}
/*
 * A multidimensional array is simply one that uses multiple indices to access its elements.
 * 
 * A multidimensional arrays are rectangular because each row is the same dimension.
 * 
 * A two-dimensional array such as this is declared as follows: <baseType>[,] <name>;
 * Arrays of more dimensions simply require more commas: <baseType>[,,,] <name>;
 * 
 * If a multi-dimensional array is a two dimensional series like rows and columns.
 * The values of a 2-dimensional array can be accessed using two indexes. 
 * The first index is for the row and the second index is for the column. 
 * Rows and columns starts with zero index
 */
