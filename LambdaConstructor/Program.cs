using System;

namespace LambdaConstructor
{
    class Program
    {
        static void Main(string[] args)
        {
            Location loc = new Location("Red Sea");
            Console.WriteLine($"The location is:- {loc.Name}");
        }
    }
    public class Location
    {
        //Constructor using lambda expression supproted from C# 7.0
        public Location(string name) => Name = name;

/*      The above contructor is the same as
        public Location(string name)
        {
            Name = name;
        }
*/
        public string Name { get; set; }
    }
}
