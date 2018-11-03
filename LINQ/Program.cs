using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] studentArray = {
            new Student() { StudentID = 1, StudentName = "John", Age = 18 },
            new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 },
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 },
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 },
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 },
            new Student() { StudentID = 6, StudentName = "Chris",  Age = 17 },
            new Student() { StudentID = 7, StudentName = "Rob",Age = 19  },
            };

            Console.WriteLine("_1-------------------------------------------------------------");
            // Use for loop to find elements from the collection in C# 1.0
            Student[] students = new Student[10];

            int index = 0;

            foreach (Student std in studentArray)
            {
                if (std.Age > 12 && std.Age < 20)
                {
                    students[index] = std;
                    index++;
                    Console.WriteLine($"StudentID = {std.StudentID}, StudentName = {std.StudentName}, Age = {std.Age} ");
                }
            }

            Console.WriteLine("_2-------------------------------------------------------------");
            //Use of for loop is cumbersome, not maintainable and readable.
            //C# 2.0 introduced delegate, which can be used to handle this kind of a scenario, 
            //as shown:
            Student[] students2 = StudentExtension.where(studentArray, delegate (Student std)
            {
                return std.Age > 12 && std.Age < 20;
            });
            //The problem here also you got a 7 null element from the element finding

            foreach (Student std in students2)
            {
                if (std != null)
                    Console.WriteLine($"StudentID = {std.StudentID}, StudentName = {std.StudentName}, Age = {std.Age} ");
            }

            Console.WriteLine("_3-------------------------------------------------------------");
            /*The C# team felt that they still needed to make the code even more compact and 
             * readable. So they introduced the extension method, lambda expression, expression
             * tree, anonymous type and query expression in C# 3.0. You can use these features 
             * of C# 3.0, which are building blocks of LINQ to query to the different types of 
             * collection and get the resulted element(s) in a single statement.
             * 
             * As you can see in the following example, we specify different criteria using LINQ 
             * operator and lambda expression in a single statement. Thus, LINQ makes code more 
             * compact and readable and it can also be used to query different data sources. 
             * For example, if you have a student table in a database instead of an array of 
             * student objects as above, you can still use the same query to find students 
             * using the Entity Framework.
             */

            // Use LINQ to find teenager students
            Student[] teenAgerStudents = studentArray.Where(s => s.Age > 12 && s.Age < 20).ToArray();
            foreach (Student std in teenAgerStudents)
                Console.WriteLine($"StudentID = {std.StudentID}, StudentName = {std.StudentName}, Age = {std.Age} ");

            // Use LINQ to find first student whose name is Bill 
            Student bill = studentArray.Where(s => s.StudentName == "Bill").FirstOrDefault();
            Console.WriteLine($"StudentID = {bill.StudentID}, StudentName = {bill.StudentName}, Age = {bill.Age} ");

            // Use LINQ to find student whose StudentID is 5
            Student student5 = studentArray.Where(s => s.StudentID == 5).FirstOrDefault();
            Console.WriteLine($"StudentID = {student5.StudentID}, StudentName = {student5.StudentName}, Age = {student5.Age} ");

            Console.WriteLine("_4-------------------------------------------------------------");
            //LINQ Query Syntax in C#
            //Use LINQ query syntax to find out teenager students from the Student collection (sequence).

            // Student collection
            IList<Student> studentList = new List<Student>() {
                        new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                        new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                        new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                        new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                        new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
                    };

            // LINQ Query Syntax to find out teenager students
            var teenAgerStudent = from s in studentList
                                  where s.Age > 12 && s.Age < 20
                                  select s;

            Console.WriteLine("Teen age Students using LINQ Query Syntax:");

            foreach (Student std in teenAgerStudent)
                Console.WriteLine(std.StudentName);

            Console.WriteLine("_5-------------------------------------------------------------");
            //Use LINQ method syntax query with the IEnumerable<T> collection.

            //LINQ Method Syntax to find out teenager students
            var teenAgerStudent2 = studentList.Where(s => s.Age > 12 && s.Age < 20)
                                  .ToList<Student>();

            Console.WriteLine("Teen age Students using LINQ Method Syntax:");

            foreach (Student std in teenAgerStudent2)
                Console.WriteLine(std.StudentName);

            Console.WriteLine("_6-------------------------------------------------------------");
            //Use let keyword to make the query more readable.

            //you can compare string values and select the lowercase string value
            /*var lowercaseStudentNames = from s in studentList
                                        where s.StudentName.ToLower().StartsWith("r")
                                        select s.StudentName.ToLower();
            */
            /* Instead the ToLower() method is used multiple times in the above query. The following 
             * use 'let' to introduce new variable 'lowercaseStudentName' that will be then used in 
             * every where. Thus, let keyword to make the query more readable.
             */
            var lowercaseStudentNames = from s in studentList
                                        let lowercaseStudentName = s.StudentName.ToLower()
                                        where lowercaseStudentName.StartsWith("r")
                                        select lowercaseStudentName;

            foreach (var name in lowercaseStudentNames)
                Console.WriteLine(name);

            Console.WriteLine("_7-------------------------------------------------------------");
            //Use the 'into' keyword to continue a query after a select clause.

            /*the 'into' keyword introduced a new range variable teenStudents, so the first range 
             * variable s goes out of scope. You can write a further query after the into keyword 
             * using a new range variable.
             */
            var teenAgerStudents2 = from s in studentList
                                    where s.Age > 12 && s.Age < 20
                                    select s
                                   into teenStudents
                                    where teenStudents.StudentName.StartsWith("B")
                                    select teenStudents;

            foreach (Student std in teenAgerStudents2)
                Console.WriteLine(std.StudentName);

            Console.WriteLine("_8-------------------------------------------------------------");
            //Use OfType operator to filter the above collection based on each element's type
            IList mixedList = new ArrayList();
            mixedList.Add(0);
            mixedList.Add("One");
            mixedList.Add("Two");
            mixedList.Add(3);
            mixedList.Add(new Student() { StudentID = 1, StudentName = "Bill" });

            var stringResult = from s in mixedList.OfType<string>()
                               select s;
            //Instead you can use:
            //var stringResult = mixedList.OfType<string>();

            var intResult = from s in mixedList.OfType<int>()
                            select s;

            var stdResult = from s in mixedList.OfType<Student>()
                            select s;

            foreach (var str in stringResult)
                Console.WriteLine(str);

            foreach (var integer in intResult)
                Console.WriteLine(integer);

            foreach (var std in stdResult)
                Console.WriteLine(std.StudentName);


            Console.WriteLine("_8-------------------------------------------------------------");
            //Using OrderBy in Query Syntax

            var orderByResult = from s in studentList
                                orderby s.StudentName //Sorts the studentList collection in ascending order
                                select s;

            var orderByDescendingResult = from s in studentList //Sorts the studentList collection in descending order
                                          orderby s.StudentName descending
                                          select s;

            Console.WriteLine("Ascending Order using OrderBy in Query Syntax:");

            foreach (var std in orderByResult)
                Console.WriteLine(std.StudentName);

            Console.WriteLine("Descending Order using OrderBy in Query Syntax:");

            foreach (var std in orderByDescendingResult)
                Console.WriteLine(std.StudentName);

            Console.WriteLine("_9-------------------------------------------------------------");
            //Using OrderBy in Method Syntax

            var studentsInAscOrder = studentList.OrderBy(s => s.StudentName);

            var studentsInDescOrder = studentList.OrderByDescending(s => s.StudentName);


            Console.WriteLine("Ascending Order using OrderBy in Method Syntax:");

            foreach (var std in studentsInAscOrder)
                Console.WriteLine(std.StudentName);

            Console.WriteLine("Descending Order using OrderBy in Method Syntax:");

            foreach (var std in studentsInDescOrder)
                Console.WriteLine(std.StudentName);

            Console.WriteLine("_10-------------------------------------------------------------");
            //Multiple sorting in Query syntax

            var multiSortingResult = from s in studentList
                                     orderby s.StudentName, s.Age
                                     select new { s.StudentName, s.Age }; // returns collection of anonymous objects with Name and Age property
            foreach (var std in multiSortingResult)
                Console.WriteLine("Name: {0}, Age {1}", std.StudentName, std.Age);

            Console.WriteLine("_11-------------------------------------------------------------");
            //Use GroupBy operator to return a group of elements from the given collection based on some key value.

            /*creates a groups of students who have same age. Students of the same age will be in the same
             * collection and each grouped collection will have a key and inner collection, where the key 
             * will be the age and the inner collection will include students whose age is matched with 
             * a key.
             */
            //GroupBy in Query syntax
            var groupedResult = from s in studentList
                                group s by s.Age;

            /* GroupBy in method syntax (Same result as above)
             var groupedResult = studentList.GroupBy(s => s.Age);
             *
             * ToLookup in method syntax 
             * ToLookup is the same as GroupBy; the only difference is GroupBy execution is deferred, 
             * whereas ToLookup execution is immediate.
             var lookupResult = studentList.ToLookup(s => s.age);
             */

            //iterate each group        
            foreach (var ageGroup in groupedResult)
            {
                Console.WriteLine("Age Group: {0}", ageGroup.Key); //Each group has a key 

                foreach (Student s in ageGroup) // Each group has inner collection
                    Console.WriteLine("Student Name: {0}", s.StudentName);
            }

            Console.WriteLine("_12-------------------------------------------------------------");
            //The All operator evalutes each elements in the given collection on a specified condition 
            //and returns True if all the elements satisfy a condition.

            // checks whether all the students are teenagers    
            bool areAllStudentsTeenAger = studentList.All(s => s.Age > 12 && s.Age < 20);

            Console.WriteLine(areAllStudentsTeenAger);

            Console.WriteLine("_13-------------------------------------------------------------");
            //Any checks whether any element satisfy given condition or not? In the following example, 
            //Any operation is used to check whether any student is teen ager or not.

            // checks whether any of the students are teenagers    
            bool isAnyStudentTeenAger = studentList.Any(s => s.Age > 12 && s.Age < 20);

            Console.WriteLine(isAnyStudentTeenAger);

            Console.WriteLine("_14-------------------------------------------------------------");
            //LINQ First()

            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine("1st Element in intList: {0}", intList.First());
            Console.WriteLine("1st Even Element in intList: {0}", intList.First(intVar => intVar % 2 == 0));

            Console.WriteLine("1st Element in strList: {0}", strList.First());

            try
            {
                Console.WriteLine(emptyList.First());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"emptyList.First() throws an {ex.GetType().Name}");
            }

            Console.WriteLine("_15-------------------------------------------------------------");
            //LINQ FirstOrDefault()

            Console.WriteLine("1st Element in intList: {0}", intList.FirstOrDefault());
            Console.WriteLine("1st Even Element in intList: {0}",
                                             intList.FirstOrDefault(intVar => intVar % 2 == 0));

            Console.WriteLine("1st Element in strList: {0}", strList.FirstOrDefault());

            Console.WriteLine("1st Element in emptyList: {0}", emptyList.FirstOrDefault());

            Console.WriteLine("_16-------------------------------------------------------------");
            //Multiple Select and where Operator

            // Student collection
            IList<Student> studentListNew = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21, StandardID = 1 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID = 2 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
            };

            // Standard collection
            IList<Standard> standardList = new List<Standard>() {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };


            var studentNames = studentListNew.Where(s => s.Age > 18)
                              .Select(s => s)
                              .Where(st => st.StandardID > 0)
                              .Select(s => s.StudentName);

            foreach (var name in studentNames)
                Console.WriteLine(name);

            Console.WriteLine("_17-------------------------------------------------------------");
            // LINQ Query returns Collection of Anonymous Objects

            //Return Enumerable of anonymous object that has only StudentName property
            var teenStudentsName = from s in studentListNew
                                   where s.Age > 12 && s.Age < 20
                                   select new { StudentName = s.StudentName };

            teenStudentsName.ToList().ForEach(s => Console.WriteLine(s.StudentName));

            Console.WriteLine("_18-------------------------------------------------------------");
            // LINQ GroupBy Query

            //Returns list students group by StandardID
            //The output includes Ron who doesn't have any StandardID. So Ron falls under StandardID 0.
            var studentsGroupByStandard = from s in studentListNew
                                          group s by s.StandardID into sg
                                          orderby sg.Key
                                          select new { sg.Key, sg };


            foreach (var group in studentsGroupByStandard)
            {
                Console.WriteLine("StandardID {0}:", group.Key);

                group.sg.ToList().ForEach(st => Console.WriteLine(st.StudentName));
            }

            //To remove a student who doesn't have a StandardID, use a where operator before the group operator.
            var studentsGroupByStandard2 = from s in studentListNew
                                           where s.StandardID > 0
                                           group s by s.StandardID into sg
                                           orderby sg.Key
                                           select new { sg.Key, sg };


            foreach (var group in studentsGroupByStandard2)
            {
                Console.WriteLine("StandardID {0}:", group.Key);

                group.sg.ToList().ForEach(st => Console.WriteLine(st.StudentName));
            }

            Console.WriteLine("_19-------------------------------------------------------------");
            //LINQ Left Outer Join

            //Use left outer join to display students under each standard. Display the standard name 
            //even if there is no student assigned to that standard.
            var studentsGroup = from stad in standardList
                                join s in studentListNew
                                on stad.StandardID equals s.StandardID
                                    into sg
                                select new
                                {
                                    StandardName = stad.StandardName,
                                    Students = sg
                                };

            foreach (var group in studentsGroup)
            {
                Console.WriteLine(group.StandardName);

                group.Students.ToList().ForEach(st => Console.WriteLine(st.StudentName));
            }

            //In the following group by query, we sort the group and select only StudentName
            var studentsWithStandard = from stad in standardList
                                       join s in studentListNew
                                       on stad.StandardID equals s.StandardID
                                       into sg
                                       from std_grp in sg
                                       orderby stad.StandardName, std_grp.StudentName
                                       select new
                                       {
                                           StudentName = std_grp.StudentName,
                                           StandardName = stad.StandardName
                                       };


            foreach (var group in studentsWithStandard)
            {
                Console.WriteLine("{0} is in {1}", group.StudentName, group.StandardName);
            }

            Console.WriteLine("_20-------------------------------------------------------------");
            //LINQ Inner join using query syntax
            var studentWithStandard = from s in studentListNew // outer sequence
                                      join stad in standardList //inner sequence
                                      on s.StandardID equals stad.StandardID // key selector
                                      select new // result selector
                                      {
                                          StudentName = s.StudentName,
                                          StandardName = stad.StandardName
                                      };

            //LINQ Inner join using extension method syntax
            var studentWithStandardExt = studentListNew.Join(// outer sequence 
                      standardList,  // inner sequence 
                      student => student.StudentID,    // outerKeySelector
                      standard => standard.StandardID,  // innerKeySelector
                      (student, standard) => new  // result selector
                      {
                          StudentName = student.StudentName,
                          StandardName = standard.StandardName
                      });

            Console.WriteLine("--Inner join using query syntax--");
            studentWithStandard.ToList().ForEach(s => Console.WriteLine("{0} is in {1}", s.StudentName, s.StandardName));
            Console.WriteLine("--Inner join using extension method syntax--");
            studentWithStandardExt.ToList().ForEach(s => Console.WriteLine("{0} is in {1}", s.StudentName, s.StandardName));

            Console.WriteLine("_21-------------------------------------------------------------");
            //Nested Query
            var nestedQueries = from s in studentListNew
                                where s.Age > 18 && s.StandardID ==
                                    (from std in standardList
                                     where std.StandardName == "Standard 1"
                                     select std.StandardID).FirstOrDefault()
                                select s;

            nestedQueries.ToList().ForEach(s => Console.WriteLine(s.StudentName));

            Console.WriteLine("_22-------------------------------------------------------------");
            //Sorting

            //The following query returns list of students by ascending order of StandardID and Age.
            var sortedStudents = from s in studentListNew
                                 orderby s.StandardID, s.Age
                                 select new
                                 {
                                     StudentName = s.StudentName,
                                     Age = s.Age,
                                     StandardID = s.StandardID
                                 };

            sortedStudents.ToList().ForEach(s => Console.WriteLine("Student Name: {0}, Age: {1}, StandardID: {2}", s.StudentName, s.Age, s.StandardID));

            Console.WriteLine("_23-------------------------------------------------------------");
            //Aggregate
            //Aggregate operator is Not Supported with query syntax in C#

            //Aggregate with Seed Value
            //uses string as a seed value in the Aggregate extension method.
            string commaSeparatedStudentNames = studentListNew.Aggregate<Student, string>(
                                        "Student Names: ",  // seed value
                                        (str, s) => str += s.StudentName + ",");

            Console.WriteLine(commaSeparatedStudentNames);

            //Aggregate with Seed Value
            //use Aggregate operator to add the age of all the students.
            int SumOfStudentsAge = studentListNew.Aggregate<Student, int>(0,
                                                (totalAge1, s) => totalAge1 += s.Age);

            Console.WriteLine(SumOfStudentsAge);

            //Aggregate with Result Selector 
            //we have specified a lambda expression str => str.Substring(0,str.Length - 1 ) 
            //which will remove the last comma in the string result.
            commaSeparatedStudentNames = studentListNew.Aggregate<Student, string, string>(
                                            String.Empty, // seed value
                                            (str, s) => str += s.StudentName + ",", // returns result using seed value, String.Empty goes to lambda expression as str
                                            str => str.Substring(0, str.Length - 1)); // result selector that removes last comma

            Console.WriteLine(commaSeparatedStudentNames);

            Console.WriteLine("_24-------------------------------------------------------------");
            //Average

            //Average in Method Syntax
            var avgAge = studentListNew.Average(s => s.Age);
            //The Average operator in query syntax is Not Supported in C#.

            Console.WriteLine("Average Age of Student: {0}", avgAge);

            Console.WriteLine("_25-------------------------------------------------------------");
            //Count

            //Count in Method Syntax
            var totalStudents = studentListNew.Count();
            Console.WriteLine("Total Students: {0}", totalStudents);

            var adultStudents = studentListNew.Count(s => s.Age >= 18);
            Console.WriteLine("Number of Adult Students: {0}", adultStudents);

            //Count in query syntax
            var totalAge = (from s in studentListNew
                            select s.Age).Count();
            Console.WriteLine("Total Students: {0}", totalStudents);

            Console.WriteLine("_26-------------------------------------------------------------");
            //Max
            var oldest = studentListNew.Max(s => s.Age);
            Console.WriteLine("Oldest Student Age: {0}", oldest);

            //You can use Min extension method/operator the same way as Max.

            Console.WriteLine("_26-------------------------------------------------------------");
            //Sum
            //Sum operator is Not Supported in C# Query syntax.

            //Sum in Method Syntax
            //sum of all student's age and also number of adult students in a student collection.
            var sumOfAge = studentListNew.Sum(s => s.Age);
            Console.WriteLine("Sum of all student's age: {0}", sumOfAge);

            var numOfAdults = studentListNew.Sum(s => {

                if (s.Age >= 18)
                    return 1;
                else
                    return 0;
            });
            Console.WriteLine("Total Adult Students: {0}", numOfAdults);

            Console.WriteLine("_27-------------------------------------------------------------");
            //LINQ ElementAt() and ElementAtOrDefault()
            IList<int> intListAt = new List<int>() { 10, 21, 30, 45, 50, 87 };
            IList<string> strListAt = new List<string>() { "One", "Two", null, "Four", "Five" };

            Console.WriteLine("1st Element in intList: {0}", intListAt.ElementAt(0));
            Console.WriteLine("1st Element in strList: {0}", strListAt.ElementAt(0));

            Console.WriteLine("2nd Element in intList: {0}", intListAt.ElementAt(1));
            Console.WriteLine("2nd Element in strList: {0}", strListAt.ElementAt(1));

            Console.WriteLine("3rd Element in intList: {0}", intListAt.ElementAtOrDefault(2));
            Console.WriteLine("3rd Element in strList: {0}", strListAt.ElementAtOrDefault(2));

            Console.WriteLine("10th Element in intList: {0} - default int value",
                            intListAt.ElementAtOrDefault(9));
            Console.WriteLine("10th Element in strList: {0} - default string value (null)",
                             strListAt.ElementAtOrDefault(9));

            try { 
            Console.WriteLine(intListAt.ElementAt(9));
            }
            catch(Exception ex) {
                Console.WriteLine($"intList.ElementAt(9) throws an exception: {ex.GetType().Name}");
            }

            Console.WriteLine("_27-------------------------------------------------------------");
            //Concat in C#
            IList<int> collection1 = new List<int>() { 1, 2, 3 };
            IList<int> collection2 = new List<int>() { 4, 5, 6 };

            var collection3 = collection1.Concat(collection2);

            foreach (int intVar in collection3)
                Console.WriteLine(intVar);

            Console.WriteLine("_28-------------------------------------------------------------");
            //Generation Operators

            //Enumerable.Empty()
            var emptyCollection1 = Enumerable.Empty<string>();
            var emptyCollection2 = Enumerable.Empty<Student>();

            Console.WriteLine("Count: {0} ", emptyCollection1.Count());
            Console.WriteLine("Type: {0} ", emptyCollection1.GetType().Name);

            Console.WriteLine("Count: {0} ", emptyCollection2.Count());
            Console.WriteLine("Type: {0} ", emptyCollection2.GetType().Name);

            //Enumerable.Range()
            // Enumerable.Range(10, 10) creates collection with 10 integer elements with the sequential 
            //values starting from 10. First parameter specifies the starting value of elements and second
            //parameter specifies the number of elements to create.
            var intCollection = Enumerable.Range(10, 10);
            Console.WriteLine("Total Count: {0} ", intCollection.Count());

            for (int j = 0; j < intCollection.Count(); j++)
                Console.WriteLine("Value at index {0} : {1}", j, intCollection.ElementAt(j));

            //Repeat
            //Enumerable.Repeat<int>(10, 10) creates collection with 100 integer type elements with the 
            //repeated value of 10. First parameter specifies the values of all the elements and second 
            //parameter specifies the number of elements to create.
            var intColl = Enumerable.Repeat<int>(10, 10);
            Console.WriteLine("Total Count: {0} ", intColl.Count());

            for (int j = 0; j < intColl.Count(); j++)
                Console.WriteLine("Value at index {0} : {1}", j, intColl.ElementAt(j));

            Console.WriteLine("_29-------------------------------------------------------------");
            //Distinct 
            IList<string> strListDist = new List<string>() { "One", "Two", "Three", "Two", "Three" };

            IList<int> intListDist = new List<int>() { 1, 2, 3, 2, 4, 4, 3, 5 };

            var distinctList1 = strListDist.Distinct();

            foreach (var str in distinctList1)
                Console.WriteLine(str);

            var distinctList2 = intListDist.Distinct();

            foreach (var intVar in distinctList2)
                Console.WriteLine(intVar);

            Console.WriteLine("_30-------------------------------------------------------------");
            //Except
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            IList<string> strList2 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };

            var result1 = strList1.Except(strList2);

            foreach (string str in result1)
                Console.WriteLine(str);

            Console.WriteLine("_31-------------------------------------------------------------");
            //Intersect
            var result2 = strList1.Intersect(strList2);

            foreach (string str in result2)
                Console.WriteLine(str);

            Console.WriteLine("_32-------------------------------------------------------------");
            //Union
            var result3 = strList1.Union(strList2);

            foreach (string str in result3)
                Console.WriteLine(str);

        }
    }

    public class Standard
    {
        public int StandardID { get; set; }
        public string StandardName { get; set; }
    }

    class Student
    {
        public int StudentID { get; set; }
        public String StudentName { get; set; }
        public int Age { get; set; }
        public int StandardID { get; set; }
    }

    delegate bool FindStudent(Student std);

    class StudentExtension
    {
        public static Student[] where(Student[] stdArray, FindStudent del)
        {
            int i = 0;
            Student[] result = new Student[10];
            foreach (Student std in stdArray)
                if (del(std))
                {
                    result[i] = std;
                    i++;
                }

            return result;
        }
    }

}
/* 
 * LINQ (Language Integrated Query) is uniform query syntax in C# and VB.NET used to save and 
 * retrieve data from different sources. It is integrated in C# or VB, thereby eliminating the 
 * mismatch between programming languages and databases, as well as providing a single querying 
 * interface for different types of data sources.
 * 
 * For example, SQL is a Structured Query Language used to save and retrieve data from a 
 * database. In the same way, LINQ is a structured query syntax built in C# and VB.NET used to 
 * save and retrieve data from different types of data sources like an Object Collection, SQL 
 * server database, XML, web service etc.
 * 
 * LINQ always works with objects so you can use the same basic coding patterns to query and 
 * transform data in XML documents, SQL databases, ADO.NET Datasets, .NET collections, and any 
 * other format for which a LINQ provider is available.
 * 
 * Developer uses LINQ to query {object collection==> Linq to object, ADO.Net DataSet==> Linq to DataSet, 
 * XML Document==> Linq to XML, Entity Framework==> Linq to Entities, SQL Database==> Linq to SQL,
 * Other Data Sourses==> By implementing IQueryable interface.
 * 
 * Advantages of LINQ:
 *  Familiar language: Developers don’t have to learn a new query language for each type of data source 
 *    or data format.
 *  Less coding: It reduces the amount of code to be written as compared with a more traditional approach.
 *  Readable code: LINQ makes the code more readable so other developers can easily understand and 
 *  maintain it.
 *  Standardized way of querying multiple data sources: The same LINQ syntax can be used to query 
 *    multiple data sources.
 *  Compile time safety of queries: It provides type checking of objects at compile time.
 *  IntelliSense Support: LINQ provides IntelliSense for generic collections.
 *  Shaping data: You can retrieve data in different shapes.
 *
 * C# 3.0/.Net 3.5 introduced lamda expression along with LINQ. Lambda expression is a shorter way of representing anonymous method using some special syntax.
        s => s.age > 18;
 * 
 * LINQ is nothing but the collection of extension methods for classes that implements IEnumerable 
 * and IQueryable interface. System.Linq namespace includes the necessary classes & interfaces for LINQ. 
 * Enumerable and Queryable are two main static classes of LINQ API that contain extension methods.
 * 
 * Enumerable class includes extension methods for the classes that implement IEnumerable<T> interface,
 * this include all the collection types in System.Collections.Generic namespaces such as List<T>, 
 * Dictionary<T>, SortedList<T>, Queue<T>, HashSet<T>, LinkedList<T> etc.
 * System.Linq.Enumerable has the following extension methods: ( Aggregate<T>, All<T>, Any<T>, AsEnumerable<T>,
 * Average<T>, Cast<T>, Concat<T>, Contains<T>) for all generic collecions as HashSet<T>
 * 
 * The Queryable class includes extension methods for classes that implement IQueryable<t> interface. 
 * IQueryable<T> is used to provide querying capabilities against a specific data source where the type 
 * of the data is known. For example, Entity Framework api implements IQueryable<T> interface to support
 * LINQ queries with underlaying database like SQL Server.
 * System.Linq.Queryable has the following extension methods: ( Aggregate<T>, All<T>, Any<T>, AsEnumerable<T>,
 * Average<T>, Cast<T>, Concat<T>, Contains<T>) for (Linq to SQL, EntityFramework, PLinq, or Linq to Amazon). 
 * 
 * Also, there are APIs available to access third party data; for example, LINQ to Amazon provides the 
 * ability to use LINQ with Amazon web services to search for books and other items by implementing
 * IQueryable interface.
 * 
 * Points to Remember :
 *  Use System.Linq namespace to use LINQ.
 *  LINQ api includes two main static class Enumerable & Queryable.
 *  The static Enumerable class includes extension methods for classes that implements IEnumerable<T> 
 *    interface.
 *  IEnumerable<T> type of collections are in-memory collection like List, Dictionary, SortedList, Queue, 
 *    HashSet, LinkedList.
 *  The static Queryable class includes extension methods for classes that implements IQueryable<T> 
 *    interface.
 *  Remote query provider implements IQueryable<T>. eg. Linq-to-SQL, LINQ-to-Amazon etc.
 * 
 * There are two basic ways to write a LINQ query to IEnumerable collection or IQueryable data sources.
 *   Query Syntax or Query Expression Syntax.
 *   Method Syntax or Method extension syntax or Fluent.
 * 
 * Query Syntax is similar to SQL (Structured Query Language) for the database. It is defined within 
 * the C# or VB code.
        from <range variable> in <IEnumerable<T> or IQueryable<T> Collection>

        <Standard Query Operators> <lambda expression>

        <select or groupBy operator> <result formation>
 * 
 * The LINQ query syntax starts with from keyword and ends with select keyword.
 * 
 * Query syntax starts with a From clause followed by a Range variable. The From clause is structured 
 * like "From rangeVariableName in IEnumerablecollection". In English, this means, from each object in 
 * the collection. It is similar to a foreach loop: foreach(Student s in studentList).
 * 
 * After the From clause, you can use different Standard Query Operators to filter, group, join elements 
 * of the collection. There are around 50 Standard Query Operators available in LINQ. In the above figure,
 * we have used "where" operator (aka clause) followed by a condition. This condition is generally 
 * expressed using lambda expression.
 * 
 * LINQ query syntax always ends with a Select or Group clause. The Select clause is used to shape the 
 * data. You can select the whole object as it is or only some properties of it. In the above example, 
 * we selected the each resulted string elements.
 * 
 * Points to Remember :
 *  As name suggest, Query Syntax is same like SQL (Structure Query Language) syntax.
 *  Query Syntax starts with from clause and can be end with Select or GroupBy clause.
 *  Use various other opertors like filtering, joining, grouping, sorting operators to construct the desired result.
 *  Implicitly typed variable - var can be used to hold the result of the LINQ query.
 * 
 * Method syntax (also known as fluent syntax) uses extension methods included in the Enumerable or 
 * Queryable static class, similar to how you would call the extension method of any class.
 * 
 * The compiler converts query syntax into method syntax at compile time.
 * 
 * Method syntax comprises of extension methods and Lambda expression. The extension method Where() 
 * is defined in the Enumerable class.
 * If you check the signature of the Where extension method, you will find the Where method accepts 
 * a predicate delegate as Func<Student, bool>. This means you can pass any delegate function that 
 * accepts a Student object as an input parameter and returns a Boolean value as shown in the below figure. 
 * The lambda expression works as a delegate passed in the Where clause.
 * 
 * Points to Remember :
 *  As name suggest, Method Syntax is like calling extension method.
 *  LINQ Method Syntax aka Fluent syntax because it allows series of extension methods call.
 *  Implicitly typed variable - var can be used to hold the result of the LINQ query.
 * 
 * Standard Query Operators in LINQ are actually extension methods for the IEnumerable<T> and 
 * IQueryable<T> types. They are defined in the System.Linq.Enumerable and System.Linq.Queryable classes. 
 * There are over 50 standard query operators available in LINQ that provide different functionalities 
 * like filtering, sorting, grouping, aggregation, concatenation, etc.
 * 
 * Standard query operators in query syntax is converted into extension methods at compile time. 
 * So both are same.
 * 
 * Standard Query Operators can be classified based on the functionality they provide. 
 * The following table lists all the classification of Standard Query Operators:

        Classification	Standard Query Operators
        Filtering	    Where, OfType
        Sorting	        OrderBy, OrderByDescending, ThenBy, ThenByDescending, Reverse
        Grouping	    GroupBy, ToLookup
        Join	        GroupJoin, Join
        Projection	    Select, SelectMany
        Aggregation	    Aggregate, Average, Count, LongCount, Max, Min, Sum
        Quantifiers	    All, Any, Contains
        Elements	    ElementAt, ElementAtOrDefault, First, FirstOrDefault, Last, LastOrDefault,
                        Single, SingleOrDefault
        Set	            Distinct, Except, Intersect, Union
        Partitioning    Skip, SkipWhile, Take, TakeWhile
        Concatenation   Concat
        Equality	    SequenceEqual
        Generation	    DefaultEmpty, Empty, Range, Repeat
        Conversion	    AsEnumerable, AsQueryable, Cast, ToArray, ToDictionary, ToList
 * 
 * The 'let' keyword is useful in query syntax. It projects a new range variable, allows re-use 
 * of the expression and makes the query more readable.
 * 
 * You can also use the 'into' keyword to continue a query after a select clause.
 * You can write a further query after the into keyword using a new range variable.
 * Also 'into' keyword already used in grouping.
 * 
 * Filtering Operators:
 *  Where	Returns values from the collection based on a predicate function
 *  OfType	Returns values from the collection based on a specified type. 
 *          However, it will depend on their ability to cast to a specified type.
 * 
 * The Where operator (Linq extension method) filters the collection based on a given criteria expression 
 * and returns a new collection. The criteria can be specified as lambda expression or Func delegate type.
 * The Where extension method has following two overloads. Both overload methods accepts a Func 
 * delegate type parameter. One overload required Func<TSource,bool> input parameter and second 
 * overload method required Func<TSource, int, bool> input parameter where int is for index.
 * 
 * Where clause - LINQ query syntax:
        var filteredResult = from s in studentList
                           where s.Age > 12 && s.Age < 20
                           select s.StudentName;
 * The lambda expression body s.Age > 12 && s.Age < 20 is passed as a predicate function Func<TSource, bool> 
 * that evaluates every student in the collection.
 * Alternatively, you can also use a Func type delegate with an anonymous method to pass as a predicate 
 * function as below (output would be the same):
        Func<Student,bool> isTeenAger = delegate(Student s) { 
                                            return s.Age > 12 && s.Age < 20; 
                                        };

        var filteredResult = from s in studentList
                             where isTeenAger(s)
                             select s;
 * You can also call any method that matches with Func parameter with one of Where() method overloads:
        var filteredResult = from s in studentList
                                    where isTeenAger(s)
                                    select s;

        public static bool IsTeenAger(Student stud)
        {
            return stud.Age > 12 && stud.Age < 20;  
        }
 * 
 * Where extension method in Method Syntax:
 * Unlike the query syntax, you need to pass whole lambda expression as a predicate 
 * function instead of just body expression in LINQ method syntax.
        var filteredResult = studentList.Where(s => s.Age > 12 && s.Age < 20);
 * the Where extension method also have second overload that includes index of current 
 * element in the collection. You can use that index in your logic if you need:
        var filteredResult = studentList.Where((s, i) => { 
                    if(i % 2 ==  0) // if it is even element
                        return true;
 * 
 * Multiple Where clause:
 * Multiple where clause in Query Syntax 
        var filteredResult = from s in studentList
                            where s.Age > 12
                            where s.Age < 20
                            select s;
 * Multiple where clause in Method Syntax 
        var filteredResult = studentList.Where(s => s.Age > 12).Where(s => s.Age < 20);
 * 
 * Points to Remember :
 * Where is used for filtering the collection based on given criteria.
 * Where extension method has two overload methods. Use a second overload method to know the 
 * index of current element in the collection.
 * Method Syntax requires the whole lambda expression in Where extension method whereas Query syntax 
 * requires only expression body.
 * Multiple Where extension methods are valid in a single LINQ query.
 * 
 * Use OfType operator to filter the above collection based on each element's type.
 * 
 * Points to Remember :
 *  The Where operator filters the collection based on a predicate function.
 *  The OfType operator filters the collection based on a given type
 *  Where and OfType extension methods can be called multiple times in a single LINQ query.
 * 
 * Sorting Operators: OrderBy & OrderByDescending:
 * OrderBy	            Sorts the elements in the collection based on specified fields in ascending or 
 *                      decending order.
 * OrderByDescending	Sorts the collection based on specified fields in descending order. Only valid 
 *                      in method syntax.
 * ThenBy	            Only valid in method syntax. Used for second level sorting in ascending order.
 * ThenByDescending	    Only valid in method syntax. Used for second level sorting in descending order.
 * Reverse	            Only valid in method syntax. Sorts the collection in reverse order.
 * 
 * OrderBy sorts the values of a collection in ascending or descending order. It sorts the collection 
 * in ascending order by default because ascending keyword is optional here. Use descending keyword to 
 * sort collection in descending order.
 * 
 * OrderBy extension method has two overloads. First overload of OrderBy extension method accepts 
 * the Func delegate type parameter. So you need to pass the lambda expression for the field based 
 * on which you want to sort the collection.
 * The second overload method of OrderBy accepts object of IComparer along with Func delegate type to 
 * use custom comparison for sorting.
 * 
 * You can sort the collection on multiple fields seperated by comma. The given collection would be first
 * sorted based on the first field and then if value of first field would be the same for two elements 
 * then it would use second field for sorting and so on.
 * 
 * The GroupBy operator returns a group of elements from the given collection based on some key value. 
 * Each group is represented by IGrouping<TKey, TElement> object. Also, the GroupBy method has eight 
 * overload methods, so you can use appropriate extension method based on your requirement in method 
 * syntax.
 * 
 * The result of GroupBy operators is a collection of groups.
 * 
 * A LINQ query can end with a GroupBy or Select clause.
 * 
 * ToLookup is the same as GroupBy; the only difference is GroupBy execution is deferred, 
 * whereas ToLookup execution is immediate. Also, ToLookup is only applicable in Method syntax. 
 * ToLookup is not supported in the query syntax.
 * 
 * Points to Remember :
 *  GroupBy & ToLookup return a collection that has a key and an inner collection based on 
 *  a key field value.
 *  The execution of GroupBy is deferred whereas that of ToLookup is immediate.
 *  A LINQ query syntax can be end with the GroupBy or Select clause.
 * 
 * There are two projection operators available in LINQ. 1) Select 2) SelectMany
 * 
 * The Select operator always returns an IEnumerable collection which contains elements based 
 * on a transformation function. It is similar to the Select clause of SQL that produces a flat 
 * result set.
 * 
 * LINQ query syntax must end with a Select or GroupBy clause.
 * 
 * Select in Query Syntax:
        var selectResult = from s in studentList
                           select s.StudentName;
        // returns collection of anonymous objects with Name and Age property
        var selectResult = from s in studentList
                           select new { Name = "Mr. " + s.StudentName, Age = s.Age }; 
 * 
 * Select in Method Syntax:
         var selectResult = studentList.Select(s => new { Name = s.StudentName , 
                                                         Age = s.Age  });
 * 
 * Quantifier Operators
 *  All	      Checks if all the elements in a sequence satisfies the specified condition
 *  Any	      Checks if any of the elements in a sequence satisfies the specified condition
 *  Contains  Checks if the sequence contains a specific element
 * 
 * The quantifier operators evaluate elements of the sequence on some condition and return a 
 * boolean value to indicate that some or all elements satisfy the condition.
 * 
 * Quantifier operators are Not Supported with C# query syntax.
 * 
 * The Contains operator checks whether a specified element exists in the collection or not and 
 * returns a boolean.
 * 
 * The Contains() extension method has following two overloads. The first overload method requires 
 * a value to check in the collection and the second overload method requires additional parameter 
 * of IEqualityComparer type for custom equalality comparison.
 * 
 * Joining Operator:
 *  Join	    The Join operator joins two sequences (collections) based on a key and returns a resulted 
 *              sequence.
 *  GroupJoin	The GroupJoin operator joins two sequences based on keys and returns groups of sequences. 
 *              It is like Left Outer Join of SQL.
 * 
 * The Join operator operates on two collections, inner collection & outer collection. It returns a new 
 * collection that contains elements from both the collections which satisfies specified expression. 
 * It is the same as inner join of SQL.
 * 
 * The Join extension method has two overloads as shown below.
        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, 
                    IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, 
                    Func<TInner, TKey> innerKeySelector, 
                    Func<TOuter, TInner, TResult> resultSelector);

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, 
                    IEnumerable<TInner> inner, 
                    Func<TOuter, TKey> outerKeySelector,
                    Func<TInner, TKey> innerKeySelector, 
                    Func<TOuter, TInner, TResult> resultSelector,
                    IEqualityComparer<TKey> comparer);
 * As you can see in the first overload method takes five input parameters (except the first 'this' parameter):
 * 1) outer 2) inner 3) outerKeySelector 4) innerKeySelector 5) resultSelector.
 * 
 * Join operator in query syntax works slightly different than method syntax. It requires outer sequence,
 * inner sequence, key selector and result selector. 'on' keyword is used for key selector where left 
 * side of 'equals' operator is outerKeySelector and right side of 'equals' is innerKeySelector.
        from ... in outerSequence

                join ... in innerSequence  

                on outerKey equals innerKey

                select ...
 * 
 * Points to Remember :
 *  Join and GroupJoin are joining operators.
 *  Join is like inner join of SQL. It returns a new collection that contains common elements from 
 *    two collections whosh keys matches.
 *  Join operates on two sequences inner sequence and outer sequence and produces a result sequence.
 *  Join query syntax:
        from... in outerSequence
        join... in innerSequence 
        on  outerKey equals innerKey
        select ...
 * 
 * Aggregation Operators:
 *  Aggregate	Performs a custom aggregation operation on the values in the collection.
 *  Average	    calculates the average of the numeric items in the collection.
 *  Count	    Counts the elements in a collection.
 *  LongCount	Counts the elements in a collection.
 *  Max	        Finds the largest value in the collection.
 *  Min	        Finds the smallest value in the collection.
 *  Sum	        Calculates sum of the values in the collection.
 * 
 * The Aggregate method performs an accumulate operation. 
 * Aggregate extension method has the 3 overload methods.
 * 
 * Aggregate operator is Not Supported with query syntax in C#
 * 
 * Average extension method calculates the average of the numeric items in the collection. 
 * Average method returns nullable or non-nullable decimal, double or float value.
 * 
 * The Average operator in query syntax is Not Supported in C#.
 * 
 * The Count operator returns the number of elements in the collection or number of elements 
 * that have satisfied the given condition.
 * 
 * The Count() extension method has the following two overloads:
        int Count<TSource>();

        int Count<TSource>(Func<TSource, bool> predicate);
 * The first overload method of Count returns the number of elements in the specified collection, 
 * whereas the second overload method returns the number of elements which have satisfied the specified 
 * condition given as lambda expression/predicate function.
 * 
 * The Max operator returns the largest numeric element from a collection.
 * 
 * The Sum() method calculates the sum of numeric items in the collection.
 * 
 * Sum operator is Not Supported in C# Query syntax.
 * 
 * Element Operators:
 *  ElementAt	        Returns the element at a specified index in a collection
 *  ElementAtOrDefault	Returns the element at a specified index in a collection or a default value if the
 *                      index is out of range.
 *  First	            Returns the first element of a collection, or the first element that satisfies 
 *                      a condition.
 *  FirstOrDefault	    Returns the first element of a collection, or the first element that satisfies 
 *                      a condition. Returns a default value if index is out of range.
 *  Last	            Returns the last element of a collection, or the last element that satisfies 
 *                      a condition
 *  LastOrDefault	    Returns the last element of a collection, or the last element that satisfies 
 *                      a condition. Returns a default value if no such element exists.
 *  Single	            Returns the only element of a collection, or the only element that satisfies 
 *                      a condition.
 *  SingleOrDefault	    Returns the only element of a collection, or the only element that satisfies 
 *                      a condition. Returns a default value if no such element exists or the collection 
 *                      does not contain exactly one element.
 * 
 * The ElementAt() method returns an element from the specified index from a given collection. If the 
 * specified index is out of the range of a collection then it will throw an Index out of range exception. 
 * Please note that index is a zero based index.
 * 
 * The ElementAtOrDefault() method also returns an element from the specified index from a collaction and 
 * if the specified index is out of range of a collection then it will return a default value of the data 
 * type instead of throwing an error.
 * 
 * Element Operators: First & FirstOrDefault
 *  First	        Returns the first element of a collection, or the first element that satisfies a condition.
 *  FirstOrDefault	Returns the first element of a collection, or the first element that satisfies a condition. 
 *                  Returns a default value if index is out of range.
 * 
 * The First and FirstOrDefault method returns an element from the zeroth index in the collection i.e.
 * the first element. Also, it returns an element that satisfies the specified condition.
 * 
 * First and FirstOrDefault has two overload methods. The first overload method doesn't take any input 
 * parameter and returns the first element in the collection. The second overload method takes the lambda 
 * expression as predicate delegate to specify a condition and returns the first element that satisfies 
 * the specified condition.
 * 
 * The First() method returns the first element of a collection, or the first element that satisfies the 
 * specified condition using lambda expression or Func delegate. If a given collection is empty or does 
 * not include any element that satisfied the condition then it will throw InvalidOperation exception.
 * 
 * The FirstOrDefault() method does the same thing as First() method. The only difference is that 
 * it returns default value of the data type of a collection if a collection is empty or doesn't find 
 * any element that satisfies the condition.
 * 
 * The Concat() method appends two sequences of the same type and returns a new sequence (collection).
 * 
 * Generation Operators: 
 *  Empty	Returns an empty collection
 *  Range	Generates collection of IEnumerable<T> type with specified number of elements with sequential 
 *          values, starting from first element.
 *  Repeat	Generates a collection of IEnumerable<T> type with specified number of elements and each
 *          element contains same specified value.
 * 
 * The Empty() method is not an extension method of IEnumerable or IQueryable like other LINQ methods. 
 * It is a static method included in Enumerable static class. So, you can call it the same way as other 
 * static methods like Enumerable.Empty<TResult>(). The Empty() method returns an empty collection of 
 * a specified type as shown below.
 * 
 * The Range() method returns a collection of IEnumerable<T> type with specified number of elements 
 * and sequential values starting from the first element.
 * 
 * The Repeat() method generates a collection of IEnumerable<T> type with specified number of elements 
 * and each element contains same specified value.
 * 
 * Set Operator:
 *  Distinct  Returns distinct values from a collection.
 *  Except	  Returns the difference between two sequences, which means the elements of one collection that
 *            do not appear in the second collection.
 *  Intersect Returns the intersection of two sequences, which means elements that appear in both the 
 *            collections.
 *  Union	  Returns unique elements from two sequences, which means unique elements that appear in 
 *            either of the two sequences.
 * 
 * The following shows how each set operators works on the collections:
 *  Collection1.Except(Collection2) ==> Collection1 items which are not in the Collection2
 *  Collection1.Distinct() ==> All distinct items in Collection1, no repeated items
 *  Collection1.Union(Collection2) ==> All distinct items from Collection1  
 *                                     & All distinct items fromCollection2
 *  Collection1.Intersect(Collection2) ==> items which exist in both of Collection1 & Collection2
 * 
 * The Distinct extension method returns a new collection of unique elements from the given collection.
 * 
 * The Distinct extension method doesn't compare values of complex type objects. You need to implement 
 * IEqualityComparer<T> interface in order to compare the values of complex types.
 * 
 * The Except() method requires two collections. It returns a new collection with elements from the first
 * collection which do not exist in the second collection (parameter collection).
 * 
 * Except extension method doesn't return the correct result for the collection of complex types. You need 
 * to implement IEqualityComparer interface in order to get the correct result from Except method.
 * 
 * The Intersect extension method requires two collections. It returns a new collection that includes common 
 * elements that exists in both the collection.
 * 
 * The Intersect extension method doesn't return the correct result for the collection of complex types. 
 * You need to implement IEqualityComparer interface in order to get the correct result from Intersect 
 * method.
 * 
 * The Union extension method requires two collections and returns a new collection that includes distinct elements 
 * from both the collections. Consider the following example.
 * 
 * The Union extension method doesn't return the correct result for the collection of complex types. You need to implement 
 * IEqualityComparer interface in order to get the correct result from Union method.
 * 
 * Partitioning Operators: 
 *  Skip	    Skips elements up to a specified position starting from the first element in a sequence.
 *  SkipWhile	Skips elements based on a condition until an element does not satisfy the condition. 
 *              If the first element itself doesn't satisfy the condition, it then skips 0 elements 
 *              and returns all the elements in the sequence.
 *  Take	    Takes elements up to a specified position starting from the first element in a sequence.
 *  TakeWhile	Returns elements from the first element until an element does not satisfy the condition. 
 *              If the first element itself doesn't satisfy the condition then returns an empty collection.
 * 
 */
