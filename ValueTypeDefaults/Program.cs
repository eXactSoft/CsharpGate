using System;

namespace TypesDefault
{
    class Program
    {
        static void Main(string[] args)
        {
            //Value types default value
            Console.WriteLine($"byte type default:  {default(byte)}");
            Console.WriteLine($"sbyte type default:  {default(sbyte)}");
            Console.WriteLine($"short type default:  {default(short)}");
            Console.WriteLine($"ushort type default:  {default(ushort)}");
            Console.WriteLine($"int type default:  {default(int)}");
            Console.WriteLine($"uint type default:  {default(uint)}");
            Console.WriteLine($"long type default:  {default(long)}");
            Console.WriteLine($"ulong type default:  {default(ulong)}");
            Console.WriteLine($"float type default:  {default(float)}");
            Console.WriteLine($"double type default:  {default(double)}");
            Console.WriteLine($"decimal type default:  {default(decimal)}");
            Console.WriteLine($"char type default ('\\0'):  {default(char)}" );
            Console.WriteLine($"bool type default:  {default(bool)}");
            Console.WriteLine($"DateTime type default:  {default(DateTime)}");
            
            //Reference type default value
            Console.WriteLine($"object reference type default (null):  {default(object)}");
        }
    }
}

/* 
 * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/default-values-table
 * The default of enum: The value produced by the expression (E)0, where E is the enum identifier.
 * The default of struct: The value produced by setting all value-type fields to their default values 
 * and all reference-type fields to null.
 * The default value of any reference type is null.
 * You also can use the default value of a type to specify the default value of a method's optional argument.
 * The default value of a nullable type is an instance for which the HasValue property 
 * is false and the Value property is undefined.
 * You cannot use uninitialized variables in C# Except:
                        -Static variables.
                        -Instance variables of class instances.
                        -Instance variables of initially assigned struct variables.
                        -Array elements.
                        -Method parameters Value or Reference types.
                        -Variables declared in a catch clause or a foreach statement.
 * Variables declared within a class are automatically initialized using the default value.
 * Variables declared within a method are not initialized, but when the variable is first used the compiler checks 
 * to make sure that it was initialized, so the code will not compile.
 * 
 * So, local variables require initialization but fields do not, Why?
 * The short answer is that code accessing uninitialised local variables can be detected 
 * by the compiler in a reliable way, using static analysis. Whereas this isn't the case 
 * of fields. So the compiler enforces the first case, but not the second.
 * 
 * Why do local variables require initialization?
 * This is no more than a design decision of the C# language. 
 * The CLR and the .NET environment do not require it. VB.NET, for example
 * , will compile just fine with uninitialised local variables, and in reality 
 * the CLR initialises all uninitialised variables to default values.
 * The same could occur with C#, but the language designers chose not to. 
 * The reason is that initialised variables are a huge source of bugs and so, 
 * by mandating initialisation, the compiler helps to cut down on accidental mistakes.
 * 
 * Why don't fields require initialization?
 * So why doesn't this compulsory explicit initialisation happen with fields within a class? 
 * Simply because that explicit initialisation could occur during construction, 
 * through a property being called by an object initializer, or even by a method 
 * being called long after the event. The compiler cannot use static analysis to 
 * determine if every possible path through the code leads to the variable being 
 * explicitly initialised before us. Getting it wrong would be annoying, as the developer 
 * could be left with valid code that won't compile. So C# doesn't enforce it at all 
 * and the CLR is left to automatically initialise fields to a default value 
 * if not explicitly set.
 * 
 */
