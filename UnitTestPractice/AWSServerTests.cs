using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestPractice
{
    using CSharpPracticeApp;
    [TestClass]
    public class AWSServerTests
    {
        [TestMethod]
        public void ProcessTasksTest1()
        {
            int[] serverInput = { 3, 3, 2 };
            int[] tasksInput = { 1, 2, 3, 2, 1, 2 };
            int[] expectedResult = { 2, 2, 0, 2, 1, 2 };
            EC2 ec2 = new EC2();
            CollectionAssert.AreEqual(expectedResult, ec2.ProcessTasks(serverInput, tasksInput));
        }

        [TestMethod]
        public void ProcessTasksTest2()
        {
            int[] serverInput = { 5, 1, 4, 3, 2 };
            int[] tasksInput = { 2, 1, 2, 4, 5, 2, 1 };
            int[] expectedResult = { 1, 4, 1, 4, 1, 3, 2 };
            EC2 ec2 = new EC2();
            CollectionAssert.AreEqual(expectedResult, ec2.ProcessTasks(serverInput, tasksInput));
        }
    }
}
