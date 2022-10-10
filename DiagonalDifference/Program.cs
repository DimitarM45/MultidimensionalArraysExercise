using System;
using System.Linq;

namespace DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(0); col++)
                    matrix[row, col] = rowData[col];
            }

            Console.WriteLine(FindDiagonalSumDifference(matrix));
        }

        static int FindDiagonalSumDifference(int[,] matrix)
        {
            int primaryDiagSum = 0;
            int secondaryDiagSum = 0;

            for (int row = 0, i = matrix.GetLength(0) - 1; row < matrix.GetLength(0); row++, i--)
            {
                primaryDiagSum += matrix[row, row];
                secondaryDiagSum += matrix[row, i];
            }

            return Math.Abs(primaryDiagSum - secondaryDiagSum);
        }
    }
}
