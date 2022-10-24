namespace CSharpPracticeApp
{

    using System;

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
    }
}