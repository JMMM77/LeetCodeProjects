namespace LeetCodeSolutions._0._100._30;

/***
URL: https://leetcode.com/problems/word-break
Number: 139
Difficulty: Medium
*/
public class WordBreakProblem
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        var longestWord = 0;
        var wordSet = new HashSet<string>();

        foreach (var word in wordDict)
        {
            longestWord = Math.Max(longestWord, word.Length);
            wordSet.Add(word);
        }

        var memory = new Dictionary<int, bool>();

        return WordBreak(s, longestWord, 0, wordSet, memory);
    }

    private bool WordBreak(string s, int maxLength, int startIndex, HashSet<string> wordSet, Dictionary<int, bool> memory)
    {
        if (startIndex == s.Length)
        {
            return true;
        }

        if (memory.TryGetValue(startIndex, out var result))
        {
            return result;
        }

        var currentWord = "";

        for (var i = startIndex; currentWord.Length < maxLength && i < s.Length; i++)
        {
            currentWord += s[i];

            if (wordSet.Contains(currentWord) && WordBreak(s, maxLength, i + 1, wordSet, memory))
            {
                return true;
            }
        }

        memory.Add(startIndex, false);
        return false;
    }
}
