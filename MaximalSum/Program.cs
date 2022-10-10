using System;
using System.Linq;

namespace MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = new int[matrixSize[0], matrixSize[1]];

            FillMatrix(matrix);

            // By definiton the size of the sub matrix is 3x3, but the program works with any given size, which can be customized below 

            int subMatrixRows = 3;
            int subMatrixCols = 3;

            FindMaxSumSubMatrix(matrix, subMatrixRows, subMatrixCols);
        }

        static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                    matrix[row, col] = rowData[col];
            }
        }

        static void PrintMatrix(int[,] matrix, int maxSumRow, int maxSumCol, int subMatrixRows, int subMatrixCols)
        {
            for (int row = maxSumRow; row < maxSumRow + subMatrixRows; row++)
            {
                for (int col = maxSumCol; col < maxSumCol + subMatrixCols; col++)
                    Console.Write($"{matrix[row, col]} ");

                Console.WriteLine();
            }
        }

        static void FindMaxSumSubMatrix(int[,] matrix, int subMatrixRows, int subMatrixCols)
        {
            if (matrix.GetLength(0) > subMatrixRows - 1 && matrix.GetLength(1) > subMatrixCols - 1)
            {
                int subMatrixSum = 0;
                int maxSum = int.MinValue;

                int maxSumRow = 0;
                int maxSumCol = 0;

                for (int row = 0; row < matrix.GetLength(0) - (subMatrixRows - 1); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1) - (subMatrixCols - 1); col++)
                    {
                        for (int subRow = row; subRow < row + subMatrixRows; subRow++)
                        {
                            for (int subCol = col; subCol < col + subMatrixCols; subCol++)
                                subMatrixSum += matrix[subRow, subCol];
                        }

                        if (subMatrixSum > maxSum)
                        {
                            maxSum = subMatrixSum;

                            maxSumRow = row;
                            maxSumCol = col;
                        }

                        subMatrixSum = 0;
                    }
                }

                Console.WriteLine($"Sum = {maxSum}");

                PrintMatrix(matrix, maxSumRow, maxSumCol, subMatrixRows, subMatrixCols);
            }
        }
    }
}
