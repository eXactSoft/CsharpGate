using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaSelectOneParam
{
    class Program
    {
        /*
         * We create a collection, containing data from a certain class. 
         * In the example, from the class Cat (with properties Name and Age), 
         * we want to get a list that contains all the dog's names. With the keyword var, 
         * we tell the compiler to define the type of the variable depending on the result 
         * that we assigned on the right side of the equals sign.
         */
        static void Main(string[] args)
        {
            List<Cat> cats = new List<Cat>() {
                new Cat { Name = "Catty", Age = 4 },
                new Cat { Name = "Jerrys", Age = 0 },
                new Cat { Name = "Nancy", Age = 3 }
                };

            //Select the items of the collection names based on the Name property of cats
            var names = cats.Select(x => x.Name);

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        class Cat
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
/*-----Type Inference in Lambdas-----
When writing lambdas, you often do not have to specify a type for the input 
parameters because the compiler can infer the type based on the lambda body, 
the parameter’s delegate type, and other factors as described 
in the C# Language Specification. For most of the standard query operators, 
the first input is the type of the elements in the source sequence. 
So if you are querying an IEnumerable<Customer>, 
then the input variable is inferred to be a Customer object, 
which means you have access to its methods and properties:-

customers.Where(c => c.City == "London");  

The general rules for lambdas are as follows:

1)-The lambda must contain the same number of parameters as the delegate type.

2)-Each input parameter in the lambda must be implicitly convertible to its     
   corresponding delegate parameter.

3)-The return value of the lambda (if any) must be implicitly convertible to the 
   delegate's return type.

Note that:- lambda expressions in themselves do not have a type because the common 
type system has no intrinsic concept of "lambda expression." However, 
it is sometimes convenient to speak informally of the "type" of a lambda expression. 
In these cases the type refers to the delegate type or Expression type to which the 
lambda expression is converted.

*/