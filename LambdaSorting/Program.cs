using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaSelectOneParam
{
    class Program
    {
        /*
         * The following is an examle of sorting with a lambda expression
         */
        static void Main(string[] args)
        {
            List<Cat> cats = new List<Cat>() {
                new Cat { Name = "Catty", Age = 4 },
                new Cat { Name = "Jerrys", Age = 0 },
                new Cat { Name = "Nancy", Age = 3 }
                };

            //Sort the elements of the cats list in a descending order according to 
            //a key TKey which is here is ths Cat object itself,
            //by passing Func<Cat, TKey> delegate initialized using lambda expression, 
            //and put them in a new collection sortedCats.
            var sortedCats = cats.OrderByDescending(x => x.Age);

            foreach (var item in sortedCats)
            {
                Console.WriteLine(string.Format("Cat {0} is {1} years old.", item.Name, item.Age));
            }
        }

        class Cat
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
