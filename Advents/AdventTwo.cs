using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Advents
{
    public class AdventTwo
    {
        public static void Solution()
        {
            int result = 0;
            List<Dictionary<string, int>> rangeList = new List<Dictionary<string, int>>
            {
                new Dictionary<string, int>
                {
                    {"red", 12},
                    {"green", 13},
                    {"blue", 14}
                }
            };

            string filePath = "./Inputs/adventTwoInput.txt";
            string[] lines = File.ReadAllLines(filePath);

            string input = string.Join(" ", lines);

            List<List<Dictionary<string, int>>> allGames = ExtractAllGames(input);

            for (int gameIndex = 0; gameIndex < allGames.Count; gameIndex++)
            {
                bool playable = true;
                List<Dictionary<string, int>> rounds = allGames[gameIndex];
                for (int roundIndex = 0; roundIndex < rounds.Count; roundIndex++)
                {
                    foreach (var kvp in rounds[roundIndex])
                    {
                        if (rangeList[0].TryGetValue(kvp.Key, out int rangeValue) && kvp.Value > rangeValue)
                        {
                            playable = false;
                        }
                    }
                }
                if (playable)
                {
                    result += (gameIndex + 1);
                }
            }
            Console.WriteLine($"result: + {result}");
        }

        static List<List<Dictionary<string, int>>> ExtractAllGames(string input)
        {
            List<List<Dictionary<string, int>>> allGames = new List<List<Dictionary<string, int>>>();
            MatchCollection gameMatches = Regex.Matches(input, @"Game (\d+):(.*?)(?=(?:Game \d+:|$))", RegexOptions.Singleline);

            foreach (Match gameMatch in gameMatches)
            {
                string gameContent = gameMatch.Groups[2].Value.Trim();
                string[] roundStrings = gameContent.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                List<Dictionary<string, int>> rounds = new List<Dictionary<string, int>>();

                foreach (var roundString in roundStrings)
                {
                    MatchCollection colorMatches = Regex.Matches(roundString, @"(\d+) (\w+)");
                    Dictionary<string, int> colorQuantities = new Dictionary<string, int>();

                    foreach (Match colorMatch in colorMatches)
                    {
                        string color = colorMatch.Groups[2].Value.ToLower();
                        int quantity = int.Parse(colorMatch.Groups[1].Value);

                        colorQuantities[color] = quantity;
                    }
                    rounds.Add(colorQuantities);
                }
                allGames.Add(rounds);
            }
            return allGames;
        }
    }
}
