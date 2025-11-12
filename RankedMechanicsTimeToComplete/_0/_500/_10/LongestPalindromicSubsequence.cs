namespace LeetCodeSolutions._0._500._10;

/***
URL: https://leetcode.com/problems/longest-palindromic-subsequence
Number: 516
Difficulty: Medium
*/
public class LongestPalindromicSubsequence
{
    public int LongestPalindromeSubseq(string s)
    {
        var memory = new Dictionary<(int, int), int>();

        return FoundLongestPalindrome(s, 0, s.Length - 1, memory);
    }

    private int FoundLongestPalindrome(string s, int leftIndex, int rightIndex, Dictionary<(int, int), int> memory)
    {
        if (memory.TryGetValue((leftIndex, rightIndex), out var result))
        {
            return result;
        }

        var diff = rightIndex - leftIndex;

        if (diff < 0)
        {
            return 0;
        }

        var equals = s[leftIndex] == s[rightIndex];

        if (diff == 0)
        {
            result = 1;
        }
        else if (diff == 1)
        {
            result = equals ? 2 : 1;
        }
        else
        {
            if (equals)
            {
                result = 2 + FoundLongestPalindrome(s, leftIndex + 1, rightIndex - 1, memory);
            }

            result = Math.Max(result, FoundLongestPalindrome(s, leftIndex + 1, rightIndex, memory));
            result = Math.Max(result, FoundLongestPalindrome(s, leftIndex, rightIndex - 1, memory));
        }

        memory.Add((leftIndex, rightIndex), result);

        return result;
    }
}
