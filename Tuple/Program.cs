using System;

namespace TupleReference
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_1-------------------------------------------------------------");
            //instance of the Tuple which holds a record of a person. We specified a type for each
            //element and passed values to the constructor. 
            Tuple<int, string, string> person1 = new Tuple<int, string, string>(1, "Steve", "Jobs");
            Console.WriteLine(person1.Item1); // returns 1
            Console.WriteLine(person1.Item2); // returns "Steve"
            Console.WriteLine(person1.Item3); // returns "Jobs"

            Console.WriteLine("_2-------------------------------------------------------------");
            //Specifying the type of each element is cumbersome. So, C# includes a static helper class Tuple 
            //which returns an instance of the Tuple<T> without specifying the type of each element,
            var person2 = Tuple.Create(1, "Steve", "Jobs");
            Console.WriteLine(person2.Item1); // returns 1
            Console.WriteLine(person2.Item2); // returns "Steve"
            Console.WriteLine(person2.Item3); // returns "Jobs"

            Console.WriteLine("_3-------------------------------------------------------------");
            //Return more than 7 items
            var numbers = Tuple.Create("One", 2, 3, "Four", 5, "Six", 7, 8);
            Console.WriteLine(numbers.Item1); // returns "One"
            Console.WriteLine(numbers.Item2); // returns 2
            Console.WriteLine(numbers.Item3); // returns 3
            Console.WriteLine(numbers.Item4); // returns "Four"
            Console.WriteLine(numbers.Item5); // returns 5
            Console.WriteLine(numbers.Item6); // returns "Six"
            Console.WriteLine(numbers.Item7); // returns 7
            Console.WriteLine(numbers.Rest); // returns (8)
            Console.WriteLine(numbers.Rest.Item1); // returns 8

            Console.WriteLine("_4-------------------------------------------------------------");
            //Nested Tuples placed at the end of the sequence so that it can be accessed using the Rest property.
            //(recommended).
            var numbersNested1 = Tuple.Create(1, 2, 3, 4, 5, 6, 7, Tuple.Create(8, 9, 10, 11, 12, 13));
            Console.WriteLine(numbersNested1.Item1); // returns 1
            Console.WriteLine(numbersNested1.Item7); // returns 7
            Console.WriteLine(numbersNested1.Rest.Item1); //returns (8, 9, 10, 11, 12, 13)
            Console.WriteLine(numbersNested1.Rest.Item1.Item1); //returns 8
            Console.WriteLine(numbersNested1.Rest.Item1.Item2); //returns 9

            Console.WriteLine("_5-------------------------------------------------------------");
            //Nested Tuples placed anywhere of the sequence (not recommended).
            var numbersNested2 = Tuple.Create(1, 2, Tuple.Create(3, 4, 5, 6, 7, 8), 9, 10, 11, 12, 13);

            Console.WriteLine(numbersNested2.Item1); // returns 1
            Console.WriteLine(numbersNested2.Item2); // returns 2
            Console.WriteLine(numbersNested2.Item3); // returns (3, 4, 5, 6, 7,  8)
            Console.WriteLine(numbersNested2.Item3.Item1); // returns 3
            Console.WriteLine(numbersNested2.Item4); // returns 9
            Console.WriteLine(numbersNested2.Rest.Item1); //returns 13

            Console.WriteLine("_6-------------------------------------------------------------");
            //Calling method and pass a tuple as an argument
            DisplayTuple(person1);

            Console.WriteLine("_7-------------------------------------------------------------");
            //Returning tuple from a method
            var person3 = GetPerson();
            Console.WriteLine(person3.Item1); 
            Console.WriteLine(person3.Item2); 
            Console.WriteLine(person3.Item3); 
        }

        //A method that has a tuple as a parameter.
        static void DisplayTuple(Tuple<int, string, string> person)
        {
            Console.WriteLine($"Id = { person.Item1}");
            Console.WriteLine($"First Name = { person.Item2}");
            Console.WriteLine($"Last Name = { person.Item3}");
        }

        //A method that returns a Tuple.
        static Tuple<int, string, string> GetPerson()
        {
            return Tuple.Create(1, "Bill", "Gates");
        }
    }
}
/* The Tuple<T> class was introduced in .NET Framework 4.0. A tuple is a data structure that contains a 
 * sequence of elements of different data types. It can be used where you want to have a data structure to 
 * hold an object with properties, but you don't want to create a separate type for it.
 * 
 * A tuple can only include maximum eight elements. It gives a compiler error when you try to include more 
 * than eight elements.
 * 
 * The elements of a tuple can be accessed with Item<elementNumber> properties e.g. Item1, Item2, Item3 and 
 * so on up to Item7 property. The Item1 property returns the first element, Item2 returns the second element 
 * and so on. The last element (the 8th element) will be returned using the Rest property.
 * 
 * Generally, the 8th position is for the nested tuple which you can access using the Rest property.
 * 
 * If you want to include more than eight elements in a tuple, you can do that by nesting another tuple 
 * object as the eighth element. The last nested tuple can be accessed using the Rest property. 
 * To access the nested tuple's element, use the Rest.Item1.Item<elelementNumber> property.
 * 
 * A method can have a tuple as a parameter.
 * 
 * A Tuple can be return from a method.
 * 
 * Tuples can be used in the following scenarios:
 *  When you want to return multiple values from a method without using ref or out parameters.
 *  When you want to pass multiple values to a method through a single parameter.
 *  When you want to hold a database record or some values temporarily without creating a separate class.
 * 
 * Tuple Limitations:
 *  Tuple is a reference type and not a value type. It allocates on heap and could result in CPU intensive 
 *    operations.
 *  Tuple is limited to include 8 elements. You need to use nested tuples if you need to store more elements. 
 *    However, this may result in ambiguity.
 *  Tuple elements can be accessed using properties with a name pattern Item<elementNumber> which does 
 *    not make sense.
 * 
 * C# 7 includes ValueTuple to overcome the limitations of Tuple and also makes it even easier to work with Tuple.
 * 
 */
