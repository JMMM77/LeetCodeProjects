namespace LeetCodeSolutions._1000._900._20;
/***
URL: https://leetcode.com/problems/build-array-from-permutation
Number: 1920
Difficulty: Easy
 */
public class BuildArrayFromPermutationProblem
{
    public int[] BuildArray(int[] nums)
    {
        var ans = new int[nums.Length];

        for (var i = 0; i < nums.Length; i++)
        {
            ans[i] = nums[nums[i]];
        }

        return ans;
    }
}
