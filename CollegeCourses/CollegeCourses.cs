using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollegeCourse
{
    public class CollegeCourses
    {
        private List<string> courseListString;
        private List<string> distinctCourseList;
        private List<Course> courseList;

        /// <summary>
        /// Initialize the class
        /// </summary>
        /// <param courses="List of Courses in string format"></param>
        public CollegeCourses(List<string> courses)
        {
            if (courses == null || courses.Count() == 0 || courses.FindAll(c => c.Trim() == "").Count() == courses.Count())
            {
                throw new InvalidOperationException("Invalid input string.");
            }
            this.courseListString = courses;
        }

        /// <summary>
        /// This method generates course sequence string and checks the cycle in courses.
        /// It creates two list internally to generate sequence string.
        /// 1. distinctCoursesList: list of unique course name in the input string.
        /// 2. courseList: List of courses with extra properties RootNumber and Level of the course.
        ///                 RootNumber property is grouping the number of root courses and sub-courses
        ///                 Level property is maintaining the Level of the course in the hierarchy
        /// 
        /// Once courseList is created then it updates RootNumber and Level property in the courseList to identify 
        /// course hierarchy and level of course in the hierarchy
        /// </summary>
        /// <returns>String of Courses in sequence</returns>
        public string GenerateCourseSequence()
        {
            CreateDistinctListAndCourseList();

            // Finding prerequisites courses which are not main courses
            List<string> prerequisitesList = distinctCourseList.Where(p => !courseList.Any(p2 => p2.MainCourse.ToLower() == p.ToLower())).ToList();

            // create course list
            foreach (var item in prerequisitesList)
            {
                courseList.Add(new Course { MainCourse = item, Prerequisites = "", Level = 0, RootNumber = 0 });
            }

            // Updating the level of each course in courseList starting from root
            int courseCounter = 0;
            foreach (var course in courseList.Where(c => c.Prerequisites == ""))
            {
                course.RootNumber = courseCounter++;
                UpdateCourseLevel(course, 1, courseCounter);
            }

            // If Level of any course is 0 means it is out of course tree and creating cycle.
            if (courseList.Where(c => c.Level == 0).Count() == 0)
            {
                bool isFirst = true;
                StringBuilder courses = new StringBuilder();
                // create output string 
                foreach (var item in courseList.OrderBy(c => c.Level).ThenBy(c => c.RootNumber))
                {
                    if (isFirst)
                    {
                        isFirst = false;
                        courses.Append(item.MainCourse);
                    }
                    else
                    {
                        courses.Append(", " + item.MainCourse);
                    }
                }
                return courses.ToString();
            }
            else
            {
                throw new InvalidOperationException("Invalid Operation: Input contains cycle.");
            }

        }

        /// <summary>
        /// Create distinct main course list and course list
        /// </summary>
        private void CreateDistinctListAndCourseList()
        {
            courseList = new List<Course>();
            distinctCourseList = new List<string>();
            foreach (var course in courseListString)
            {
                if (!String.IsNullOrEmpty(course))
                {
                    string courseOne = course.Split(':')[0].Trim();
                    string courseTwo = "";
                    if (course.Contains(":"))
                    {
                        courseTwo = course.Split(':')[1].Trim();
                    }

                    courseList.Add(new Course { Level = 0, MainCourse = courseOne, Prerequisites = courseTwo });

                    if (!String.IsNullOrWhiteSpace(courseOne) && !distinctCourseList.Contains(courseOne, StringComparer.OrdinalIgnoreCase))
                    {
                        distinctCourseList.Add(courseOne);
                    }

                    if (!String.IsNullOrWhiteSpace(courseTwo) && !distinctCourseList.Contains(courseTwo, StringComparer.OrdinalIgnoreCase))
                    {
                        distinctCourseList.Add(courseTwo);
                    }
                }
            }
        }

        /// <summary>
        /// Recursive function to update the level and rootNumber of Courses
        /// </summary>
        /// <param root="course object"></param>
        /// <param level="course Level"></param>
        /// <param rootNumber="Root Number of course to maintain different course hierarchy"></param>
        private void UpdateCourseLevel(Course root, int level, int rootNumber)
        {
            root.Level = level;
            root.RootNumber = rootNumber;
            ++level;

            foreach (var item in courseList.Where(c => c.Prerequisites.ToLower() == root.MainCourse.ToLower()))
            {
                UpdateCourseLevel(item, level, rootNumber);
            }
        }

    }

    /// <summary>
    /// Course class
    /// </summary>
    class Course
    {
        public int RootNumber { get; set; }  // maintaining root number of course hierarchy
        public string MainCourse { get; set; }
        public string Prerequisites { get; set; }
        public int Level { get; set; }   // maintain course level in their course root hierarchy
    }
}
