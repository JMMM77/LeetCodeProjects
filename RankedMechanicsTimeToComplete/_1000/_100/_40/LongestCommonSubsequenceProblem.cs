namespace LeetCodeSolutions._1000._100._40;

/***
URL: https://leetcode.com/problems/longest-common-subsequence
Number: 1143
Difficulty: Medium
 */
public class LongestCommonSubsequenceProblem
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        var n = text1.Length;
        var m = text2.Length;
        var dp = new int[n + 1][];

        for (var i = 0; i < n + 1; i++)
        {
            dp[i] = new int[m + 1];
            dp[i][0] = 0; // Num of text1 that matches ""
        }

        for (var i = 1; i < m + 1; i++)
        {
            dp[0][i] = 0; // Num of text2 that matches ""
        }

        for (var i = 1; i < n + 1; i++)
        {
            for (var j = 1; j < m + 1; j++)
            {
                if (text1[i - 1] == text2[j - 1])
                {
                    dp[i][j] = dp[i - 1][j - 1] + 1;
                    continue;
                }

                dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j - 1]);
            }
        }

        return dp[n][m];
    }
}
