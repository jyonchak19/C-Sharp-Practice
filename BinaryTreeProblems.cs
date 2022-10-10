namespace CSharpPracticeApp
{
    using System;

    public class BinaryTreeProblems
    {
        public class BinaryTreeNode
        {
            public int Value { get; set; }
            public BinaryTreeNode Left { get; set; }
            public BinaryTreeNode Right { get; set; }
        }
        public BinaryTreeProblems()
        {

        }

        public static bool CheckTree(BinaryTreeNode root)
        {
            if (root.Left == null && root.Right == null)
                return true;
            if (root.Right.Value + root.Left.Value != root.Value)
                return false;
            return CheckTree(root.Left) && CheckTree(root.Right);
        }

        /*		10
			5		5
		   2  3*/
    }
}