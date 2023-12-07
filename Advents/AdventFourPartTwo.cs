using System.Text.RegularExpressions;

namespace Advents
{
    public class AdventFourPartTwo
    {
        public static void Solution()
        {
            string filePath = "./Inputs/adventFourInput.txt";
            string[] lines = File.ReadAllLines(filePath);
            int result = CalculateResults(lines);
            System.Console.WriteLine($"Total: {result}");
        }

        public static int CalculateResults(string[] lines)
        {
            int result = 0;
            var memo = new Dictionary<int, int>();
            for (int index = 0; index < lines.Length; index++)
            {
                (List<int> scratchCard, List<int> numbersToCheck) = SeparateCards(lines[index]);

                if (!memo.ContainsKey(index))
                {
                    memo[index] = 1;
                }
                else
                {
                    memo[index] += 1;
                }

                int numberOfWins = NumberOfWins(scratchCard, numbersToCheck);

                for (int plays = 0; plays < memo[index]; plays++)
                {
                    for (int nextCard = 1; nextCard <= numberOfWins; nextCard++)
                    {
                        int nextIndex = nextCard + index;
                        if (nextIndex < lines.Length)
                        {
                            if (!memo.ContainsKey(nextIndex))
                            {
                                memo[nextIndex] = 1;
                            }
                            else
                            {
                                memo[nextIndex] += 1;
                            }
                        }
                    }
                }
            }
            foreach (var kvp in memo)
            {
                result += kvp.Value;
            }
            return result;
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

        public static int NumberOfWins(List<int> scratchCard, List<int> numbersToCheck)
        {
            int result = 0;
            foreach (int i in scratchCard)
            {
                if (numbersToCheck.Contains(i))
                {
                    result += 1;
                }
            }
            return result;
        }
    }
}
