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
                for (int j = 0; j < n; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[j, n - i];
                    matrix[j, n - i] = temp;
                }
            }
        }
    }
}