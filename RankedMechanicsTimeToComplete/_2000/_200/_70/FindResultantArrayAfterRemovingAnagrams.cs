namespace LeetCodeSolutions._2000._200._70;

/***
URL: https://leetcode.com/problems/find-resultant-array-after-removing-anagrams
Number: 2273
Difficulty: Easy
 */
public class FindResultantArrayAfterRemovingAnagrams
{
    public IList<string> RemoveAnagrams(string[] words)
    {
        var returnList = new List<string>();

        for (var i = words.Length - 1; i > 0; i--)
        {
            if (AreAnagrams(words[i], words[i - 1]))
            {
                continue;
            }

            returnList.Add(words[i]);
        }

        returnList.Add(words[0]);
        returnList.Reverse();

        return returnList;
    }

    private bool AreAnagrams(string firstString, string secondString)
    {
        var firstDict = new Dictionary<char, int>();

        foreach (var ch in firstString)
        {
            if (!firstDict.TryGetValue(ch, out var value))
            {
                value = 0;
                firstDict.Add(ch, value);
            }

            firstDict[ch] = value + 1;
        }

        var secondDict = new Dictionary<char, int>();

        foreach (var ch in secondString)
        {
            if (!secondDict.TryGetValue(ch, out var value))
            {
                value = 0;
                secondDict.Add(ch, value);
            }

            secondDict[ch] = value + 1;
        }

        if (firstDict.Count != secondDict.Count)
        {
            return false;
        }

        foreach (var (ch, count) in firstDict)
        {
            if (secondDict.TryGetValue(ch, out var value) && value == count)
            {
                continue;
            }

            return false;
        }

        return true;
    }
}
