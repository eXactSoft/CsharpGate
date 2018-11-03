using System;

namespace CollectionsCustom
{
    class Program
    {
        static void Main(string[] args)
        {
            var colors = new AllColors();

            foreach (Color theColor in colors)
            {
                Console.WriteLine(theColor.Name);
            }
            // Output: red blue green  
        }
    }

    // Custom Collection class.  
    public class AllColors : System.Collections.IEnumerable
    {
        Color[] _colors =
        {
        new Color() { Name = "red" },
        new Color() { Name = "blue" },
        new Color() { Name = "green" }
    };

        public System.Collections.IEnumerator GetEnumerator()
        {
            return new ColorEnumerator(_colors);

            // Instead of creating a custom enumerator, you could  
            // use the GetEnumerator of the array.  
            //return _colors.GetEnumerator();  
        }

        // Custom enumerator.  
        private class ColorEnumerator : System.Collections.IEnumerator
        {
            private Color[] _colors;
            private int _position = -1;

            public ColorEnumerator(Color[] colors)
            {
                _colors = colors;
            }

            object System.Collections.IEnumerator.Current
            {
                get
                {
                    return _colors[_position];
                }
            }

            bool System.Collections.IEnumerator.MoveNext()
            {
                _position++;
                return (_position < _colors.Length);
            }

            void System.Collections.IEnumerator.Reset()
            {
                _position = -1;
            }
        }
    }

    // Element class.  
    public class Color
    {
        public string Name { get; set; }
    }
}
/*
 * You can define a collection by implementing the IEnumerable<T> or IEnumerable interface.
 * 
 * Although you can define a custom collection, it is usually better to instead use the 
 * collections that are included in the .NET Framework.
 * 
 * This project defines a custom collection class named AllColors. 
 * This class implements the IEnumerable interface, which requires that the 
 * GetEnumerator method be implemented.
 * 
 * The GetEnumerator method returns an instance of the ColorEnumerator class. 
 * ColorEnumerator implements the IEnumerator interface, which requires that the 
 * Current property, MoveNext method, and Reset method be implemented.
 * 
 * IEnumerator interface (that the custom class Collection implements) has three 
 * methods that are needed to be implemented in the child class.
 * 'IEnumerator.Current', 'IEnumerator.MoveNext()', & 'IEnumerator.Reset()'
 * 
 * MoveNext method it returns false only if the counter does not match the count of the list. 
 * 
 * Custom collection lass needs to have GetEnumerator method for it to be iterative. 
 * So it is required to implement  GetEnumerator() method into the the custom Collection 
 * Class.
 * 
 */
