using System;
using System.IO;

namespace Advents
{
    public class AdventTwo
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
                var replacedLine = ReplaceWordsWithNumbers(line);
                for (int i = 0; i <= replacedLine.Length / 2 + 1; i++)
                {
                    char firstChar = replacedLine[i];
                    char lastChar = replacedLine[replacedLine.Length - 1 - i];
                    updateNumbers();

                    if (first != null && last != null)
                    {
                        printSolution();
                        break;
                    }

                    if (i >= replacedLine.Length / 2 + 1)
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
                string ReplaceWordsWithNumbers(string input)
                {
                    var doubleWordsToNumber = new Dictionary<string, string>
                    {
                        {"twone", "21"},
                        {"eightwo", "82"},
                        {"eighthree", "83"},
                        {"oneight", "18"},
                        {"nineight", "98"}
                    };
                    var wordToNumber = new Dictionary<string, string>
                    {
                        {"one", "1"},
                        {"two", "2"},
                        {"three", "3"},
                        {"four", "4"},
                        {"five", "5"},
                        {"six", "6"},
                        {"seven", "7"},
                        {"eight", "8"},
                        {"nine", "9"}
                    };
                    foreach (var word in doubleWordsToNumber)
                    {
                        input = input.Replace(word.Key, word.Value);
                    }

                    foreach (var word in wordToNumber)
                    {
                        input = input.Replace(word.Key, word.Value);
                    }

                    return input;
                }
            }
            Console.WriteLine($"Sum of all: {sumOfAll}");
        }
    }
}
