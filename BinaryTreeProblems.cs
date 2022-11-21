namespace CSharpPracticeApp
{
    using System;

    public class BinaryTreeProblems
    {
        public class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int value)
            {
                Value = value;
            }

            public Node(int value, Node left, Node right) : this(value)
            {
                Left = left;
                Right = right;
            }
        }
        public BinaryTreeProblems()
        {

        }

        public static bool CheckChildSum(Node root)
        {
            if (root.Left == null && root.Right == null)
                return true;
            if (root.Right.Value + root.Left.Value != root.Value)
                return false;
            return CheckChildSum(root.Left) && CheckChildSum(root.Right);
        }

        /*		10
			5		5
		   2  3*/
    }
}