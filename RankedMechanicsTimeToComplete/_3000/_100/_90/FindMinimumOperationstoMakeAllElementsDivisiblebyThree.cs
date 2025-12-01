namespace LeetCodeSolutions._3000._100._90;

/***
URL: https://leetcode.com/problems/find-minimum-operations-to-make-all-elements-divisible-by-three
Number: 3190
Difficulty: Easy
 */
public class FindMinimumOperationstoMakeAllElementsDivisiblebyThree
{
    public int MinimumOperations(int[] nums)
    {
        var numOfOps = 0;

        foreach (var num in nums)
        {
            if (num % 3 != 0)
            {
                numOfOps++;
            }
        }

        return numOfOps;
    }
}
