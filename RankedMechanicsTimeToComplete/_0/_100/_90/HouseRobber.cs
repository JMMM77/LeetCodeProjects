namespace LeetCodeSolutions._0._100._90;

/***
URL: https://leetcode.com/problems/house-robber
Number: 198
Difficulty: Medium
 */
public class HouseRobber
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        if (nums.Length == 2)
        {
            return Math.Max(nums[0], nums[1]);
        }

        var dp = new int[nums.Length];
        dp[^1] = nums[^1];
        dp[^2] = nums[^2];
        dp[^3] = nums[^3] + dp[^1];

        for (var i = nums.Length - 4; i >= 0; i--)
        {
            dp[i] = nums[i] + Math.Max(dp[i + 2], dp[i + 3]);
        }

        return Math.Max(dp[0], dp[1]);
    }
}
