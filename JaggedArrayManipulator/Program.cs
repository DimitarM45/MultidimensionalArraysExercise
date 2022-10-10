using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixRows = int.Parse(Console.ReadLine());
            
            int[][] jaggedArray = new int[matrixRows][];

            for (int i = 0; i < matrixRows; i++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[i] = rowData;
            }

            for (int i = 0; i < jaggedArray.GetLength(0) - 1; i++)
            {
                if (jaggedArray[i].Length == jaggedArray[i + 1].Length)
                {
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                        jaggedArray[i][j] *= 2;

                    for (int j = 0; j < jaggedArray[i + 1].Length; j++)
                        jaggedArray[i + 1][j] *= 2;
                }

                else
                {
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                        jaggedArray[i][j] /= 2;

                    for (int j = 0; j < jaggedArray[i + 1].Length; j++)
                        jaggedArray[i + 1][j] /= 2;
                }
            }

            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                int row = int.Parse(input[1]);
                int column = int.Parse(input[2]);
                int value = int.Parse(input[3]);

                if (row >= 0 
                    && row < jaggedArray.Length
                    && column >= 0
                    && column < jaggedArray[row].Length)
                {
                    switch (input[0])
                    {
                        case "Add":
                            jaggedArray[row][column] += value;
                            break;

                        case "Subtract":
                            jaggedArray[row][column] -= value;
                            break;

                        default:
                            break;
                    }
                }

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (int[] array in jaggedArray)
                Console.WriteLine(string.Join(' ', array));
        }
    }
}
