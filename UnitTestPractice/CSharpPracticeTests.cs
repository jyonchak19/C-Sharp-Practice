using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace UnitTestPractice
{
    using CSharpPracticeApp;
    [TestClass]
    public class CSharpPracticeTests
    {
        [TestMethod]
        public void UniqueOccurrencesTest()
        {
            //Arranging
            int[] uniqueOccurrencesArr = { 1, 2, 2, 1, 1, 3 };
            //Acting and Asserting
            Assert.IsTrue(CSharpPracticeProblems.UniqueOccurrences(uniqueOccurrencesArr));

        }

        [TestMethod]
        public void TwoSumTest()
        {
            int[] twoSumArr = { 2, 7, 11, 15 };
            int[] twoSumResult = CSharpPracticeProblems.TwoSum(twoSumArr, 9);
            int[] expectedResult = { 0, 1 };

            CollectionAssert.AreEqual(expectedResult, twoSumResult);
        }

        [TestMethod]
        public void ValidStringTest1()
        {
            string s1 = "(){}[]";
            Assert.IsTrue(InterviewProblems.IsValid(s1));
        }

        [TestMethod]
        public void ValidStringTest2()
        {
            string s2 = "([)]";
            Assert.IsFalse(InterviewProblems.IsValid(s2));
        }

        [TestMethod]
        public void ValidStringTest3()
        {
            string s3 = "(3)";
            Assert.IsTrue(InterviewProblems.IsValid(s3));
        }

        [TestMethod]
        public void ValidStringTest4()
        {
            string s4 = "(]";
            Assert.IsFalse(InterviewProblems.IsValid(s4));
        }

        [TestMethod]
        public void ValidString2Test1()
        {
            string s1 = "(){}[]";
            Assert.IsTrue(InterviewProblems.IsValid2(s1));
        }

        [TestMethod]
        public void ValidString2Test2()
        {
            string s2 = "([)]";
            Assert.IsTrue(InterviewProblems.IsValid2(s2));
        }

        [TestMethod]
        public void ValidString2Test3()
        {
            string s3 = "(3)";
            Assert.IsTrue(InterviewProblems.IsValid2(s3));
        }

        [TestMethod]
        public void ValidString4Test4()
        {
            string s4 = "(]";
            Assert.IsFalse(InterviewProblems.IsValid2(s4));
        }

        [TestMethod]
        public void MatrixRotationTest()
        {
            int[,] Matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] ExpectedResult = new int[,] { { 7, 4, 1 }, { 8, 5, 2 }, { 9, 6, 3 } };

            InterviewProblems.RotateMatrix(Matrix);

            CollectionAssert.AreEqual(Matrix, ExpectedResult);
        }

        [TestMethod]
        public void CheckChildSumTest1()
        {
            BinaryTreeProblems.Node BottomLeft = new BinaryTreeProblems.Node(4);
            BinaryTreeProblems.Node BottomRight = new BinaryTreeProblems.Node(6);
            BinaryTreeProblems.Node Top = new BinaryTreeProblems.Node(10, BottomLeft, BottomRight);

            bool result = BinaryTreeProblems.CheckChildSum(Top);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckChildSumTest2()
        {
            BinaryTreeProblems.Node BottomLeft = new BinaryTreeProblems.Node(3);
            BinaryTreeProblems.Node BottomRight = new BinaryTreeProblems.Node(1);
            BinaryTreeProblems.Node Top = new BinaryTreeProblems.Node(5, BottomLeft, BottomRight);

            bool result = BinaryTreeProblems.CheckChildSum(Top);

            Assert.IsFalse(result);
        }

        [TestMethod, TestCategory("LinkedList")]
        public void RemoveNodeCSharpNativeTest()
        {
            LinkedListNode<int> nativeNode1 = new LinkedListNode<int>(1);
            LinkedListNode<int> nativeNode2 = new LinkedListNode<int>(2);
            LinkedListNode<int> nativeNode3 = new LinkedListNode<int>(3);
            LinkedListNode<int> nativeNode4 = new LinkedListNode<int>(4);

            LinkedList<int> ll = new LinkedList<int>();
            ll.AddLast(nativeNode1);
            ll.AddLast(nativeNode2);
            ll.AddLast(nativeNode3);
            ll.AddLast(nativeNode4);

            InterviewProblems.RemoveNodeCSharpNative(ll, 3);
            InterviewProblems.RemoveNodeCSharpNative(ll, 1);
            InterviewProblems.RemoveNodeCSharpNative(ll, 4);

            LinkedListNode<int> expectedNode1 = new LinkedListNode<int>(2);
            //LinkedListNode<int> expectedNode2 = new LinkedListNode<int>(3);

            LinkedList<int> llResult = new LinkedList<int>();
            llResult.AddLast(expectedNode1);
            //llResult.AddLast(expectedNode2);

            CollectionAssert.AreEqual(ll, llResult);
        }

        [TestMethod, TestCategory("LinkedList")]
        public void RemoveNodeTest()
        {
            InterviewProblems.LLNode node1 = new InterviewProblems.LLNode(1);
            InterviewProblems.LLNode node2 = new InterviewProblems.LLNode(2);
            InterviewProblems.LLNode node3 = new InterviewProblems.LLNode(3);
            InterviewProblems.LLNode node4 = new InterviewProblems.LLNode(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            InterviewProblems.RemoveNode(node1, 1);
            //InterviewProblems.RemoveNode(node2, 3);
            InterviewProblems.RemoveNode(node2, 4);

            InterviewProblems.LLNode currentNode = node2;

            InterviewProblems.LLNode expectedNode = new InterviewProblems.LLNode(2);
            InterviewProblems.LLNode expectedNode2 = new InterviewProblems.LLNode(3);

            expectedNode.Next = expectedNode2;

            while (currentNode != null)
            {
                Assert.AreEqual(expectedNode.Value, currentNode.Value);
                currentNode = currentNode.Next;
                expectedNode = expectedNode.Next;
            }
        }
    }
}