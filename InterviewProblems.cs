namespace CSharpPracticeApp
{

    using System;
    using System.Collections;

    public class InterviewProblems
    {

        public class LLNode
        {
            public int Value { get; set; }
            public LLNode Next { get; set; }
        }
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

        public static bool IsValid(string s)
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

        public static bool IsValid2(string s)
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

        public static Tuple<int, int> TwoSumBF(int[] nums, int target)
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

        public static Tuple<int, int> TwoSumOptimized(int[] nums, int target)
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

        public static LLNode RemoveNode(LLNode head, int val)
        {

            while(head != null && head.Value == val)
            {
                head = head.Next;
            }

            if (head == null)
                return null;

            LLNode node = head;

            while (node != null && node.Next != null)
            {
                if(node.Next.Value == val)
                {
                    node.Next = node.Next.Next;
                }
                else
                {
                    node = node.Next;
                }
            }

            return head;
        }

        public static LinkedList<int> RemoveNodeCSharpNative(LinkedList<int> ll, int val)
        {
            while (ll.Contains(val))
            {
                ll.Remove(val);
            }
            return ll;
        }
    }
}