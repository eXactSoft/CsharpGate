using System;

namespace Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_1-------------------------------------------------------------");
            //The following shows how a dynamic variable changes its type based on its value
            dynamic dynamicVariable = 100;
            Console.WriteLine("Dynamic variable value: {0}, Type: {1}", dynamicVariable, dynamicVariable.GetType().ToString());

            dynamicVariable = "Hello World!!";
            Console.WriteLine("Dynamic variable value: {0}, Type: {1}", dynamicVariable, dynamicVariable.GetType().ToString());

            dynamicVariable = true;
            Console.WriteLine("Dynamic variable value: {0}, Type: {1}", dynamicVariable, dynamicVariable.GetType().ToString());

            dynamicVariable = DateTime.Now;
            Console.WriteLine("Dynamic variable value: {0}, Type: {1}", dynamicVariable, dynamicVariable.GetType().ToString());

            Console.WriteLine("_2-------------------------------------------------------------");
            //assign class object to the dynamic type then the compiler would not check for correct methods 
            //and properties name of a dynamic type that holds the custom class object.

            //Assign Student object to a dynamic variable.
            dynamic dynamicStudent = new Student();
            try {
                /* Calling FakeMethod() method, which is not exists in the Student class. However, the compiler 
                 * will not give any error for FakeMethod() because it skips type checking for dynamic type, 
                 * instead you will get a runtime exception for it as shown below.
                 */
                dynamicStudent.FakeMethod();
            }
            catch (Exception ex){
                Console.WriteLine($"Exception raised of type: {ex.GetType().Name}");
            }

            Console.WriteLine("_3-------------------------------------------------------------");
            // A method can have dynamic type parameters so that it can accept any type of parameter at run time. 

            DisplayValue("Hello World!!");
            DisplayValue(100);
            DisplayValue(100.50);
            DisplayValue(true);
            DisplayValue(DateTime.Now);

        }

        static void DisplayValue(dynamic val)
        {
            Console.WriteLine(val);
        }

    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public int StandardID { get; set; }

        public void DisplayStudentDetail()
        {
            Console.WriteLine("Name: {0}", this.StudentName);
            Console.WriteLine("Age: {0}", this.Age);
            Console.WriteLine("Standard: {0}", this.StandardID);
        }
    }
}
/*
 * The implicitly typed variable- var where the compiler assigns a specific type 
 *   based on the value of the expression.
 *   
 * C# 4.0 (.NET 4.5) introduced a new type that avoids compile time type checking.
 * A dynamic type escapes type checking at compile time; instead, it resolves type at run time.
 * 
 * A dynamic type can be defined using the dynamic keyword.
 * The compiler compiles dynamic types into object types in most cases.
 * 
 * The folowing statement:
 *      dynamic dynamicVariable = 1;
 * would be compiled as:
 *      object dynamicVariable = 1;
 * 
 * The actual type of dynamic would resolve at runtime.
 * 
 * A dynamic type changes its type at runtime based on the value of the expression 
 * to the right of the "=" operator.
 * 
 * If you assign class object to the dynamic type then the compiler would not check 
 * for correct methods and properties name of a dynamic type that holds the custom class object.
 * 
 * Intellisense in Visual Studio does not give any help for the dymanic type.
 * 
 * A method can have dynamic type parameters so that it can accept any type of parameter at run time.
 * 
 * Points to Remember :
 *  The dynamic types are resolved at runtime instead of compile time.
 *  The compiler skips the type checking for dynamic type. So it doesn't give any error about dynamic 
 *    types at compile time.
 *  The dynamic types do not have intellisense support in visual studio.
 *  A method can have parameters of the dynamic type.
 *  An exception is thrown at runtime if a method or property is not compatible.
 * 
 * 
 */
