using System;
using System.Drawing;

namespace DelegateBuiltInPredicate02
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an array of Point structures.
            Point[] points = { new Point(100, 200),
                         new Point(150, 250), new Point(250, 375),
                         new Point(275, 395), new Point(295, 450) };

            //Predicate Delegate declaration and initialized with the named method FindPoints().
            Predicate<Point> predicateWithNamedMethod = FindPoints;

            //Declare th variable first of type Point
            Point first;

            // Find the first Point structure for which X times Y  
            // is greater than 100000. 
            // Passing the predicateWithNamedMethod as a parameter to the Find() method.
            first = Array.Find(points, predicateWithNamedMethod);

            // Display the first structure found.
            Console.WriteLine("Found: X = {0}, Y = {1}", first.X, first.Y);

            // Find the first Point structure for which X times Y  
            // is greater than 100000. 
            // Using a lambda expression to represent the Predicate<T> delegate 
            // and pass it as parameter to the Find() method.
            first = Array.Find(points, x => x.X * x.Y > 100000);

            // Display the first structure found.
            Console.WriteLine("Found: X = {0}, Y = {1}", first.X, first.Y);
        }

        // FindPoints() method with the same signature of the delgate predicateWithNamedMethod
        private static bool FindPoints(Point obj)
        {
            return obj.X * obj.Y > 100000;
        }
    }
}
