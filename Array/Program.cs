using System;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1st method of istantiate (delare & initialize) an array with size 5. add values later on
            int[] intArray1 = new int[5];

            // 2nd method of declare the array in a separate line
            // & initialize that array in another line with size 5. add values later on
            int[] intArray2;
            intArray2 = new int[5];

            // 3rd method of istantiate (delare & initialize) an array with size 5
            int[] intArray3 = new int[5] { 1, 2, 3, 4, 5 };

            // 4th method of declare the array in a separate line
            // & initialize that array in another line with size 5. 
            int[] intArray4;
            intArray4 = new int[5] { 1, 2, 3, 4, 5 };

            // 5th method of istantiate (delare & initialize) an array with size 5 (easiest way)
            int[] intArray5 = { 1, 2, 3, 4, 5 };

            /* The 5th method cannot be c/o with 2 separate lines so the following is forbiden:
             * int[] intArray5;
             * intArray5 = { 1, 2, 3, 4, 5 };
             */

            // 6th method use a variable to initialize the array size, add values later on
            int arraySize = 5;
            int[] intArray6 = new int[arraySize] ;

            // 7th method of declare the array in a separate line
            // & initialize that array in another line with size arrySize. add values later on
            int[] intArray7;
            intArray7 = new int[arraySize];

            // 8th method use a constant variable to initialize the array size, it must be a constant
            const int arraySizeConst = 5;
            int[] intArray8 = new int[arraySizeConst] { 1, 2, 3, 4, 5 };

            // 9th method of declare the array in a separate line
            // & initialize that array in another line with size arraySizeConst. 
            // Add values later on. The arraySizeConst variable must be constant.
            int[] intArray9;
            intArray9 = new int[arraySizeConst] { 1, 2, 3, 4, 5 };

            Console.WriteLine("_1-------------------------------------------------------------");
            // You can loop through array elements by for loop.
            // By using Array property Length.
            for (int i = 0; i < intArray3.Length; i++)
            {
                Console.WriteLine(intArray3[i]);
            }

            Console.WriteLine("_2-------------------------------------------------------------");
            // The easiest simplest syntax to loop through array elements is by foreach loop.
            foreach (int item in intArray8)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("_3-------------------------------------------------------------");
            // Returns the number of elements in the specified dimension (intArray4 is 1 dim).
            Console.WriteLine(intArray4.GetLength(0));

            Console.WriteLine("_4-------------------------------------------------------------");
            // Returns the lowest index of the specified dimension (intArray4 is 1 dim).
            Console.WriteLine(intArray4.GetLowerBound(0));

            Console.WriteLine("_5-------------------------------------------------------------");
            // Returns the highest index of the specified dimension (intArray4 is 1 dim).
            Console.WriteLine(intArray4.GetUpperBound(0));

            Console.WriteLine("_6-------------------------------------------------------------");
            // Returns the value at the specified index 1st method.
            Console.WriteLine(intArray4[2]);

            Console.WriteLine("_7-------------------------------------------------------------");
            // Returns the value at the specified index 2nd method.
            Console.WriteLine(intArray4.GetValue(2));

            Console.WriteLine("_8-------------------------------------------------------------");
            // Sorting the values of an array using Array Helper class
            System.Array.Sort(intArray8); //Here also note how array as an argument to a method 
            foreach (int item in intArray8)
                Console.WriteLine(item);

            Console.WriteLine("_9-------------------------------------------------------------");
            // Reversing the values of an array using Array Helper class
            System.Array.Reverse(intArray8);
            foreach (int item in intArray8)
                Console.WriteLine(item);

            Console.WriteLine("_10-------------------------------------------------------------");
            // Resize the array to a bigger size (five elements larger).
            System.Array.Resize(ref intArray7, intArray7.Length + 5);
            Console.WriteLine($"The new size of the array intArray7 is {intArray7.Length}");

            Console.WriteLine("_11-------------------------------------------------------------");
            // Copies the first 3 elements from the intArray8 to the intArray3 array.
            System.Array.Copy(intArray8, intArray3, 3);
            foreach (int item in intArray3)
                Console.WriteLine(item);

            Console.WriteLine("_12-------------------------------------------------------------");
            // Copies the last two elements from the intArray8 array to the intArray3 array.
            System.Array.Copy(intArray8, intArray8.GetUpperBound(0) - 1, intArray3, intArray3.GetUpperBound(0) - 1, 2);
            foreach (int item in intArray3)
                Console.WriteLine(item);

            Console.WriteLine("_13-------------------------------------------------------------");
            // Shallow copy of the array intArray8 to array intArray10
            int[] intArray10 = (int[]) intArray8.Clone();
            foreach (int item in intArray10)
                Console.WriteLine(item);

            Console.WriteLine("_14-------------------------------------------------------------");
            // Find the first int for which its value > 3, 
            // And as parameter to Find() method use Predicate delegate with lambda expression procedure 
            int first = System.Array.Find(intArray5, intVal => intVal > 3);
            Console.WriteLine($"The first element of the int array with value > 3 is: {first}");

            Console.WriteLine("_15-------------------------------------------------------------");
            // Find the all the int values af an array elements for which its value > 3, 
            // And as parameter to Find() method use Predicate delegate with lambda expression procedure 
            int[] matchedItems = System.Array.FindAll(intArray5, intVal => intVal > 3);
            Console.WriteLine($"The elements of the int array with value > 3 are:  ");
            foreach (int item in matchedItems)
                  Console.WriteLine(item);
         }
    }
}
/* 
 * Points to Remember :
 *   An Array stores values in a series starting with a zero-based index.
 *   The size of an array must be specified while initialization.
 *   An Array values can be accessed using indexer.
 *   An Array can be single dimensional, multi-dimensional and jagged array.
 *   The Array helper class includes utility methods for arrays.
 *   
 * A variable can hold only one literal value, for example int x = 1; . 
 * Only one literal value can be assigned to a variable x. 
 * Suppose, you want to store 100 different values then it will be cumbersome 
 * to create 100 different variables. To overcome this problem, C# introduced an array.
 * 
 * An array is a special type of data type which can store fixed number of values 
 * sequentially using special syntax.
 * You can store a fixed number of values in an array. Array index will 
 * be increased by 1 sequentially till the maximum specified array size.
 * Index is a number starting from 0.
 * 
 * Arrays can be initialized after declaration. It is not necessary to declare and initialize 
 * at the same time using new keyword. 
 * However, in the case of late initialization, it must be initialized with the new keyword as above. 
 * It cannot be initialize by only assigning values to the array.
 * 
 * .NET provides an abstract class, Array, as a base class for all arrays. It provides static methods 
 * for creating, manipulating, searching, and sorting arrays.
 * The Array class is not part of the System.Collections namespaces. However, it is still considered 
 * a collection because it is based on the IList interface.
 * 
 * A shallow copy of an Array copies only the elements of the Array, whether they 
 * are reference types or value types, but it does not copy the objects that the references 
 * refer to. The references in the new Array point to the same objects that the references 
 * in the original Array point to.
 * In contrast, a deep copy of an Array copies the elements and everything directly 
 * or indirectly referenced by the elements.
 * 
 * In Array.Copy() if sourceArray and destinationArray are both reference-type arrays or 
 * are both arrays of type Object, a shallow copy is performed. A shallow copy of an Array 
 * is a new Array containing references to the same elements as the original Array. 
 * The elements themselves or anything referenced by the elements are not copied. 
 * In contrast, a deep copy of an Array copies the elements and everything directly 
 * or indirectly referenced by the elements.
 * 
 * Array.Resize() method changes the number of elements of a one-dimensional array to 
 * the specified new size.
 * The Resize method resizes a one-dimensional array only. The Array class does not include 
 * a method for resizing multi-dimensional arrays.
 * 
 * This method allocates a new array with the specified size, copies elements from the 
 * old array to the new one, and then replaces the old array with the new one. array 
 * must be a one-dimensional array.
 * 
 * If array is null, this method creates a new array with the specified size.
 * If newSize is greater than the Length of the old array, a new array is allocated 
 * and all the elements are copied from the old array to the new one. 
 * If newSize is less than the Length of the old array, a new array is allocated 
 * and elements are copied from the old array to the new one until the new one is filled; 
 * the rest of the elements in the old array are ignored. If newSize is equal to 
 * the Length of the old array, this method does nothing.
 * 
 * This method is an O(n) operation, where n is newSize.
 */
