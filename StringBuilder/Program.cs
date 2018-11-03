using System;
using System.Text;

namespace StringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare & initializes a StringBuilder object sb, and append a string later
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            //Declare & initializes a StringBuilder object sb, and append a string in the same statement
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder("Hello World!!");

            //Declare & initializes a StringBuilder object sb, and append a string in the same statement,
            //and define the max capacity which is here is 70 char.
            System.Text.StringBuilder sb2 = new System.Text.StringBuilder("Hello World!!", 70);

            Console.WriteLine("_1-------------------------------------------------------------");
            //Add or append a string to StringBuilder. 
            sb.Append("Hello");
            //Add or append a string to StringBuilder with a newline at the end.
            sb.AppendLine(" World!!");
            sb.AppendLine("This is new line.");
            Console.WriteLine(sb);

            Console.WriteLine("_2-------------------------------------------------------------");
            //Format input string into specified format and then append it.
            System.Text.StringBuilder amountMsg = new System.Text.StringBuilder("Your total amount is ");
            amountMsg.AppendFormat("{0:C} ", 25);

            Console.WriteLine(amountMsg);

            Console.WriteLine("_3-------------------------------------------------------------");
            //Inserts the string at specified index in StringBuilder.
            sb1.Insert(5, " C#");

            Console.WriteLine(sb1);

            Console.WriteLine("_4-------------------------------------------------------------");
            //Replaces all occurance of a specified string with a specified replacement string.
            sb1.Replace("C#", "JavaScript ");

            Console.WriteLine(sb1);

            Console.WriteLine("_5-------------------------------------------------------------");
            //Removes the string at specified index with specified length.
            sb1.Remove(6, 10);

            Console.WriteLine(sb1);

            Console.WriteLine("_6-------------------------------------------------------------");
            //Uses indexer to get all the characters of StringBuilder using for loop.
            for (int i = 0; i < sb1.Length; i++)
                Console.Write(sb1[i]);

            Console.WriteLine("");
            Console.WriteLine("_7-------------------------------------------------------------");
            //Use ToString() method to get string from StringBuilder.
            string str = sb1.ToString();

            Console.WriteLine(str);
        }

    }
}
/*
 * StringBuilder class represents a mutable string of characters.
 * 
 * A String is immutable, meaning String cannot be changed once created. For example, 
 * new string "Hello World!!" will occupy a memory space on the heap. Now, by changing 
 * the initial string "Hello World!!" to "Hello World!! from Tutorials Teacher" will 
 * create a new string object on the memory heap instead of modifying the initial string 
 * at the same memory address. This behaviour will hinder the performance if the same 
 * string changes multiple times by replacing, appending, removing or inserting new 
 * strings in the initial string.
 * 
 * Although StringBuilder and String both represent sequences of characters, they are 
 * implemented differently. String is an immutable type. That is, each operation that 
 * appears to modify a String object actually creates a new string.
 * 
 * To solve this problem, C# introduced StringBuilder. StringBuilder is a dynamic object 
 * that allows you to expand the number of characters in the string. It doesn't create a 
 * new object in the memory but dynamically expands memory to accommodate the modified string.
 * 
 * StringBuilder is in namespace System.Text
 * 
 * StringBuilder performs faster than string when concatenating multiple strings. 
 * Use StringBuilder if you want to append more than three-four string. Appending two 
 * or three string is more efficient than using StringBuilder.
 * 
 * For routines that perform extensive string manipulation (such as apps that modify a 
 * string numerous times in a loop), modifying a string repeatedly can exact a significant 
 * performance penalty. The alternative is to use StringBuilder, which is a mutable string 
 * class. Mutability means that once an instance of the class has been created, it can be 
 * modified by appending, removing, replacing, or inserting characters. A StringBuilder 
 * object maintains a buffer to accommodate expansions to the string. New data is appended 
 * to the buffer if room is available; otherwise, a new, larger buffer is allocated, data 
 * from the original buffer is copied to the new buffer, and the new data is then appended 
 * to the new buffer.
 * 
 * Although the StringBuilder class generally offers better performance than the String class,
 * you should not automatically replace String with StringBuilder whenever you want to 
 * manipulate strings. Performance depends on the size of the string, the amount of 
 * memory to be allocated for the new string, the system on which your app is executing, 
 * and the type of operation. You should be prepared to test your app to determine whether 
 * StringBuilder actually offers a significant performance improvement.
 * 
 * Consider using the String class under these conditions:
 *      When the number of changes that your app will make to a string is small. 
 *        In these cases, StringBuilder might offer negligible or no performance improvement 
 *        over String.
 *      When you are performing a fixed number of concatenation operations, particularly 
 *        with string literals. In this case, the compiler might combine the concatenation 
 *        operations into a single operation.
 *      When you have to perform extensive search operations while you are building your 
 *        string. The StringBuilder class lacks search methods such as IndexOf or StartsWith. 
 *        You'll have to convert the StringBuilder object to a String for these operations, 
 *        and this can negate the performance benefit from using StringBuilder. 
 *      
 * Consider using the StringBuilder class under these conditions:
 *      When you expect your app to make an unknown number of changes to a string at 
 *        design time (for example, when you are using a loop to concatenate a random 
 *        number of strings that contain user input).
 *      When you expect your app to make a significant number of changes to a string.
 *
 * How StringBuilder works:
 *      The StringBuilder.Length property indicates the number of characters the 
 *      StringBuilder object currently contains. If you add characters to the StringBuilder 
 *      object, its length increases until it equals the size of the StringBuilder.Capacity 
 *      property, which defines the number of characters that the object can contain. 
 *      If the number of added characters causes the length of the StringBuilder object 
 *      to exceed its current capacity, new memory is allocated, the value of the Capacity 
 *      property is doubled, new characters are added to the StringBuilder object, and its 
 *      Length property is adjusted. Additional memory for the StringBuilder object is 
 *      allocated dynamically until it reaches the value defined by the StringBuilder.
 *      MaxCapacity property. When the maximum capacity is reached, no further memory can be 
 *      allocated for the StringBuilder object, and trying to add characters or expand it 
 *      beyond its maximum capacity throws either an ArgumentOutOfRangeException or 
 *      an OutOfMemoryException exception.
 * 
 * The default capacity of a StringBuilder object is 16 characters, and its default maximum 
 * capacity is Int32.MaxValue. These default values are used if you call the StringBuilder() 
 * and StringBuilder(String) constructors.
 * 
 * Even for a large "chunky" StringBuilder object, using the Chars[Int32] property for 
 * index-based access to one or a small number of characters has a negligible performance 
 * impact; typically, it is an 0(n) operation. The significant performance impact occurs 
 * when iterating the characters in the StringBuilder object, which is an O(n^2) operation.
 * 
 * The AppendFormat method appends a to a StringBuilder object. The string representations of 
 * objects included in the result string can reflect the formatting conventions of the 
 * current system culture or a specified culture.
 * 
 * Searching the text in a StringBuilder object
 *  The StringBuilder class does not include methods similar to the String.Contains, 
 *  String.IndexOf, and String.StartsWith methods provided by the String class, which allow 
 *  you to search the object for a particular character or a substring. Determining the 
 *  presence or starting character position of a substring requires that you search 
 *  a String value by using either a string search method or a regular expression method. 
 *  There are four ways to implement such searches, as the following table shows.
 *  Technique	                                Pros	                               Cons
 *  
 *  Search string values before                 Useful for determining whether          Cannot be used when the index 
 *  adding them to the StringBuilder            a substring exists.	                    position of a substring is important.
 *  object.
 *  
 *  Call ToString and search the 	            Easy to use if you assign all the   	Cumbersome to repeatedly call ToString 
 *  returned String object.                     text to a StringBuilder object,         if you must make modifications before all 
 *                                              and then begin to modify it.            text is added to the StringBuilder object.
 *                                                                                      You must remember to work from the end of     
 *                                                                                      the StringBuilder object's text if you're 
 *                                                                                      making changes.
 *                                                                                      
 *  Use the Chars[Int32] property to 	        Useful if you're concerned with 	    Cumbersome if the number of characters to 
 *  sequentially search a range of              individual characters or a small        search is large or if the search logic is 
 *  characters.                                 substring.                              complex.
 *                                                                                      Results in very poor performance 
 *                                                                                      for objects that have grown very 
 *                                                                                      large through repeated method calls.
 *                                                                                      
 *  Convert the StringBuilder object to      	Useful if the number of 	            Negates the performance benefit of the 
 *  a String object, and perform                modifications is small.                 StringBuilder class if the number of 
 *  modifications on the String object.                                                 modifications is large.                                                        
 * 
 * 
 * You must convert the StringBuilder object to a String object before you can pass the string 
 * represented by the StringBuilder object to a method that has a String parameter or display 
 * it in the user interface. You perform this conversion by calling the StringBuilder.
 * ToString method. 
 * 
 * Points to Remember :
 *      StringBuilder is mutable.
 *      StringBuilder performs faster than string when appending multiple string values.
 *      Initialize StringBuilder as class e.g. StringBuilder sb = new StringBuilder()
 *      Use StringBuilder when you need to append more than three or four strings.
 *      Use Append() method to add or append strings with StringBuilder.
 *      Use ToString() method to get the string from StringBuilder.
 * 
 */
