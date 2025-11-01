namespace LeetCodeSolutions._0._200._20;

/***
URL: https://leetcode.com/problems/maximal-square
Number: 221
Difficulty: Medium
 */
public class MaximalSquareProblem
{
    public int MaximalSquare(char[][] matrix)
    {
        var xLength = matrix.Length;
        var yLength = matrix[0].Length;
        var dp = new int[matrix.Length][];
        var foundMaxVal = 0;
        dp[0] = new int[yLength];

        for (var i = 0; i < yLength; i++)
        {
            if (matrix[0][i] == '1')
            {
                dp[0][i] = 1;
                foundMaxVal = 1;
            }
            else
            {
                dp[0][i] = 0;
            }
        }

        for (var i = 1; i < xLength; i++)
        {
            dp[i] = new int[yLength];

            if (matrix[i][0] == '1')
            {
                dp[i][0] = 1;
                foundMaxVal = 1;
            }
            else
            {
                dp[i][0] = 0;
            }
        }

        for (var i = 1; i < xLength; i++)
        {
            for (var j = 1; j < yLength; j++)
            {
                if (matrix[i][j] == '0')
                {
                    dp[i][j] = 0;
                    continue;
                }

                var leftVal = dp[i - 1][j];
                var topVal = dp[i][j - 1];

                if (leftVal == 0
                    || topVal == 0)
                {
                    dp[i][j] = 1;
                    foundMaxVal = Math.Max(foundMaxVal, dp[i][j]);
                    continue;
                }

                if (leftVal == topVal)
                {
                    if (dp[i - leftVal][j - leftVal] > 0)
                    {
                        dp[i][j] = leftVal + 1;
                    }
                    else
                    {
                        dp[i][j] = leftVal;
                    }
                }
                else
                {
                    dp[i][j] = Math.Min(leftVal, topVal) + 1;
                }

                foundMaxVal = Math.Max(foundMaxVal, dp[i][j]);
            }
        }

        return foundMaxVal * foundMaxVal;
    }
}
