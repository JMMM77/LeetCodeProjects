namespace LeetCodeSolutions._0._700._10;

/***
URL: https://leetcode.com/problems/minimum-ascii-delete-sum-for-two-strings
Number: 712
Difficulty: Medium
 */
public class MinimumASCIIDeleteSumforTwoStrings
{
    public int MinimumDeleteSum(string s1, string s2)
    {
        var n = s1.Length;
        var m = s2.Length;
        var dp = new int[n + 1][];

        for (var i = 0; i < n + 1; i++)
        {
            dp[i] = new int[m + 1];
            dp[i][0] = 0; // Num of s1 that matches ""
        }

        for (var i = 1; i < m + 1; i++)
        {
            dp[0][i] = 0; // Num of s2 that matches ""
        }

        // Longest common subsequence
        for (var i = 1; i < n + 1; i++)
        {
            for (var j = 1; j < m + 1; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                {
                    dp[i][j] = dp[i - 1][j - 1] + s1[i - 1];
                    continue;
                }

                dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j - 1]);
            }
        }

        return GetAsciiSum(s1) + GetAsciiSum(s2) - (2 * dp[n][m]);
    }

    private static int GetAsciiSum(string s)
    {
        var totalsum = 0;

        foreach (var ch in s)
        {
            totalsum += ch;
        }

        return totalsum;
    }
}
