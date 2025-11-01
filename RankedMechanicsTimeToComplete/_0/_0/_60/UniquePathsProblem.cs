namespace LeetCodeSolutions._0._0._60;

/***
URL: https://leetcode.com/problems/unique-paths
Number: 62
Difficulty: Medium
 */
public class UniquePathsProblem
{
    public int UniquePaths(int m, int n)
    {
        var dp = new int[m][];

        for (var i = 0; i < m; i++)
        {
            dp[i] = new int[n];

            for (var j = 0; j < n; j++)
            {
                dp[i][j] = 1;
            }
        }

        for (var i = 1; i < m; i++)
        {
            for (var j = 1; j < n; j++)
            {
                dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
            }
        }

        return dp[m - 1][n - 1];
    }
}
