namespace LeetCodeSolutions._3000._300._90;

/***
URL: https://leetcode.com/problems/maximum-number-of-distinct-elements-after-operations
Number: 3397
Difficulty: Medium
 */

public class MaximumNumberofDistinctElementsAfterOperations
{
    public int MaxDistinctElements(int[] nums, int k)
    {
        Array.Sort(nums);

        var distinctCount = 0;
        var prevNum = int.MinValue;

        foreach (var num in nums)
        {
            var thisNum = Math.Min(Math.Max(num - k, prevNum + 1), num + k);

            if (thisNum > prevNum)
            {
                distinctCount++;
                prevNum = thisNum;
            }
        }

        return distinctCount;
    }
}
