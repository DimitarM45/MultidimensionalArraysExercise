using System;
using System.Linq;

namespace MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[matrixSize[0], matrixSize[1]];

            FillMatrix(matrix);

            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "END")
            {
                if (command[0] == "swap" && command.Length == 5)
                {
                    int firstRow = int.Parse(command[1]);
                    int firstCol = int.Parse(command[2]);
                    int secondRow = int.Parse(command[3]);
                    int secondCol = int.Parse(command[4]);

                    bool firstCoordsAreValid = firstRow >= 0 && firstRow < matrix.GetLength(0) && firstCol >= 0 && firstCol < matrix.GetLength(1);
                    bool secondCoordsAreValid = secondRow >= 0 && secondRow < matrix.GetLength(0) && secondCol >= 0 && secondCol < matrix.GetLength(1);

                    if (firstCoordsAreValid && secondCoordsAreValid)
                    {
                        string tempValue = matrix[firstRow, firstCol];

                        matrix[firstRow, firstCol] = matrix[secondRow, secondCol];

                        matrix[secondRow, secondCol] = tempValue;

                        PrintMatrix(matrix);
                    }
                    else
                        Console.WriteLine("Invalid input!");
                }
                else
                    Console.WriteLine("Invalid input!");

                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }

        static void FillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                    matrix[row, col] = rowData[col];
            }
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                    Console.Write($"{matrix[row, col]} ");

                Console.WriteLine();
            }
        }
    }
}
