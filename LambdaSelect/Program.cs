using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaSelectTwoParam
{
    class Program
    {
        /*
         * The newly created collection newCatsList has elements of an anonymous type 
         * taking the properties Age and FirstLetter as parameters.
         */
        static void Main(string[] args)
        {
            List<Cat> cats = new List<Cat>() {
                new Cat { Name = "Catty", Age = 4 },
                new Cat { Name = "Jerry", Age = 0 },
                new Cat { Name = "Nancy", Age = 3 }
                };

            //Instantiate new Cat objects based on the age and first letter
            var newCatsList = cats.Select(x => new { Age = x.Age, FirstLetter = x.Name[0] });

            foreach (var item in newCatsList)
            {
                Console.WriteLine(item);
            }
        }

        class Cat
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
