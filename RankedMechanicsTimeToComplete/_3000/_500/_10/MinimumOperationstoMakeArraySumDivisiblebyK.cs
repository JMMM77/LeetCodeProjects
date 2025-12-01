namespace LeetCodeSolutions._3000._500._10;

/***
URL: https://leetcode.com/problems/minimum-operations-to-make-array-sum-divisible-by-k
Number: 3512
Difficulty: Easy
 */
public class MinimumOperationstoMakeArraySumDivisiblebyK
{
    public int MinOperations(int[] nums, int k)
    {
        var totalSumOfTheArray = 0;

        foreach (var num in nums)
        {
            totalSumOfTheArray += num;
        }

        return totalSumOfTheArray % k;
    }
}
