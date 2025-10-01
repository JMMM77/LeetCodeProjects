namespace LeetCodeSolutions._3000._400._90;

/***
URL: https://leetcode.com/problems/minimum-operations-to-make-array-elements-zero
Number: 3495
Difficulty: Hard
 */
public class MinimumOperationstoMakeArrayElementsZero
{
    public long MinOperations(int[][] queries)
    {
        long numOfOps = 0;

        foreach (var nums in queries)
        {
            var totalRight = GetNumOfOps(nums[1]);
            var totalLeft = GetNumOfOps(nums[0] - 1);

            numOfOps += (totalRight - totalLeft + 1) / 2;
        }

        return numOfOps;
    }

    private static long GetNumOfOps(int num)
    {
        long count = 0;
        var level = 1;
        var baseVal = 1;

        while (baseVal <= num)
        {
            var end = Math.Min(baseVal * 2 - 1, num);

            count += (long)((level + 1) / 2) * (end - baseVal + 1);
            level++;
            baseVal *= 2;
        }

        return count;
    }
}
