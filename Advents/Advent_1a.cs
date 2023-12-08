namespace Advents
{
    public class Advent_1a
    {
        public static void Solution()
        {
            int sumOfAll = 0;

            string filePath = "./Inputs/adventOneInput.txt";
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                int? first = null;
                int? last = null;
                int? tempFirst = null;
                int? tempLast = null;

                for (int i = 0; i <= line.Length / 2 + 1; i++)
                {
                    char firstChar = line[i];
                    char lastChar = line[line.Length - 1 - i];

                    updateNumbers();

                    if (first != null && last != null)
                    {
                        printSolution();
                        break;
                    }

                    if (i >= line.Length / 2 + 1)
                    {
                        if (last == null)
                        {
                            last = tempLast ?? first;
                        }
                        if (first == null)
                        {
                            first = tempFirst ?? last;
                        }
                        printSolution();
                        break;
                    }

                    void printSolution()
                    {
                        int result = int.Parse($"{first}{last}");
                        sumOfAll += result;
                    }

                    void updateNumbers()
                    {
                        if (char.IsDigit(lastChar) && first == null && last != null)
                        {
                            tempFirst = int.Parse(lastChar.ToString());
                        }

                        if (char.IsDigit(firstChar) && last == null && first != null)
                        {
                            tempLast = int.Parse(firstChar.ToString());
                        }

                        if (char.IsDigit(firstChar) && first == null)
                        {
                            first = int.Parse(firstChar.ToString());
                        }

                        if (char.IsDigit(lastChar) && last == null)
                        {
                            last = int.Parse(lastChar.ToString());
                        }
                    }
                }
            }
            Console.WriteLine($"Sum of all: {sumOfAll}");
        }
    }
}
