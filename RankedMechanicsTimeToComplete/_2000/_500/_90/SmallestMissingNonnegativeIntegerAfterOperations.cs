namespace LeetCodeSolutions._2000._500._90;

/***
URL: https://leetcode.com/problems/smallest-missing-non-negative-integer-after-operations
Number: 2598
Difficulty: Medium
 */
public class SmallestMissingNonnegativeIntegerAfterOperations
{
    public int FindSmallestInteger(int[] nums, int value)
    {
        var remainders = new int[value];

        foreach (var num in nums)
        {
            // Keep remainder within value range
            var remainIndex = ((num % value % value) + value) % value;
            remainders[remainIndex]++;
        }

        var maxMex = 0;
        var index = maxMex % value;

        while (remainders[index] > 0)
        {
            remainders[index]--;
            maxMex++;
            index = maxMex % value;
        }

        return maxMex;
    }
}
