using System;
using System.Data;
using System.Linq;

namespace KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            if (matrixSize < 3)
            {
                Console.WriteLine(0);

                return;
            }

            char[,] chessboard = new char[matrixSize, matrixSize];

            FillMatrix(matrixSize, chessboard);

            int knightsRemoved = 0;

            while (true)
            {
                int mostAttackingCount = 0;
                int mostAttackingRow = 0;
                int mostAttackingCol = 0;

                for (int row = 0; row < matrixSize; row++)
                {
                    for (int col = 0; col < matrixSize; col++)
                    {
                        if (chessboard[row, col] == 'K')
                        {
                            int attackedKnights = CountAttackedKnights(row, col, chessboard);

                            if (attackedKnights > mostAttackingCount)
                            {
                                mostAttackingCount = attackedKnights;
                                mostAttackingRow = row;
                                mostAttackingCol = col;
                            }
                        }
                    }
                }

                if (mostAttackingCount == 0) break;

                else
                {
                    chessboard[mostAttackingRow, mostAttackingCol] = '0';

                    knightsRemoved++;
                }
            }

            Console.WriteLine(knightsRemoved);
        }

        private static void FillMatrix(int matrixSize, char[,] chessBoard)
        {
            for (int row = 0; row < matrixSize; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < matrixSize; col++)
                    chessBoard[row, col] = rowData[col];
            }
        }

        private static int CountAttackedKnights(int row, int col, char[,] chessboard)
        {
            int attackedKnights = 0;

            //Left-Up

            if (IsCellValid(row - 1, col - 2, chessboard.GetLength(0)))
            {
                if (chessboard[row - 1, col - 2] == 'K')
                    attackedKnights++;
            }

            //Left-Down

            if (IsCellValid(row - 1, col + 2, chessboard.GetLength(0)))
            {
                if (chessboard[row - 1, col + 2] == 'K')
                    attackedKnights++;
            }

            //Right-Up

            if (IsCellValid(row + 1, col - 2, chessboard.GetLength(0)))
            {
                if (chessboard[row + 1, col - 2] == 'K')
                    attackedKnights++;
            }

            //Right-Down

            if (IsCellValid(row + 1, col + 2, chessboard.GetLength(0)))
            {
                if (chessboard[row + 1, col + 2] == 'K')
                    attackedKnights++;
            }

            //Up-Left

            if (IsCellValid(row - 2, col - 1, chessboard.GetLength(0)))
            {
                if (chessboard[row - 2, col - 1] == 'K')
                    attackedKnights++;
            }

            //Up-Right

            if (IsCellValid(row - 2, col + 1, chessboard.GetLength(0)))
            {
                if (chessboard[row - 2, col + 1] == 'K')
                    attackedKnights++;
            }

            //Down-Left

            if (IsCellValid(row + 2, col - 1, chessboard.GetLength(0)))
            {
                if (chessboard[row + 2, col - 1] == 'K')
                    attackedKnights++;
            }

            //Down-Right

            if (IsCellValid(row + 2, col + 1, chessboard.GetLength(0)))
            {
                if (chessboard[row + 2, col + 1] == 'K')
                    attackedKnights++;
            }

            return attackedKnights;
        }

        private static bool IsCellValid(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }
    }
}
