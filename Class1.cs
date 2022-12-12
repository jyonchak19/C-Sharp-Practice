using System;

public class InterViewProblems
{
    public InterViewProblems()
    {

    }

    public void RotateMatrix(int[][] matrix)
    {
        int n = matrix.Lenght;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int temp = matrix[i][j];
                matrix[i][j] = matrix[j][n - i];
                matrix[j][n - i] = temp;
            }
        }
    }
}