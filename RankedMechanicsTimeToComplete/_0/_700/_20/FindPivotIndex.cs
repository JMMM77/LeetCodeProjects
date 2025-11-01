namespace LeetCodeSolutions._0._700._20;

/***
URL: https://leetcode.com/problems/find-pivot-index
Number: 724
Difficulty: Easy
 */
public class FindPivotIndex
{
    public int PivotIndex(int[] nums)
    {
        var prefixSums = new int[nums.Length];
        prefixSums[0] = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            prefixSums[i] = prefixSums[i - 1] + nums[i];
        }

        var lastVal = prefixSums[^1];

        if (lastVal == prefixSums[0])
        {
            return 0;
        }

        for (var i = 1; i < prefixSums.Length; i++)
        {
            var leftElement = prefixSums[i - 1];
            var valToIgnore = prefixSums[i];

            if (lastVal == leftElement + valToIgnore)
            {
                return i;
            }
        }

        return -1;
    }
}
