using System.Text.RegularExpressions;

namespace Advents
{
    public class AdventFour
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
                string tempNum = "";
                bool toggle = false;
                List<int> scratchCard = [];
                List<int> numbersToCheck = [];
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
                int tempResult = 0;
                foreach (int i in scratchCard)
                {
                    if (numbersToCheck.Contains(i))
                    {
                        if (tempResult == 0)
                        {
                            tempResult = 1;
                        }
                        else
                        {
                            tempResult *= 2;
                        }
                    }
                }
                result += tempResult;
            }
            System.Console.WriteLine($"Result: {result}");
        }
    }
}