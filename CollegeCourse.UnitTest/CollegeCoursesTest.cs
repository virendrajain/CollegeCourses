using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CollegeCourse.UnitTest
{
    [TestClass]
    public class CollegeCoursesTest
    {
        /// <summary>
        /// Check Invalid Input in constructor
        /// </summary>
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
            catch { }
        }

        /// <summary>
        /// Generate course sequence - Check if input is single course
        /// </summary>
        [TestMethod]
        public void Test_GenerateCourseSequence_CheckCourseSequenceWithSingleCourses()
        {
            string expectedResult = "Introduction to Paper Airplanes, Advanced Throwing Techniques";

            List<string> input = new List<string>();
            input.Add("Advanced Throwing Techniques: Introduction to Paper Airplanes");

            CollegeCourses collegeCourses = new CollegeCourses(input);

            string actualResult = collegeCourses.GenerateCourseSequence();
            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// if Courses contains cycle, it should throw exception
        /// </summary>
        [TestMethod]
        public void Test_GenerateCourseSequence_CheckIfCycle()
        {
            List<string> input = new List<string>();
            input.Add("Intro to Arguing on the Internet: Godwin’s Law");
            input.Add("Understanding Circular Logic: Intro to Arguing on the Internet");
            input.Add("Godwin’s Law: Understanding Circular Logic");

            CollegeCourses collegeCourses = new CollegeCourses(input);

            try
            {
                collegeCourses.GenerateCourseSequence();
                Assert.Fail();
            }
            catch { }
        }

        /// <summary>
        /// Check valid Course Sequence 
        /// </summary>
        [TestMethod]
        public void Test_GenerateCourseSequence_CheckCourseSequence()
        {
            string expectedResult = "Introduction to Paper Airplanes, Rubber Band Catapults 101, Advanced Throwing Techniques, Paper Jet Engines, History of Cubicle Siege Engines, Advanced Office Warfare";

            List<string> input = new List<string>();
            input.Add("Introduction to Paper Airplanes:");
            input.Add("Advanced Throwing Techniques: Introduction to Paper Airplanes");
            input.Add("History of Cubicle Siege Engines: Rubber Band Catapults 101");
            input.Add("Advanced Office Warfare: History of Cubicle Siege Engines");
            input.Add("Rubber Band Catapults 101:");
            input.Add("Paper Jet Engines: Introduction to Paper Airplanes");

            CollegeCourses collegeCourses = new CollegeCourses(input);

            string actualResult = collegeCourses.GenerateCourseSequence();
            Assert.AreEqual(expectedResult, actualResult);

        }

        /// <summary>
        /// Check course cycle , Generate Course Sequence when no course without prerequisites course
        /// and input does not have main course which is their in prerequisites course
        /// </summary>
        [TestMethod]
        public void Test_GenerateCourseSequence_WhenNoCoursesWithoutPrerequisits()
        {
            string expectedResult = "Introduction to Paper Airplanes, Rubber Band Catapults 101, Advanced Throwing Techniques, Paper Jet Engines, History of Cubicle Siege Engines, Advanced Office Warfare";

            List<string> input = new List<string>();
            input.Add("Advanced Throwing Techniques: Introduction to Paper Airplanes");
            input.Add("History of Cubicle Siege Engines: Rubber Band Catapults 101");
            input.Add("Advanced Office Warfare: History of Cubicle Siege Engines");
            input.Add("Paper Jet Engines: Introduction to Paper Airplanes");

            CollegeCourses collegeCourses = new CollegeCourses(input);

            string actualResult = collegeCourses.GenerateCourseSequence();
            Assert.AreEqual(expectedResult, actualResult);

        }


        /// <summary>
        /// Check courses if cycle with non-cycle courses exist
        /// </summary>
        [TestMethod]
        public void Test_GenerateCourseSequence_CheckIfCycleWithIndependentCourses()
        {
            List<string> input = new List<string>();
            input.Add("Advanced Throwing Techniques: Introduction to Paper Airplanes");
            input.Add("History of Cubicle Siege Engines: Rubber Band Catapults 101");
            input.Add("Advanced Office Warfare: History of Cubicle Siege Engines");
            input.Add("Paper Jet Engines: Introduction to Paper Airplanes");
            input.Add("Rubber Band Catapults 101: Advanced Office Warfare");
            input.Add("Introduction to Paper Airplanes:");

            CollegeCourses collegeCourses = new CollegeCourses(input);

            try
            {
                collegeCourses.GenerateCourseSequence();
                Assert.Fail();
            }
            catch { }
        }
    }
}
