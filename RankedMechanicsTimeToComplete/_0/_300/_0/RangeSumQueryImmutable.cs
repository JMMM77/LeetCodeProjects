namespace LeetCodeSolutions._0._300._0;

/***
URL: https://leetcode.com/problems/range-sum-query-immutable
Number: 303
Difficulty: Easy
 */
public class RangeSumQueryImmutable
{
    private static int[] Nums = [];

    public void NumArray(int[] nums)
    {
        var prefixSums = new int[nums.Length];
        prefixSums[0] = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            prefixSums[i] = prefixSums[i - 1] + nums[i];
        }

        Nums = prefixSums;
    }

    public int SumRange(int left, int right)
    {
        if (left == 0)
        {
            return Nums[right];
        }

        return Nums[right] - Nums[left - 1];
    }
}
