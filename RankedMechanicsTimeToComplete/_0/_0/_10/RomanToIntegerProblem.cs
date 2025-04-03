namespace LeetCodeSolutions._0._0._10;

/***
URL: https://leetcode.com/problems/roman-to-integer
Number: 13
Difficulty: Easy
 */
public class RomanToIntegerProblem
{
    public int RomanToInt(string s)
    {
        var romanDictionary = new Dictionary<string, int>()
        {
            { "I", 1 },
            { "V", 5 },
            { "X", 10 },
            { "L", 50 },
            { "C", 100 },
            { "D", 500 },
            { "M", 1000 },
        };

        var combinationDictionary = new Dictionary<string, int>()
        {
            { "IV", 4 },
            { "IX", 9 },
            { "XL", 40 },
            { "XC", 90 },
            { "CD", 400 },
            { "CM", 900 },
        };

        var returnNumber = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var combinedCharacters = "";
            var currentChar = s[i];

            if (i < s.Length - 1)
            {
                combinedCharacters = string.Concat(currentChar, s[i + 1]);
            }

            if (combinationDictionary.TryGetValue(combinedCharacters, out var value))
            {
                returnNumber += value;
                i++;
                continue;
            }

            returnNumber += romanDictionary[currentChar.ToString()];
        }

        return returnNumber;
    }
}