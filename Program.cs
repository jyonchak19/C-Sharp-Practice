namespace CSharpPracticeApp
{
    using System.Collections.Generic;

    /* 
    input (nums): [2,7,11,15], target: 9
    output: [0,1] bc 2 + 7 = 9
    */
    public class Class1
    {
        static void Main(string[] args)
        {
            int[] twoSumArr = { 2, 7, 11, 15 };
            int[] twoSumResult = Class1.TwoSum(twoSumArr, 9);
            foreach(int i in twoSumResult)
            {
                Console.WriteLine(i);
            }

            int[] uniqueOccurrencesArr = { 1, 2, 2, 1, 1, 3 };
            Console.WriteLine("UniqueOccurrences = " + UniqueOccurrences(uniqueOccurrencesArr));
            

            // SOME DIFFERENCES OF C SHARP VS JAVA

            // initialization, ex hashmap/dictionary literals
            var dict = new Dictionary<string, int> {
                {"rafi", 1231},
                {"jacob", 424324},
            };

            // exception handling

            // generics 

            // binary tree

            BinaryTreeProblems.Node BottomLeft = new BinaryTreeProblems.Node(4);
            BinaryTreeProblems.Node BottomRight = new BinaryTreeProblems.Node(6);
            BinaryTreeProblems.Node Top = new BinaryTreeProblems.Node(10, BottomLeft, BottomRight);

            bool result = BinaryTreeProblems.CheckTree(Top);
            Console.WriteLine("CheckTree = " + result);

            BottomLeft.Value = 3;
            BottomRight.Value = 1;
            Top.Value = 5;

            result = BinaryTreeProblems.CheckTree(Top);
            Console.WriteLine("CheckTree2 = " + result);

            // matrix roatation

            int[,] Matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            PrintMatrix(Matrix);
            InterviewProblems.RotateMatrix(Matrix);
            PrintMatrix(Matrix);
            Console.WriteLine();

            //Valid string test

            Console.WriteLine("IsValid with stack");
            string s1 = "(){}[]";
            Console.WriteLine(InterviewProblems.IsValid(s1));
            string s2 = "([)]";
            Console.WriteLine(InterviewProblems.IsValid(s2));
            string s3 = "(3)";
            Console.WriteLine(InterviewProblems.IsValid(s3));
            string s4 = "(]";
            Console.WriteLine(InterviewProblems.IsValid(s4));
            Console.WriteLine();

            Console.WriteLine("IsValid with array list");
            Console.WriteLine(InterviewProblems.IsValid2(s1));
            Console.WriteLine(InterviewProblems.IsValid2(s2));
            Console.WriteLine(InterviewProblems.IsValid2(s3));
            Console.WriteLine(InterviewProblems.IsValid2(s4));
            Console.WriteLine();

            //TwoSum test

            Console.WriteLine("TwoSum brute force");
            int[] nums = new int[] { 2, 7, 11, 15 };
            int target = 9;
            Console.WriteLine(InterviewProblems.TwoSumBF(nums, target));
            Console.WriteLine();

            Console.WriteLine("TwoSum optimized");
            Console.WriteLine(InterviewProblems.TwoSumOptimized(nums, target));
            Console.WriteLine();
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];
                if (dict.ContainsKey(complement))
                    return new int[] { dict[complement], i };

                dict[nums[i]] = i; // in Java: map.put(nums[i], i);
            }

            return new int[] { };
        }

        public static bool UniqueOccurrences(int[] nums)
        {
            var dict = new Dictionary<int, int>();

            for(int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                    dict[nums[i]] = 1;
                else
                    dict[nums[i]]++;
            }

            var set = new HashSet<int>();

            foreach(int numOccurrences in dict.Values)
            {
                if (!set.Contains(numOccurrences))
                    set.Add(numOccurrences);
                else
                    return false;
            }

            return true;
        }

        public static Tuple<string, int> TestMethod() {
            return Tuple.Create("Steve", 1);
        }

        public static void PrintMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}