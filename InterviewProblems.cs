namespace CSharpPracticeApp
{

    using System;

    public class InterviewProblems
    {
        public static void RotateMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            Console.WriteLine(n);
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
    }
}