namespace LeetCodeSolutions._2000._400._30;

/***
URL: https://leetcode.com/problems/paths-in-matrix-whose-sum-is-divisible-by-k
Number: 2435
Difficulty: Hard
 */
public class PathsinMatrixWhoseSumIsDivisiblebyK
{
    private const int MOD = 1_000_000_007;

    public int NumberOfPaths(int[][] grid, int k)
    {
        int m = grid.Length, n = grid[0].Length;

        // dp[j][r] = ways to reach cell (i,j) with remainder r
        var dp = Create2D(n, k);
        var prev = Create2D(n, k);

        for (var i = 0; i < m; i++)
        {
            // swap prev and dp
            (dp, prev) = (prev, dp);

            // clear dp row
            for (var j = 0; j < n; j++)
            {
                Array.Clear(dp[j], 0, k);
            }

            for (var j = 0; j < n; j++)
            {
                var val = grid[i][j] % k;

                if (i == 0 && j == 0)
                {
                    dp[0][val] = 1;

                    continue;
                }

                // from top
                if (i > 0)
                {
                    for (var r = 0; r < k; r++)
                    {
                        if (prev[j][r] != 0)
                        {
                            var newR = (r + val) % k;
                            dp[j][newR] = (dp[j][newR] + prev[j][r]) % MOD;
                        }
                    }
                }

                // from left
                if (j > 0)
                {
                    for (var r = 0; r < k; r++)
                    {
                        if (dp[j - 1][r] != 0)
                        {
                            var newR = (r + val) % k;
                            dp[j][newR] = (dp[j][newR] + dp[j - 1][r]) % MOD;
                        }
                    }
                }
            }
        }

        return dp[n - 1][0];
    }

    private static int[][] Create2D(int rows, int cols)
    {
        var arr = new int[rows][];

        for (var i = 0; i < rows; i++)
        {
            arr[i] = new int[cols];
        }

        return arr;
    }
}
