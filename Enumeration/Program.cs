using System;

namespace Enumeration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_1-------------------------------------------------------------");
            Console.WriteLine((int)WeekDays.Monday);
            Console.WriteLine((int)WeekDays.Friday);

            Console.WriteLine("_2-------------------------------------------------------------");
            Console.WriteLine((int)WeekDays2.Monday);
            Console.WriteLine((int)WeekDays2.Friday);


            Console.WriteLine("_3-------------------------------------------------------------");

            //Returns the name of the constant of the specified value of specified enum.
            Console.WriteLine(Enum.GetName(typeof(WeekDays), 4));

            Console.WriteLine("WeekDays constant names:");

            //Returns an array of string name of all the constant of specified enum.
            foreach (string str in Enum.GetNames(typeof(WeekDays)))
                Console.WriteLine(str);

            Console.WriteLine("-----------------------Enum.TryParse():");

            //Declare WeekDays enum object
            WeekDays wdEnum;

            //Converts the string representation of the name or numeric value of one or more 
            //enumerated constants to an equivalent enumerated object. The return value 
            //indicates whether the conversion succeeded.
            Enum.TryParse<WeekDays>("1", out wdEnum);

            Console.WriteLine(wdEnum);

            Console.WriteLine("_4-------------------------------------------------------------");

            //Declare of an enum object wdEnumObject
            WeekDays2 wdEnumObject ;

            //Initialization of wdEnumObject object
            //cannot be use new WeekDays2();
            wdEnumObject = WeekDays2.Monday;

            //Note that you must use explicit conversions here. Even though the underlying 
            //type of WeekDays2 is byte (or any int type), you still have to use the(byte) 
            //cast to convert the value of wdEnumObject into a byte type
            byte wdEnumByte = (byte)wdEnumObject;

            //The same explicit casting is necessary in the other direction, too, if you want 
            //to convert a byte into an orientation. For example, you could use the following 
            //code to convert a byte variable called myByte into an orientation and assign this value to myDirection:
            WeekDays2 wdEnumObject2 = (WeekDays2)wdEnumByte;

            //To get the string value of an enumeration value you can use Convert.ToString():
            //Using a(string) cast won’t work because the processing required is more complicated 
            //than just placing the data stored in the enumeration variable into a string variable. 
            //Alternatively, you can use theToString() command of the variable itself.
            //The following code gives you the same result as using Convert.ToString():
            //directionString = wdEnumObject.ToString();
            string wdEnumString = Convert.ToString(wdEnumObject);

            Console.WriteLine($"The WeekDays wdEnumByte object = {wdEnumObject}");
            Console.WriteLine($"byte equivalent = {wdEnumByte}");
            Console.WriteLine($"string equivalent = {wdEnumString}");

            string wdEnumString2 = wdEnumObject2.ToString();

            Console.WriteLine($"string equivalent of enum WeekDays wdEnumObject2 object  = {wdEnumString2}");
        }
    }

    //Declaration of a enum WeekDays
    enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    //A change in the value of the first enum member will automatically assign incremental 
    //values to the other members sequentially.
    enum WeekDays2
    {
        Monday=10,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
}
/*
 * In C#, enum is a value type data type. The enum is used to declare a list of named integer 
 * constants. It can be defined using the enum keyword directly inside a namespace, class, 
 * or structure. The enum is used to give a name to each constant so that the constant 
 * integer can be referred using its name.
 * 
 * By default, the first member of an enum has the value 0 and the value of each successive enum 
 * member is increased by 1.
 * 
 * The enum can includes named constants of numeric data type e.g. byte, sbyte, short, ushort, int
 * , uint, long, or ulong.
 * 
 * Enum is mainly used to make code more readable by giving related constants a meaningful name. 
 * It also improves maintainability.
 * 
 * enum cannot be used with string type.
 * 
 * Enum methods: Enum is an abstract class that includes static helper methods to work with enums.
 *      Format: 	Converts the specified value of enum type to the specified string format.
 *      GetName:	Returns the name of the constant of the specified value of specified enum.
 *      GetNames:	Returns an array of string name of all the constant of specified enum.
 *      GetValues:	Returns an array of the values of all the constants of specified enum.
 *      object Parse(type, string):	        Converts the string representation of the name or 
 *                                          numeric value of one or more enumerated constants 
 *                                          to an equivalent enumerated object.
 *      bool TryParse(string, out TEnum):	Converts the string representation of the name or 
 *                                          numeric value of one or more enumerated constants 
 *                                          to an equivalent enumerated object. The return 
 *                                          value indicates whether the conversion succeeded.
 * 
 * Every enumeration type has an underlying type, which can be any integral type except char. 
 * The default underlying type of enumeration elements is int. To declare an enum of another 
 * integral type, such as byte, use a colon after the identifier followed by the type, 
 * as shown in the following example:
 *      enum Day : byte {Sat=1, Sun, Mon, Tue, Wed, Thu, Fri};
 *      
 * The approved types for an enum are byte, sbyte, short, ushort, int, uint, long, or ulong.
 * 
 * The enum keyword is used to declare an enumeration, a distinct type that consists of a 
 * set of named constants called the enumerator list.
 * 
 * Usually it is best to define an enum directly within a namespace so that all classes in 
 * the namespace can access it with equal convenience. However, an enum can also be nested 
 * within a class or struct.
 * 
 * Points to Remember :
 *      The enum is a set of named constant.
 *      The value of enum constants starts from 0. Enum can have value of any 
 *        valid numeric type.
 *      String enum is not supported in C#.
 *      Use of enum makes code more readable and manageable.
 * 
 */
