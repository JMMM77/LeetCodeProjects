namespace LeetCodeSolutions._0._100._10;

/***
URL: https://leetcode.com/problems/distinct-subsequences
Number: 115
Difficulty: Medium
 */
public class DistinctSubsequences
{
    public int NumDistinct(string s, string t)
    {
        var n = s.Length;
        var m = t.Length;

        // dp[i][j] = number of distinct subsequences of s[0..i-1] that form t[0..j-1]
        var dp = new int[n + 1][];

        for (var i = 0; i < n + 1; i++)
        {
            dp[i] = new int[m + 1];
            dp[i][0] = 1; // there’s one way to form an empty t (delete all of s).
        }

        for (var j = 1; j < m + 1; j++)
        {
            dp[0][j] = 0; // can’t form a non-empty t from an empty s.
        }

        for (var i = 1; i < n + 1; i++)
        {
            for (var j = 1; j < m + 1; j++)
            {
                if (s[i - 1] == t[j - 1])
                {
                    dp[i][j] = dp[i - 1][j - 1] + dp[i - 1][j];

                    continue;
                }

                dp[i][j] = dp[i - 1][j];
            }
        }

        return dp[n][m];
    }
}
