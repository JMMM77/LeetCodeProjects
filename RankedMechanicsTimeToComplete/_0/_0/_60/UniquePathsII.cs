namespace LeetCodeSolutions._0._0._60;

/***
URL: https://leetcode.com/problems/unique-paths-ii
Number: 63
Difficulty: Medium
 */
public class UniquePathsII
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        var firstBlock = obstacleGrid[0][0];

        if (firstBlock == 1)
        {
            return 0;
        }

        var xLength = obstacleGrid.Length;
        var yLength = obstacleGrid[0].Length;
        var dp = new int[obstacleGrid.Length][];
        dp[0] = new int[yLength];
        dp[0][0] = 1;

        for (var i = 1; i < xLength; i++)
        {
            dp[i] = new int[yLength];

            if (obstacleGrid[i][0] == 1)
            {
                dp[i][0] = 0;
            }
            else
            {
                dp[i][0] = dp[i - 1][0];
            }
        }

        for (var i = 1; i < yLength; i++)
        {
            if (obstacleGrid[0][i] == 1)
            {
                dp[0][i] = 0;
            }
            else
            {
                dp[0][i] = dp[0][i - 1];
            }
        }

        for (var i = 1; i < xLength; i++)
        {
            for (var j = 1; j < yLength; j++)
            {
                if (obstacleGrid[i][j] == 1)
                {
                    dp[i][j] = 0;
                }
                else
                {
                    dp[i][j] = dp[i][j - 1] + dp[i - 1][j];
                }
            }
        }

        return dp[^1][^1];
    }
}
