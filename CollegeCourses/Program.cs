using System;
using System.Collections.Generic;

namespace CollegeCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the list of courses: ");
            List<string> list = new List<string>();

            var input = Console.ReadLine();
            while (input != string.Empty)
            {
                list.Add(input.Trim());
                input = Console.ReadLine();
            }

            try
            {
                Console.WriteLine("Output: ");
                CollegeCourses collegeCourses = new CollegeCourses(list);

                Console.WriteLine(collegeCourses.GenerateCourseSequence());
                Console.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
            }
        }
    }
}
