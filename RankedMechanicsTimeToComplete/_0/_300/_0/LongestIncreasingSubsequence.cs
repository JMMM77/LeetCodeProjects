namespace LeetCodeSolutions._0._300._0;

/***
URL: https://leetcode.com/problems/longest-increasing-subsequence
Number: 300
Difficulty: Medium
 */
public class LongestIncreasingSubsequence
{
    public int LengthOfLIS(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        var dp = new int[nums.Length];
        var length = 0;

        foreach (var num in nums)
        {
            var i = Array.BinarySearch(dp, 0, length, num);

            if (i < 0)
            {
                i = ~i;
            }

            dp[i] = num;

            if (i == length)
            {
                length++;
            }
        }

        return length;
    }

    public int LengthOfLIS1(int[] nums)
    {
        var dp = new int[nums.Length];

        for (var i = 0; i < nums.Length; i++)
        {
            dp[i] = 1; // Store the length of the longest increasing subsequence ending at each index.
        }

        var smallestNumberFound = nums[0];
        var longestIncreasingSub = 1;

        for (var i = 1; i < nums.Length; i++)
        {
            var thisNum = nums[i];

            if (thisNum < smallestNumberFound)
            {
                smallestNumberFound = thisNum;
                continue;
            }

            var setNum = -1;

            for (var j = i - 1; j >= 0; j--)
            {
                if (thisNum > nums[j])
                {
                    setNum = Math.Max(setNum, dp[j] + 1);
                }
            }

            longestIncreasingSub = Math.Max(longestIncreasingSub, setNum);
            dp[i] = setNum;
        }

        return longestIncreasingSub;
    }
}
