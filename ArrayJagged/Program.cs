using System;

namespace ArrayJagged
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_1-------------------------------------------------------------");
            int[][,] intJaggedArray = new int[3][,];

            intJaggedArray[0] = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            intJaggedArray[1] = new int[2, 2] { { 3, 4 }, { 5, 6 } };
            intJaggedArray[2] = new int[2, 2]; //Set the default value of int ==> 0

            Console.WriteLine(intJaggedArray[0][1, 1]); // 4
            Console.WriteLine(intJaggedArray[1][1, 0]); // 5
            Console.WriteLine(intJaggedArray[1][1, 1]); // 6

            Console.WriteLine("_2-------------------------------------------------------------");

            //To loop throug all elements of the intJaggedArray array
            foreach (int[,] divisorsOfInt in intJaggedArray)
            {
                foreach (int divisor in divisorsOfInt)
                {
                    Console.WriteLine(divisor);
                }
            }
        }
    }
}
/*
 * A jagged array is an array of an array. Jagged arrays store arrays instead of any 
 * other data type value directly.
 * A jagged array is initialized with two square brackets [][]. 
 * The first bracket specifies the size of an array and the second bracket specifies 
 * the dimension of the array which is going to be stored as values. 
 * (Remember, jagged array always store an array.)
 * 
 * have jagged arrays, whereby “rows” may be varied sizes. For this, you need an
 * array in which each element is another array.
 * 
 * The syntax for declaring arrays of arrays involves specifying multiple sets of square brackets in the
 * 
    Declaration of the array, as shown here:
        int[][] jaggedIntArray;
    Unfortunately, initializing arrays such as this isn’t as simple as initializing multidimensional arrays.
    You can’t, for example, follow the preceding declaration with this:
        jaggedIntArray = new int[3][4];
    Even if you could do this, it wouldn’t be that useful because you can achieve the same effect with
    simple multidimensional arrays with less effort. Nor can you use code such as this:
        jaggedIntArray = { { 1, 2, 3 }, { 1 }, { 1, 2 } };
    You have two options. You can initialize the array that contains other arrays (let’s call these subarrays
    for clarity) and then initialize the sub-arrays in turn:
        jaggedIntArray = new int[2][];
        jaggedIntArray[0] = new int[3];
        jaggedIntArray[1] = new int[4];
    Alternatively, you can use a modified form of the preceding literal assignment:
        jaggedIntArray = new int[3][] { new int[] { 1, 2, 3 }, new int[] { 1 },
        new int[] { 1, 2 } };
    This can be simplified if the array is initialized on the same line as it is declared, as follows:
        int[][] jaggedIntArray = { new int[] { 1, 2, 3 }, new int[] { 1 },
        new int[] { 1, 2 } };
    You can use foreach loops with jagged arrays, but you often need to nest these to get to the actual
    data. For example, suppose you have the following jagged array that contains 10 arrays, each of
    which contains an array of integers that are divisors of an integer between 1 and 10:
        int[][] divisors1To10 = { new int[] { 1 },
        new int[] { 1, 2 },
        new int[] { 1, 3 },
        new int[] { 1, 2, 4 },
        new int[] { 1, 5 },
        new int[] { 1, 2, 3, 6 },
        new int[] { 1, 7 },
        new int[] { 1, 2, 4, 8 },
        new int[] { 1, 3, 9 },
        new int[] { 1, 2, 5, 10 } };
    The following code will fail:
        foreach (int divisor in divisors1To10)
        {
            WriteLine(divisor);
        }
    The failure occurs because the array divisors1To10 contains int[] elements, not int elements.
    Instead, you must loop through every sub-array, as well as through the array itself:
        foreach (int[] divisorsOfInt in divisors1To10)
        {
            foreach(int divisor in divisorsOfInt)
            {
                 WriteLine(divisor);
            }
        }

    As you can see, the syntax for using jagged arrays can quickly become complex! In most cases, it is
    easier to use rectangular arrays or a simpler storage method. Nonetheless, there may well be situations
    in which you are forced to use this method, and a working knowledge can’t hurt. An example
    of this happens when working with XML documents where some elements have sub-children and
    other do not.
 * 
 */
