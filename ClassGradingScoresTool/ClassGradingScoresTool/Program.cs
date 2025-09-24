using System;
using System.Xml.Linq;

namespace App4
{
    class Program
    {
        static void Main(string[] args)
        {
            //This program is meant to create a student list and give each one a grade for a single class.
            //Then you will be allowed to search for a student and get their grades.
            //It will also display class average, mean, median, etc.

            //Here, we will grab the number of students and make arrays for the names and grades of each.
            Console.WriteLine("How many students do you have in your class?");
            int studentNum;

            while (!int.TryParse(Console.ReadLine(), out studentNum))
            {
                Console.WriteLine("Error. Please enter a number for the students in your class.");
            }
            /* while (string.IsNullOrWhiteSpace(studentInput) || !int.TryParse(studentInput, out studentNum)) //checks if input is empty, or not an 'int'
             {
                 studentInput = Console.ReadLine();

                 if (string.IsNullOrWhiteSpace(studentInput))
                     Console.WriteLine("Error. Please enter a number.");
             }*/

            string[] names = new string[studentNum];
            int[] grades = new int[studentNum];


            //Here, we grab the names and grades for the students and input them into the arrays.
            for (int i = 0; i < studentNum; i++) //loops through name inputs
            {
                string inputName = "";
                while (string.IsNullOrWhiteSpace(inputName)) //checks if empty.
                {
                    Console.WriteLine($"Please enter the name of student #{i + 1}");
                    inputName = Console.ReadLine();


                    if (string.IsNullOrWhiteSpace(inputName))
                        Console.WriteLine("Error. Please enter a name.");
                }

                string inputGrade = "";
                int grade = 0;
                while (string.IsNullOrWhiteSpace(inputGrade) || !int.TryParse(inputGrade, out grade)) //checks if input is empty, or not an 'int'
                {
                    Console.WriteLine("Please enter the NUMBER grade for " + inputName);
                    inputGrade = Console.ReadLine();


                    if (string.IsNullOrWhiteSpace(inputGrade))
                        Console.WriteLine("Error. Please enter a number.");
                }
                
                names[i] = inputName; //sets name if not empty.
                grades[i] = grade;
            }

            //Here we will begin the math for highest, lowest, average, and median.
            int classHighNum = grades.Max();
            int classLowNum = grades.Min();
            //string classLowName = names[Array.IndexOf(grades, classLowNum)]; //finds one name with the lowest score
            //string classHighName = names[Array.IndexOf(grades, classHighNum)];
            double classAverage = grades.Average();
            

            // Collect all names with that grade
            List<string> topStudents = new List<string>();
            List<string> bottomStudents = new List<string>();

            for (int i = 0; i < grades.Length; i++)              //Makes a list of names of top and lowest scores
            {
                if (grades[i] == classHighNum)
                    topStudents.Add(names[i]);
                if (grades[i] == classLowNum)
                    bottomStudents.Add(names[i]);
            }

            //Find Median
            var sortedGrades = grades.OrderBy(g => g).ToArray();
            double classMedian;
            if (studentNum % 2 == 0) //If number of students is even, have to find the average of the middle 2.
            {
                classMedian = ((sortedGrades[studentNum/2 - 1]) + sortedGrades[studentNum/2]) / 2;
            }
            else                    //If number of students is odd, find middle.
            {
                classMedian = sortedGrades[studentNum / 2];
            }
            Console.WriteLine($"Of the class of {studentNum} students, these are the results. /n");
            Console.WriteLine($"Highest grade: {classHighNum}");
            Console.WriteLine("Students with this grade: " + string.Join(", ", topStudents));

            Console.WriteLine($"Lowest grade: {classLowNum}");
            Console.WriteLine("Students with this grade: " + string.Join(", ", bottomStudents));

            Console.WriteLine($"Average grade: {classAverage:F2}");
            Console.WriteLine($"Median grade: {classMedian:F2}");

        }
    }
}


/*
 * using System;
using System.Linq;
using System.Collections.Generic;

namespace App4
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentNum = GetIntInput("How many students do you have in your class?");

            string[] names = new string[studentNum];
            int[] grades = new int[studentNum];

            for (int i = 0; i < studentNum; i++)
            {
                names[i] = GetStringInput($"Enter name of student #{i + 1}:");
                grades[i] = GetIntInput($"Enter grade for {names[i]}:");
            }

            int classHighNum = grades.Max();
            int classLowNum = grades.Min();
            double classAverage = grades.Average();

            var topStudents = names.Where((name, index) => grades[index] == classHighNum).ToList();
            var bottomStudents = names.Where((name, index) => grades[index] == classLowNum).ToList();

            var sortedGrades = grades.OrderBy(g => g).ToArray();
            double classMedian = studentNum % 2 == 0
                ? (sortedGrades[studentNum / 2 - 1] + sortedGrades[studentNum / 2]) / 2.0
                : sortedGrades[studentNum / 2];

            Console.WriteLine($"\nClass of {studentNum} students results:\n");
            Console.WriteLine($"Highest grade: {classHighNum} ({string.Join(", ", topStudents)})");
            Console.WriteLine($"Lowest grade: {classLowNum} ({string.Join(", ", bottomStudents)})");
            Console.WriteLine($"Average grade: {classAverage:F2}");
            Console.WriteLine($"Median grade: {classMedian:F2}");
        }

        static int GetIntInput(string prompt)
        {
            int value;
            Console.WriteLine(prompt);
            while (!int.TryParse(Console.ReadLine(), out value))
                Console.WriteLine("Error. Please enter a number.");
            return value;
        }

        static string GetStringInput(string prompt)
        {
            string input;
            Console.WriteLine(prompt);
            while (string.IsNullOrWhiteSpace(input = Console.ReadLine()))
                Console.WriteLine("Error. Please enter a valid name.");
            return input;
        }
    }
}
*/