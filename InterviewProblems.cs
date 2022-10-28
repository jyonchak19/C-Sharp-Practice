namespace CSharpPracticeApp
{

    using System;
    using System.Collections;

    public class InterviewProblems
    {
        public static void RotateMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = temp;
                }
            }

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n / 2; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, n - j - 1];
                    matrix[i, n - j - 1] = temp;
                }
            }
        }

        public static bool isValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach(char c in s)
            {
                if (c == '(' || c == '[' || c == '{')
                    stack.Push(c);
                else if (stack.Count > 0 && c == ')' && stack.Peek() == '(')
                {
                    stack.Pop();
                }
                else if (stack.Count > 0 && c == ']' && stack.Peek() == '[')
                {
                    stack.Pop();
                }
                else if (stack.Count > 0 && c == '}' && stack.Peek() == '{')
                {
                    stack.Pop();
                }
            }
            return stack.Count == 0;
        }

        public static bool isValid2(string s)
        {
            ArrayList list = new ArrayList();
            int index;

            foreach (char c in s)
            {
                if (c == '(' || c == '[' || c == '{')
                    list.Add(c);
                else if (list.Count > 0 && c == ')')
                {
                    index = list.IndexOf('(');
                    if (index > -1)
                        list.RemoveAt(index);
                    else
                        return false;
                }
                else if (list.Count > 0 && c == ']')
                {
                    index = list.IndexOf('[');
                    if (index > -1)
                        list.RemoveAt(index);
                    else
                        return false;
                }
                else if (list.Count > 0 && c == '}')
                {
                    index = list.IndexOf('{');
                    if (index > -1)
                        list.RemoveAt(index);
                    else
                        return false;
                }
            }

            return list.Count == 0;
        }

        public static Tuple<int, int> twoSumBF(int[] nums, int target)
        {
            for(int i = 0; i < nums.Length; i++)
            {
                for(int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                        return new Tuple<int, int>(i, j);
                }
            }
            return new Tuple<int, int>(-1, -1);
        }

        public static Tuple<int, int> twoSumOptimized(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for(int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (dict.ContainsKey(complement))
                    return new Tuple<int, int>(dict[complement], i);
                else
                    dict.Add(nums[i], i);
            }
            return new Tuple<int, int>(-1, -1);
        }
    }
}