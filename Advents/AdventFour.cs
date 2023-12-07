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
                (List<int> scratchCard, List<int> numbersToCheck) = SeparateCards(line);
                result += CalculateResults(scratchCard, numbersToCheck);
            }
            System.Console.WriteLine($"Result: {result}");
        }

        public static (List<int>, List<int>) SeparateCards(string line)
        {
            Match match = Regex.Match(line, @"Card\s*(\d+):");
            string cleanLine = line.Replace(match.Value, "").Replace(":", "").Replace(" ", ",").Replace(",,", ",").Trim();
            string[] parts = cleanLine.Split('|');
            List<int> scratchCard = parts[0].Trim(',').Split(',').Select(int.Parse).ToList();
            List<int> numbersToCheck = parts[1].Trim(',').Split(',').Select(int.Parse).ToList();
            return (scratchCard, numbersToCheck);
        }

        public static int CalculateResults(List<int> scratchCard, List<int> numbersToCheck)
        {
            int result = 0;
            foreach (int i in scratchCard)
            {
                if (numbersToCheck.Contains(i))
                {
                    result = (result == 0) ? 1 : result * 2;
                }
            }
            return result;
        }
    }
}