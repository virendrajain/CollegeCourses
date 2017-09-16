using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CollegeCourse;
using System.Collections.Generic;

namespace CollegeCourse.UnitTest
{
    [TestClass]
    public class CollegeCoursesTest
    {
        [TestMethod]
        public void Test_CollegeCourses_CheckInvalidInput()
        {
            List<string> input = new List<string>();
            input.Add("");
            input.Add(" ");

            try
            {
                CollegeCourses collegeCourses = new CollegeCourses(input);
                Assert.Fail();
            }
            catch {}
        }


    }
}
