namespace LeetCodeSolutions._0._700._40;

/***
URL: https://leetcode.com/problems/min-cost-climbing-stairs
Number: 746
Difficulty: Easy
 */
public class MinCostClimbingStairsProblem
{
    public int MinCostClimbingStairs(int[] cost)
    {
        var dp = new int[cost.Length];
        dp[^1] = cost[^1];
        dp[^2] = cost[^2];

        for (var i = cost.Length - 3; i >= 0; i--)
        {
            dp[i] = cost[i] + Math.Min(dp[i + 1], dp[i + 2]);
        }

        return Math.Min(dp[0], dp[1]);
    }
}
