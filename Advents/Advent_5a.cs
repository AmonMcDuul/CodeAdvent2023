using System;
using System.IO;
using System.Linq;

namespace Advents
{
    public class Advent_5a
    {
        public static void Solution()
        {
            string filePath = "./Inputs/advent_5_input.txt";
            string[] lines = File.ReadAllLines(filePath);
            List<int> seeds = new List<int>();

            bool seedsBool = false;

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                System.Console.WriteLine(line);
                if (seedsBool)
                {
                    var cleanLine = line.Replace(" ", ",");
                    seeds = cleanLine.Trim(',').Split(',').Select(int.Parse).ToList();
                    seedsBool = false;
                }
                if (line.Contains("seeds:"))
                {
                    seedsBool = true;
                }
            }
        }
    }
}
