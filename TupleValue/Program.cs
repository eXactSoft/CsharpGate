using System;

namespace TupleValue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_1-------------------------------------------------------------");
            //It can be created and initialized using parentheses() and specifying the values between them.
            var person = (1, "Bill", "Gates");
            //equivalent Tuple
            //var person = Tuple.Create(1, "Bill", "Gates");
            Console.WriteLine(person.Item1); // returns 1
            Console.WriteLine(person.Item2); // returns "Bill"
            Console.WriteLine(person.Item3); // returns "Gates"

            Console.WriteLine("_2-------------------------------------------------------------");
            //ValueTuple can also be initialized by specifying the type of each element, as shown below.
            (int, string, string) person1 = (1, "Bill", "Gates");
            //equivalent Tuple
            // ValueTuple<int, string, string> person1 = (1, "Bill", "Gates");
            Console.WriteLine(person1.Item1); // returns 1
            Console.WriteLine(person1.Item2); // returns "Bill"
            Console.WriteLine(person1.Item3); // returns "Gates"

            Console.WriteLine("_3-------------------------------------------------------------");
            //We can assign names to ValueTuple properties instead of having the default property names 
            //Item1, Item2 and so on.
            (int Id, string FirstName, string LastName) person2 = (1, "Bill", "Gates");
            Console.WriteLine(person2.Id);   // returns 1
            Console.WriteLine(person2.FirstName);  // returns "Bill"
            Console.WriteLine(person2.LastName); // returns "Gates"

            Console.WriteLine("_4-------------------------------------------------------------");
            //We can also assign member names at the right side with values, as below.
            var person3 = (Id: 1, FirstName: "Bill", LastName: "Gates");
            Console.WriteLine(person3.Id);   // returns 1
            Console.WriteLine(person3.FirstName);  // returns "Bill"
            Console.WriteLine(person3.LastName); // returns "Gates"

            Console.WriteLine("_5-------------------------------------------------------------");
            //Please note that we can provide member names either at the left side or at the right side but 
            //not at both side. The left side has precedence over the left side. The following will ignore
            //names at the right side.

            // PersonId, FName, LName will be ignored.
            (int Id, string FirstName, string LastName) person4 = (PersonId: 1, FName: "Bill", LName: "Gates");
            Console.WriteLine(person4.Id);   // cannot use person4.PersonId
            Console.WriteLine(person4.FirstName);  // cannot use person4.FName
            Console.WriteLine(person4.LastName); // cannot use person4.LName

            // PersonId, FirstName, LastName will be ignored. It will have the default names: Item1, Item2, Item3.
            (int, string, string) person5 = (Id: 1, FirstName: "Bill", LastName: "Gates");
            Console.WriteLine(person5.Item1);   // cannot use person4.PersonId
            Console.WriteLine(person5.Item2);  // cannot use person4.FirstName
            Console.WriteLine(person5.Item3); // cannot use person4.LastName

            Console.WriteLine("_6-------------------------------------------------------------");
            //You can also assign variables as member values.
            string firstName = "Bill", lastName = "Gates";
            int id = 1;
            var person6 = (Id: id, FirstName: firstName, LastName: lastName);
            Console.WriteLine(person6.Id);   
            Console.WriteLine(person6.FirstName); 
            Console.WriteLine(person6.LastName);

            Console.WriteLine("_7-------------------------------------------------------------");
            //Calling method and pass a ValueTuple as an argument
            DisplayTuple((1, "Bill", "Gates"));

            Console.WriteLine("_8-------------------------------------------------------------");
            //Returning ValueTuple from a method
            var person7 = GetPerson();
            Console.WriteLine(person7.Item1);
            Console.WriteLine(person7.Item2);
            Console.WriteLine(person7.Item3);

            Console.WriteLine("_9-------------------------------------------------------------");
            // Individual members of a ValueTuple can be retrieved by deconstructing it

            // change property names
            (int PersonId, string FName, string LName) person8 = GetPerson();
            Console.WriteLine(person8.PersonId);
            Console.WriteLine(person8.FName);
            Console.WriteLine(person8.LName);

            // change property names by using var instead of explicit data type names.
            /* use var as datatype
            (var PersonId, var FName, var LName) person9= GetPerson();
            Console.WriteLine(person9.PersonId);
            Console.WriteLine(person9.FName);
            Console.WriteLine(person9.LName);
            */

            //Console.WriteLine("_10-------------------------------------------------------------");
            //ValueTuple also allows "discards" in deconstruction for the members you are not going to use.
            // use discard _ for the unused member LName
            //(int pID, string fName, _ ) person10= GetPerson();
        }

        //A method that has a ValueTuple as a parameter.
        static void DisplayTuple((int, string, string) person)
        {
            Console.WriteLine($"Id = { person.Item1}");
            Console.WriteLine($"First Name = { person.Item2}");
            Console.WriteLine($"Last Name = { person.Item3}");
        }

        //A method that returns a ValueTuple.
        static (int, string, string) GetPerson()
        {
            return (1, "Bill", "Gates");
            //return (Id: 1, FirstName: "Bill", LastName: "Gates"); will ignore Id, FirstName, LastName
        }
    }
}
/* C# 7.0 (.NET Framework 4.7) introduced ValueTuple, a structure which is a value type representation of the 
 * Tuple.
 * 
 * The ValueTuple is only available in .NET Framework 4.7. If you don't see ValueTuple in your project then 
 * you need to install the ValueTuple. (.NET Framework 4.7 or higher, or .NET Standard Library 2.0 or higher 
 * already includes ValueTuple.)
 * 
 * To install the ValueTuple package, right click on the project in the solution explorer and select Manage 
 * NuGet Packages... This will open the NuGet Package Manager. Click the Browse tab, search for ValueTuple in 
 * the search box and select the System.ValueTuple package, as shown below.
 * 
 * Tuple requires at least two values. The following is NOT a tuple.
        var number = (1);  // int type, NOT a tuple
        var numbers = (1,2); //valid tuple
 * 
 * Unlike Tuple, a ValueTuple can include more than eight values.
        var numbers = (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14); 
 * 
 * We can assign names to ValueTuple properties instead of having the default property names 
 * Item1, Item2 and so on.
 * 
 * Individual members of a ValueTuple can be retrieved by deconstructing it. A deconstructing 
 * declaration syntax splits a ValueTuple into its parts and assigns those parts individually 
 * to fresh variables.
 * 
 * 
 */
