namespace LeetCodeSolutions._0._700._40;

/***
URL: https://leetcode.com/problems/shortest-completing-word
Number: 748
Difficulty: Easy
 */
public class ShortestCompletingWordProblem
{
    public string ShortestCompletingWord(string licensePlate, string[] words)
    {
        var licenseCount = new int[26];

        licensePlate = licensePlate.ToLower();

        foreach (var ch in licensePlate)
        {
            if (char.IsLetter(ch))
            {
                if (char.IsLetter(ch))
                {
                    licenseCount[char.ToLower(ch) - 'a']++;
                }
            }
        }

        var returnWord = "";
        var returnWordLength = int.MaxValue;

        foreach (var word in words)
        {
            if (word.Length >= returnWordLength)
            {
                continue;
            }

            if (WordsMatch(word, licenseCount))
            {
                returnWord = word;
                returnWordLength = word.Length;
            }
        }

        return returnWord;
    }

    private static bool WordsMatch(string word, int[] licenseCount)
    {
        var wordCount = new int[26];

        foreach (var c in word)
        {
            if (char.IsLetter(c))
            {
                wordCount[char.ToLower(c) - 'a']++;
            }
        }

        for (var i = 0; i < 26; i++)
        {
            if (wordCount[i] < licenseCount[i])
            {
                return false;
            }
        }

        return true;
    }
}
