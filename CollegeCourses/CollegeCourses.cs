using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeCourse
{
    public class CollegeCourses
    {
        private List<string> courseListString;
        private List<string> rootcourseListString;
        private List<Course> courseList;
        private bool isCircular = true;

        public CollegeCourses(List<string> courseList)
        {
            if (courseList == null || courseList.Count() == 0 || courseList.FindAll(c => c.Trim() == "").Count() == courseList.Count())
            {
                throw new InvalidOperationException();
            }
            this.courseListString = courseList;
        }

        public bool CreateRootCourses()
        {
            return false;
        }

        public string GenerateCourseSequence()
        {
            return "";
        }

    }

    class Course
    {
        public int RootNumber { get; set; }
        public string MainCourse { get; set; }
        public string Prerequisites { get; set; }
        public int Level { get; set; }
    }
}
