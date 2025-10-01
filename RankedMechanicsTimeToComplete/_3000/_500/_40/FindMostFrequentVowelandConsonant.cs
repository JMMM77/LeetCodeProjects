namespace LeetCodeSolutions._3000._500._40;

/***
URL: https://leetcode.com/problems/find-most-frequent-vowel-and-consonant
Number: 3541
Difficulty: Easy
 */
public class FindMostFrequentVowelandConsonant
{
    public int MaxFreqSum(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }
        // Had to code this on my phone on the train lol, luckily it was an easy question
        var findVowels = "aeiou";
        var vowels = new Dictionary<char, int>();
        var constants = new Dictionary<char, int>();

        foreach (var c in s)
        {
            if (findVowels.Contains(c))
            {
                if (!vowels.TryAdd(c, 1))
                {
                    vowels[c]++;
                }
            }
            else
            {
                if (!constants.TryAdd(c, 1))
                {
                    constants[c]++;
                }
            }
        }

        if (vowels.Count == 0)
        {
            return constants.Max(x => x.Value);
        }

        if (constants.Count == 0)
        {
            return vowels.Max(x => x.Value);
        }

        return vowels.Max(x => x.Value) + constants.Max(x => x.Value);
    }
}
