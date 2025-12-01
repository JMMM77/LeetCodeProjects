namespace LeetCodeSolutions._1000._900._30;

/***
URL: https://leetcode.com/problems/unique-length-3-palindromic-subsequences
Number: 1930
Difficulty: Medium
 */
public class UniqueLength3PalindromicSubsequences
{
    public int CountPalindromicSubsequence(string s)
    {
        var occurences = new Dictionary<char, int[]>(); // int[] = [first, last]

        for (var i = 0; i < s.Length; i++)
        {
            var thisChar = s[i];

            if (!occurences.TryGetValue(thisChar, out var value))
            {
                value = [i, i];
                occurences[thisChar] = [i, i];
            }

            value[1] = i;
            occurences[thisChar] = value;
        }

        var foundStrings = 0;

        foreach (var occurence in occurences.Values)
        {
            var uniqueChars = new HashSet<char>();

            for (var i = occurence[0] + 1; i < occurence[1]; i++)
            {
                var thisChar = s[i];

                if (uniqueChars.Contains(thisChar))
                {
                    continue;
                }

                uniqueChars.Add(thisChar);
            }

            foundStrings += uniqueChars.Count;
        }

        return foundStrings;
    }
}
