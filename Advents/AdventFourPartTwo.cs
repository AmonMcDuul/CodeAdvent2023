using System.Text.RegularExpressions;

namespace Advents
{
    public class AdventFourPartTwo
    {
        public static void Solution()
        {
            string filePath = "./Inputs/adventFourInput.txt";
            string[] lines = File.ReadAllLines(filePath);
            int result = 0;
            foreach (string line in lines)
            {
                Match match = Regex.Match(line, @"Card\s*(\d+):");
                string cleanLine = line.Replace(match.Value, "").Replace(":", "").Trim();
                cleanLine = cleanLine.Replace(" ", ",");

                (List<int> scratchCard, List<int> numbersToCheck) = SeparateCards(cleanLine);

                result += CalculateResults(scratchCard, numbersToCheck);
            }
            System.Console.WriteLine($"Result: {result}");
        }
        public static (List<int>, List<int>) SeparateCards(string cleanLine)
        {
            List<int> scratchCard = [];
            List<int> numbersToCheck = [];
            string tempNum = "";
            bool toggle = false;
            for (int i = 0; i <= cleanLine.Length - 1; i++)
            {
                if (cleanLine[i] == '|')
                {
                    toggle = true;
                    continue;
                }
                if (cleanLine[i] != ',')
                {
                    tempNum += cleanLine[i];
                }
                if (cleanLine[i] == ',' && tempNum != "")
                {
                    if (!toggle)
                    {
                        scratchCard.Add(int.Parse(tempNum));
                    }
                    if (toggle)
                    {
                        numbersToCheck.Add(int.Parse(tempNum));
                    }
                    tempNum = "";
                }
                if (i == cleanLine.Length - 1)
                {
                    numbersToCheck.Add(int.Parse(tempNum));
                    break;
                }
            }
            return (scratchCard, numbersToCheck);
        }

        public static int CalculateResults(List<int> scratchCard, List<int> numbersToCheck)
        {
            int result = 0;
            foreach (int i in scratchCard)
            {
                if (numbersToCheck.Contains(i))
                {
                    if (result == 0)
                    {
                        result = 1;
                    }
                    else
                    {
                        result *= 2;
                    }
                }
            }
            return result;
        }
    }
}