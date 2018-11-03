using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExecutionDeferredImmediate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_1-------------------------------------------------------------");
            //Deferred Execution returns the Latest Data

            // Student collection
            IList<Student> studentList = new List<Student>() {
                        new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                        new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                        new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                        new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                        new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
                    };

            // LINQ Query Syntax to find out teenager students
            // Query does not executed here:
            var teenAgerStudent = from s in studentList
                                  where s.Age > 12 && s.Age < 20
                                  select s;

            //Query executed here:
            foreach (Student std in teenAgerStudent)
                Console.WriteLine($"Student Name: {std.StudentName}");

            studentList.Add(new Student() { StudentID = 6, StudentName = "Martin", Age = 16 });

            //Query executed again here:
            foreach (Student std in teenAgerStudent)
                Console.WriteLine($"Student Name: {std.StudentName}");
            /* the second foreach loop executes the query again and returns the latest data. Deferred execution
             * re-evaluates on each execution; this is called lazy evaluation. This is one of the major advantages 
             * of deferred execution: it always gives you the latest data.
             */

            Console.WriteLine("_2-------------------------------------------------------------");
            //Implimenting Custom Deferred Execution

            //custom extension method GetTeenAgerStudents for IEnumerable that returns a list of 
            //all students who are teenagers.
            //GetTeenAgerStudents() dosn't called here
            var teenAgerStudents = from s in studentList.GetTeenAgerStudents()
                                   select s;

            //GetTeenAgerStudents() called here
            foreach (Student teenStudent in teenAgerStudents)
                Console.WriteLine("Student Name: {0}", teenStudent.StudentName);

            Console.WriteLine("_3-------------------------------------------------------------");
            //Immediate Execution Method Syntax

            //ToList() extension method executes the query immediately and returns the result.
            IList<Student> teenAgerStudentsImm =
                studentList.Where(s => s.Age > 12 && s.Age < 20).ToList();

            foreach (Student teenStudent in teenAgerStudentsImm)
                Console.WriteLine("Student Name: {0}", teenStudent.StudentName);

            Console.WriteLine("_4-------------------------------------------------------------");
            //Immediate Execution Query Syntax

            // Query Syntax can use ToList(), ToArray() or ToDictionary() for immediate execution.
            IList<Student> teenAgerStudentsQuery = (from s in studentList
                                               where s.Age > 12 && s.Age < 20
                                               select s).ToList();
            foreach (Student teenStudent in teenAgerStudentsQuery)
                Console.WriteLine("Student Name: {0}", teenStudent.StudentName);
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public String StudentName { get; set; }
        public int Age { get; set; }
    }

    public static class EnumerableExtensionMethods
    {
        //Print the student name on the console whenever GetTeenAgerStudents() gets called.
        //Create custom methods using the yield keyword to get the advantage of deferred execution.
        public static IEnumerable<Student> GetTeenAgerStudents(this IEnumerable<Student> source)
        {

            foreach (Student std in source)
            {
                Console.WriteLine("Accessing student {0}", std.StudentName);

                if (std.Age > 12 && std.Age < 20)
                    yield return std;
            }
        }
    }

}
/* Deferred execution means that the evaluation of an expression is delayed until its realized value is 
 * actually required. It greatly improves performance by avoiding unnecessary execution.
 * 
 * Deferred execution is applicable on any in-memory collection as well as remote LINQ providers 
 * like LINQ-to-SQL, LINQ-to-Entities, LINQ-to-XML, etc.
 * 
 * you can see the query is materialized and executed when you iterate using the foreach loop. This is 
 * called deferred execution. LINQ processes the studentList collection when you actually access each 
 * object from the collection and do something with it.
 * 
 * You can implement deferred execution for your custom extension methods for IEnumerable using the yield 
 * keyword of C#.
 * 
 * Immediate execution is the reverse of deferred execution. It forces the LINQ query to execute and gets 
 * the result immediately. The 'To' conversion operators execute the given query and give the result 
 * immediately.
 * 
 */
