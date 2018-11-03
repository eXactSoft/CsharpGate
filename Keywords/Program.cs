using System;

namespace Keywords
{
    class Program
    {
       /*
        * keyword cannot be used as an identifier (name of variable, class, interface etc). 
        * However, they can be used with the prefix '@'. For example, class is a reserved 
        * keyword so it cannot be used as an identifier, but @class can be used as shown below.
        */
        public class @class
        {
            public static int MyProperty { get; set; }
        }

        static void Main(string[] args)
        {
            @class.MyProperty = 100;
            Console.WriteLine(@class.MyProperty);
        }
    }
}
/*
 * C# contains reserved words, that have special meaning for the compiler. 
 * These reserved words are called "keywords". Keywords cannot be used 
 * as a name (identifier) of a variable, class, interface, etc.
 * 
 * Keywords in C# are distributed under the following categories:
 * 1)Modifier Keywords:
 *   abstract,async, const, event, extern, new, override, partial, readonly, sealed, static
 *   ,unsafe, virtual, volatile.
 * 2)Access Modifier Keywords:
 *   public, private, internal, protected.
 * 3)Statement Keywords:
 *   if, else, switch, case, do, for, foreach, in, while, break, continue, default, goto 
 *   , return, yield, throw, try, catch, finally, checked, unchecked, fixed, lock.
 * 4)Method Parameter Keywords
 *   params, ref, out.
 * 5)Namespace Keywords
 *    using, . operator, :: operator, extern alias.
 * 6)Operator Keywords
 *    as, await, is, new, sizeof, typeof, stackalloc, checked, unchecked.
 * 7)Access keywords
 *    base, this.
 * 8)Literal Keywords
 *    null, false, true, value, void.   
 * 9)Type keywords:
 *    bool, byte, char, class, decimal, double, enum, float, int, long, sbyte, short 
 *    , string, struct, uint, ulong, ushort.
 * 10)Contextual Keywords:
 *    add, var, dynamic, global, set, value.
 *    
 *    Contextual keywords are considered as keywords, only if used in certain contexts. 
 *    They are not reserved and so can be used as names or identifiers.  
 *    Contextual keywords are not converted into blue color (default color for keywords in visual studio) 
 *    when used as an identifier in Visual Studio.
 *    
 * 11)Query Keywords:
 *    from, where, select, group, into, orderby, join, let, in, on, equals, by, ascending
 *    , descending. 
 *    
 *    Query keywords are contextual keywords used in LINQ queries.
 *   
 * Points to Remember :
 *   Keywords are reserved words that cannot be used as name or identifier.
 *   Prefix '@' with keywords if you want to use it as identifier.
 *   C# includes various categories of keywords e.g. modifier keywords, access modifiers keywords, statement keywords, method param keywords etc.
 *   Contextual keywords can be used as identifier.  
 */
