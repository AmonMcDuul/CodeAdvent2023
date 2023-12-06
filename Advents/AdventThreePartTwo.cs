namespace Advents
{
    public class AdventThreePartTwo
    {
        public static void Solution()
        {
            string filePath = "./Inputs/adventThreeInput.txt";
            string[] lines = File.ReadAllLines(filePath);

            char[,] matrix = CreateMatrix(lines);

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            List<List<string>> connectedNumbers = new List<List<string>>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == '*')
                    {
                        List<string> numbers = ExtractConnectedNumbers(matrix, i, j);
                        if (numbers.Count == 2)
                        {
                            connectedNumbers.Add(numbers);
                        }
                    }
                }
            }

            int result = 0;
            foreach (var numbers in connectedNumbers)
            {
                result += int.Parse(numbers[0]) * int.Parse(numbers[1]);
            }
            System.Console.WriteLine($"Result: {result}");
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

        static List<string> ExtractConnectedNumbers(char[,] matrix, int row, int col)
        {
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            string currentNumber = "";
            List<string> connectedNumbers = new List<string>();

            for (int k = 0; k < 8; k++)
            {
                int newRow = row + dx[k];
                int newCol = col + dy[k];

                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
                {
                    if (char.IsDigit(matrix[newRow, newCol]))
                    {
                        string number = ExtractNumber(matrix, newRow, newCol);
                        if (number != currentNumber)
                        {
                            connectedNumbers.Add(number);
                            currentNumber = number;
                        }
                    }
                    else
                    {
                        currentNumber = "";
                    }
                }
            }
            return connectedNumbers;
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