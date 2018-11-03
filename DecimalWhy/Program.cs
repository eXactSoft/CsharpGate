using System;

namespace DecimalWhy
{
    class Program
    {
        static void Main(string[] args)
        {
            float valFloat = 10e20F;
            valFloat += 1F;
            double valDouble = 10e20d;
            valDouble += 1d;
            decimal valDecimal = 10e20m;
            valDecimal += 1m;
            Console.WriteLine($"Float ={valFloat}\nDouble ={valDouble}\nDecimal ={valDecimal}\n");
        }
    }
}
/*
 The decimal keyword denotes a 128-bit data type.Compared to floating-point types, 
 the decimal type has a greater precision and a smaller range, which makes it suitable 
 for financial and monetary calculations.
 Decimal is not infinitely precise (it is impossible to represent infinite precision for 
 non-integral in a primitive data type), but it is far more precise than double:-
     decimal = 28-29 significant digits
     double = 15-16 significant digits
     float = 7 significant digits
 For money, always decimal. It's why it was created.
 If numbers must add up correctly or balance, use decimal. 
 This includes any financial storage or calculations, scores, or other numbers that people might do by hand.
 If the exact value of numbers is not important, use double for speed. This includes graphics, 
 physics or other physical sciences computations where there is already a "number of significant digits.

 Note: the default of all floating point calculations is double.
 */
