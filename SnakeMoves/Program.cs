using System;
using System.Data;
using System.Linq;
using System.Text;

namespace SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] snakeMatrix = new char[matrixSize[0], matrixSize[1]];

            string rowData = Console.ReadLine();

            PopulateSnakeMatrix(snakeMatrix, rowData);

            PrintMatrix(snakeMatrix);
        }

        private static void PopulateSnakeMatrix(char[,] snakeMatrix, string rowData)
        {
            int index = 0;

            for (int row = 0; row < snakeMatrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < snakeMatrix.GetLength(1); col++)
                    {
                        snakeMatrix[row, col] = rowData[index++];

                        if (index == rowData.Length) index = 0;
                    }
                }

                else
                {
                    for (int col = snakeMatrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        snakeMatrix[row, col] = rowData[index++];

                        if (index == rowData.Length) index = 0;
                    }
                }
            }
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                    Console.Write($"{matrix[row, col]}");

                Console.WriteLine();
            }
        }
    }
}
