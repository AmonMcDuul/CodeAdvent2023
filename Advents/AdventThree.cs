using System;
using System.Collections.Generic;
using System.IO;

namespace Advents
{
    public class AdventThree
    {
        public static void Solution()
        {
            string filePath = "./Inputs/adventThreeInput.txt";
            string[] lines = File.ReadAllLines(filePath);
            char[,] matrix = CreateMatrix(lines);

            var results = CheckIfTouched(matrix);
            int sumOfAll = 0;

            foreach (var result in results)
            {
                sumOfAll += int.Parse(result);
            }
            System.Console.WriteLine($"sum of all: {sumOfAll}");
        }

        static char[,] CreateMatrix(string[] lines)
        {
            int rows = lines.Length;
            int cols = lines[0].Length;
            char[,] matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = lines[i][j];
                }
            }
            return matrix;
        }

        static List<string> CheckIfTouched(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            bool isNewNumber = true;
            List<string> results = new List<string>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (char.IsDigit(matrix[i, j]))
                    {
                        if (IsTouched(matrix, i, j))
                        {
                            string touchedNumber = ExtractNumber(matrix, i, j);
                            if (isNewNumber)
                            {
                                results.Add(touchedNumber);
                            }
                            isNewNumber = false;
                        }
                    }
                    else
                    {
                        isNewNumber = true;
                    }
                }
            }

            return results;
        }

        static bool IsTouched(char[,] matrix, int row, int col)
        {
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };
            List<char> charsToCheck = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.'];
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int k = 0; k < 8; k++)
            {
                int newRow = row + dx[k];
                int newCol = col + dy[k];

                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
                {
                    if (!charsToCheck.Contains(matrix[newRow, newCol]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static string ExtractNumber(char[,] matrix, int row, int col)
        {
            int cols = matrix.GetLength(1);
            string number = "";

            for (int j = col; j >= 0 && char.IsDigit(matrix[row, j]); j--)
            {
                number = matrix[row, j] + number;
            }

            for (int j = col + 1; j < cols && char.IsDigit(matrix[row, j]); j++)
            {
                number += matrix[row, j];
            }
            return number;
        }
    }
}
