namespace LeetCodeSolutions._1000._400._80;

/***
URL: https://leetcode.com/problems/running-sum-of-1d-array
Number: 1480
Difficulty: Easy
 */
public class RunningSumof1dArray
{
    public int[] RunningSum(int[] nums)
    {
        var runningSum = new int[nums.Length];
        runningSum[0] = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            runningSum[i] = runningSum[i - 1] + nums[i];
        }

        return runningSum;
    }
}
