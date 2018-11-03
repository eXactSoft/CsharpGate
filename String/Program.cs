using System;

namespace String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_1-------------------------------------------------------------");
            //Specify any Unicode character using a Unicode escape sequence. 
            //These consist of the standard \ character followed by a u and 
            //a four-digit hexadecimal value(
            Console.WriteLine("Benjamin\u0027s string.");// Equivalent to "Benjamin\'s string."

            Console.WriteLine("_2-------------------------------------------------------------");
            //@"Verbatim string literal."
            Console.WriteLine(@"C:\Temp\MyDir\MyFile.doc");

            Console.WriteLine("_3-------------------------------------------------------------");
            //To get a char array that you can write to, This uses the ToCharArray() command of the array variable:
            string myString = "A string";
            //Copies the characters in the string instance myString to a Unicode character array.
            char[] myChars = myString.ToCharArray();

            //Then you can manipulate the char array the standard way.You can also use 
            //strings in foreach loops, as shown here:
            foreach (char character in myString)
                Console.WriteLine($"{character}");

            Console.WriteLine("_4-------------------------------------------------------------");
            //Get the number of elements using myString.Length. This gives you the
            //number of characters in the string:
            Console.WriteLine($"The length of the string {myString.Length} characters.");

            Console.WriteLine("_5-------------------------------------------------------------");
            //Enable strings to be converted into uppercase.
            Console.WriteLine(myString.ToUpper());
            //Enable strings to be converted into lowercase.
            Console.WriteLine(myString.ToLower());

            //ToUpper() & ToLower() method, like the others in this section, doesn’t actually change the 
            //string to which it is applied.
            Console.WriteLine(myString);

            Console.WriteLine("_6-------------------------------------------------------------");
            string userResponse = "  yes";
            Console.WriteLine(userResponse);
            //Trim an extra space at the beginning or end of the string
            userResponse = userResponse.Trim();
            Console.WriteLine(userResponse);

            Console.WriteLine("_7-------------------------------------------------------------");
            //You can also use these commands to remove any other characters, by specifying 
            //them in a char array  
            userResponse = " yeess";
            char[] trimChars = { ' ', 'e', 's' };
            Console.WriteLine(userResponse.Trim(trimChars));

            Console.WriteLine("_8-------------------------------------------------------------");
            userResponse = " yes ";
            //Trim spaces from the beginning of a string.
            Console.WriteLine(userResponse.TrimStart());
            //Trim spaces from the end of a string.
            Console.WriteLine(userResponse.TrimEnd());

            Console.WriteLine("_9-------------------------------------------------------------");
            myString = "Aligned";
            //Three spaces being added to the left of the word Aligned in myString
            Console.WriteLine(myString.PadLeft(10));
            //This would add three dashes to the start of myString.
            Console.WriteLine(myString.PadLeft(10, '-'));

            Console.WriteLine("_10-------------------------------------------------------------");
            string myString1 = "This is a test.";
            char[] separator = { ' ' };
            string[] myWords;

            //Converts a string into a string array by splitting it at the points specified.
            //These points take the form of a char array, which in this case is simply 
            //populated by a single element, the space character
            myWords = myString1.Split(separator);

            //Loop through the words in this array using foreach and write each one to the console
            foreach (string word in myWords)
                Console.WriteLine($"{word}");

            Console.WriteLine("_11-------------------------------------------------------------");
            string sentence = "This sentence has five words.";

            // Extract the second word.

            //Reports the zero-based index of the first occurrence of the specified Unicode 
            //character in this string.
            int startPosition = sentence.IndexOf(" ") + 1;

            //Retrieves a substring from this instance. The substring starts at a specified 
            //character position and has a specified length.
            string word2 = sentence.Substring(startPosition,
                                              sentence.IndexOf(" ", startPosition) - startPosition);

            // The output is: Second word: sentence
            Console.WriteLine("Second word: " + word2);


            Console.WriteLine("_12-------------------------------------------------------------");
            string strFirst = "Goodbye";
            string strSecond = "Hello";
            string strThird = "a small string";
            string strFourth = "goodbye";

            // Compare a string to itself.
            Console.WriteLine( CompareStrings(strFirst, strFirst) );
            Console.WriteLine( CompareStrings(strFirst, strSecond) );
            Console.WriteLine( CompareStrings(strFirst, strThird) );

            // Compare a string to another string that varies only by case.
            Console.WriteLine(CompareStrings(strFirst, strFourth));
            Console.WriteLine(CompareStrings(strFourth, strFirst));

            Console.WriteLine("_13-------------------------------------------------------------");
            string s1 = "The quick brown fox jumps over the lazy dog";
            string s2 = "fox";
            //Returns a value indicating whether a specified substring occurs within this string.
            Console.WriteLine( s1.Contains(s2) );
            //Determines whether the beginning of this string instance matches the specified string.
            Console.WriteLine(s1.StartsWith("Th"));
            //Determines whether the end of this string instance matches the specified string.
            Console.WriteLine(s1.EndsWith("v"));
            //Indicates whether the specified string is null or an Empty string.
            Console.WriteLine( System.String.IsNullOrEmpty(s2) );
            //Reports the zero-based index position of the last occurrence of a specified Unicode 
            //character within this instance.
            Console.WriteLine(s1.LastIndexOf('o'));
            //Return Empty string ""
            Console.WriteLine(System.String.Empty);

            Console.WriteLine("_14-------------------------------------------------------------");
            // Using Standard Numeric Format in the object's ToString method. 
            Console.WriteLine(DateTime.Now.ToString("d"));


            // Using composite formatting in the object's ToString method. 
            Console.WriteLine( DateTime.Now.ToString("dddd MMMM") );

            Console.WriteLine("_15-------------------------------------------------------------");
            // Using Standard Numeric Format in the Format method.
            //Multiple format items can refer to the same element in the 
            //list of objects by specifying the same parameter specifier.
            string multiple = System.String.Format("0x{0:X} {0:E} {0:N}",
                                Int64.MaxValue);
            Console.WriteLine(multiple);

            Console.WriteLine("_16-------------------------------------------------------------");
            //The composite format string left-aligns the names in a 20-character field, 
            //and right-aligns their hours in a 5-character field. 
            Console.WriteLine("{0,-20} {1,5}\n", "Name", "Hours");

            //Note that the "N2" standard format string is also used to format the hours 
            //with two fractional digit.
            Console.WriteLine("{0,-20} {1,5:N2}", "Adam", 40.0);

            Console.WriteLine("_17-------------------------------------------------------------");
            // WriteLine (string format, params object[] arg);
            // Format a negative integer or floating-point number in various ways.
            Console.WriteLine("Standard Numeric Format Specifiers");
            Console.WriteLine(
                "(C) Currency: . . . . . . . . {0:C}\n" +
                "(D) Decimal:. . . . . . . . . {0:D}\n" +
                "(E) Scientific: . . . . . . . {1:E}\n" +
                "(F) Fixed point:. . . . . . . {1:F}\n" +
                "(G) General:. . . . . . . . . {0:G}\n" +
                "    (default):. . . . . . . . {0} (default = 'G')\n" +
                "(N) Number: . . . . . . . . . {0:N}\n" +
                "(P) Percent:. . . . . . . . . {1:P}\n" +
                "(R) Round-trip: . . . . . . . {1:R}\n" +
                "(X) Hexadecimal:. . . . . . . {0:X}\n",
                -123, -123.45f);

            // Format the current date in various ways.
            Console.WriteLine("Standard DateTime Format Specifiers");
            Console.WriteLine(
                "(d) Short date: . . . . . . . {0:d}\n" +
                "(D) Long date:. . . . . . . . {0:D}\n" +
                "(t) Short time: . . . . . . . {0:t}\n" +
                "(T) Long time:. . . . . . . . {0:T}\n" +
                "(f) Full date/short time: . . {0:f}\n" +
                "(F) Full date/long time:. . . {0:F}\n" +
                "(g) General date/short time:. {0:g}\n" +
                "(G) General date/long time: . {0:G}\n" +
                "    (default):. . . . . . . . {0} (default = 'G')\n" +
                "(M) Month:. . . . . . . . . . {0:M}\n" +
                "(R) RFC1123:. . . . . . . . . {0:R}\n" +
                "(s) Sortable: . . . . . . . . {0:s}\n" +
                "(u) Universal sortable: . . . {0:u} (invariant)\n" +
                "(U) Universal full date/time: {0:U}\n" +
                "(Y) Year: . . . . . . . . . . {0:Y}\n",
                thisDate);

            // Format a Color enumeration value in various ways.
            Console.WriteLine("Standard Enumeration Format Specifiers");
            Console.WriteLine(
                "(G) General:. . . . . . . . . {0:G}\n" +
                "    (default):. . . . . . . . {0} (default = 'G')\n" +
                "(F) Flags:. . . . . . . . . . {0:F} (flags or integer)\n" +
                "(D) Decimal number: . . . . . {0:D}\n" +
                "(X) Hexadecimal:. . . . . . . {0:X}\n",
                Color.Green);
        }
        enum Color { Yellow = 1, Blue, Green };
        static DateTime thisDate = DateTime.Now;

        private static string CompareStrings(string str1, string str2)
        {
            // Compare the values, using the CompareTo method on the first string.
            //Compares this instance with a specified String object and indicates whether 
            //this instance precedes, follows, or appears in the same position in the sort 
            //order as the specified string.
            int cmpVal = str1.CompareTo(str2);

            if (cmpVal == 0) // The strings are the same.
                return "The strings occur in the same position in the sort order.";
            else if (cmpVal < 0)
                return "The first string precedes the second in the sort order.";
            else
                return "The first string follows the second in the sort order.";
        }
    }
}
/*
 * Strings are reference types. One consequence of this is that strings can also 
 * be assigned the value null, which means that the string variable doesn’t reference a 
 * string (or anything else, for that matter).
 * 
 *  String is an immutable type. That is, each operation that appears to modify a String 
 *  object actually creates a new string.
 * 
 * Escape Sequences for String Literals
 * ESCAPE   SEQUENCE CHARACTER PRODUCED     UNICODE (HEX) VALUE OF CHARACTER
 * \'       Single quotation mark           0x0027
 * \"       Double quotation mark           0x0022
 * \\       Backslash                       0x005C
 * \0       Null                            0x0000
 * \a       Alert (causes a beep)           0x0007
 * \b       Backspace                       0x0008
 * \f       Form feed                       0x000C
 * \n       New line                        0x000A
 * \r       Carriage return                 0x000D
 * \t       Horizontal tab                  0x0009
 * \v       Vertical tab                    0x000B
 * 
 * The Unicode Value of Character column of the preceding table shows the hexadecimal values of
 * the characters as they are found in the Unicode character set.
 * 
 * You can also specify strings verbatim. This means that all characters contained between two double
 * quotation marks are included in the string, including end-of-line characters and characters that
 * would otherwise need escaping. The only exception to this is the escape sequence for the double
 * quotation mark character, which must be specified to avoid ending the string. To do this, place the @
 * character before the string:   @"Verbatim string literal."
 * 
 * Verbatim strings are particularly useful in filenames, as these use plenty of backslash characters.
 * Using normal strings, you’d have to use double backslashes all the way along the string:
 * "C:\\Temp\\MyDir\\MyFile.doc"
 * With verbatim string literals you can make this more readable. The following verbatim string is
 * equivalent to the preceding one:
 * @"C:\Temp\MyDir\MyFile.doc"
 * 
 * Each word obtained has no spaces, either embedded in the word or at either end. 
 * The separators are removed when you use Split().
 * 
 * String.Format Method: Converts the value of objects to strings based on the formats specified 
 *                       and inserts them into another string.
 * 
 * ToString(IFormatProvider) method: Converts the value of this instance to an equivalent String 
 * using the specified culture-specific formatting information.
 * 
 *Standard Numeric Format Specifiers
 * Standard DateTime Format Specifiers
        (d) Short date: . . . . . . . 6/26/2004
        (D) Long date:. . . . . . . . Saturday, June 26, 2004
        (t) Short time: . . . . . . . 8:11 PM
        (T) Long time:. . . . . . . . 8:11:04 PM
        (f) Full date/short time: . . Saturday, June 26, 2004 8:11 PM
        (F) Full date/long time:. . . Saturday, June 26, 2004 8:11:04 PM
        (g) General date/short time:. 6/26/2004 8:11 PM
        (G) General date/long time: . 6/26/2004 8:11:04 PM
            (default):. . . . . . . . 6/26/2004 8:11:04 PM (default = 'G')
        (M) Month:. . . . . . . . . . June 26
        (R) RFC1123:. . . . . . . . . Sat, 26 Jun 2004 20:11:04 GMT
        (s) Sortable: . . . . . . . . 2004-06-26T20:11:04
        (u) Universal sortable: . . . 2004-06-26 20:11:04Z (invariant)
        (U) Universal full date/time: Sunday, June 27, 2004 3:11:04 AM
        (Y) Year: . . . . . . . . . . June, 2004
 *
 * Standard Enumeration Format Specifiers
        (G) General:. . . . . . . . . Green
            (default):. . . . . . . . Green (default = 'G')
        (F) Flags:. . . . . . . . . . Green (flags or integer)
        (D) Decimal number: . . . . . 3
        (X) Hexadecimal:. . . . . . . 00000003
 *
 * 
 */
