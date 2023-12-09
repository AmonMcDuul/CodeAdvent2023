using System;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace Advents
{
    public class Advent_5a
    {
        public static void Solution()
        {
            string filePath = "C:\\repos\\CodeAdvent2023\\CodeAdvent2023\\Inputs\\advent_5_input.txt";
            string[] lines = File.ReadAllLines(filePath);
            List<long> seeds = ExtractSeeds(lines[0]);
            long lowestNumber = 999999999;
            foreach (long seed in seeds)
            {
                long result = CalculateSeed(seed, lines);
                if (result < lowestNumber)
                {
                    lowestNumber = result;
                }
            }
            System.Console.WriteLine(lowestNumber);
        }

        public static long CalculateSeed(long seed, string[] lines)
        {
            Dictionary<long, long> resultDict = new Dictionary<long, long>();
            bool flag = true;
            long result = seed;
            for (long i = 2; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    flag = true;
                    continue;
                }
                if (lines[i].Contains(':'))
                {
                    continue;
                }
                var cleanLine = lines[i].Replace(" ", ",");
                List<long> newLine = cleanLine.Trim(',').Split(',').Select(long.Parse).ToList();
                long newLocation = 0;

                if (result >= newLine[1] && result < newLine[1] + newLine[2])
                {
                    newLocation = result - (newLine[1] - newLine[0]);
                    System.Console.WriteLine($"id {i} result {result}, new {newLocation}");
                    if (flag == true)
                    {
                        result = newLocation;
                        flag = false;
                    }
                }
            }
            return result;
        }

        public static List<long> ExtractSeeds(string line)
        {
            var cleanLine = line.Replace("seeds: ", "").Replace(" ", ",");
            List<long> seeds = cleanLine.Trim(',').Split(',').Select(long.Parse).ToList();
            return seeds;
        }
    }
}
