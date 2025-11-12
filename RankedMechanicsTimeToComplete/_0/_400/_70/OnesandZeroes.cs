namespace LeetCodeSolutions._0._400._70;

/***
URL: https://leetcode.com/problems/ones-and-zeroes
Number: 474
Difficulty: Medium
 */
public class OnesandZeroes
{
    public int FindMaxForm(string[] strs, int m, int n)
    {
        // dp[i][j] = max number of strings that can be formed with i zeros and j ones
        var dp = new int[m + 1, n + 1];

        foreach (var s in strs)
        {
            var zeros = 0;
            var ones = 0;

            foreach (var ch in s)
            {
                if (ch == '0')
                {
                    zeros++;
                }
                else
                {
                    ones++;
                }
            }

            // Traverse backwards to avoid overwriting needed values
            for (var i = m; i >= zeros; i--)
            {
                for (var j = n; j >= ones; j--)
                {
                    dp[i, j] = Math.Max(dp[i, j], 1 + dp[i - zeros, j - ones]);
                }
            }
        }

        return dp[m, n];
    }
}
