namespace LeetCodeSolutions._0._700._40;

/***
URL: https://leetcode.com/problems/delete-and-earn
Number: 740
Difficulty: Medium
 */
public class DeleteAndEarnProblem
{
    public int DeleteAndEarn(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        if (nums.Length == 2)
        {
            if (Math.Abs(nums[0] - nums[1]) == 1)
            {
                return Math.Max(nums[0], nums[1]);
            }

            return nums[0] + nums[1];
        }

        Array.Sort(nums);

        var prevNum = nums[0];
        var dp = new List<int>
        {
            prevNum
        };

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] == prevNum)
            {
                dp[^1] += prevNum;
                continue;
            }

            var thisMax =
                dp.Count == 2 ? dp[^2] :
                dp.Count > 2 ? Math.Max(dp[^2], dp[^3]) :
                0;

            if (nums[i] - prevNum == 1)
            {
                dp.Add(nums[i] + thisMax);
            }
            else
            {
                dp.Add(nums[i] + Math.Max(dp[^1], thisMax));
            }

            prevNum = nums[i];
        }

        Console.WriteLine(string.Join(", ", dp));

        if (dp.Count == 1)
        {
            return dp[^1];
        }

        return Math.Max(dp[^1], dp[^2]);
    }
}
