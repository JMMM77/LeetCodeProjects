namespace LeetCodeSolutions._3000._300._90;
/***
URL: https://leetcode.com/problems/count-subarrays-of-length-three-with-a-condition
Number: 3392
Difficulty: Easy
 */
public class CountSubarraysOfLengthThreeWithAConditionProblem
{
    public int CountSubarrays(int[] nums)
    {
        var count = 0;

        for (var i = 2; i < nums.Length; i++)
        {
            Console.WriteLine(nums[i - 2] + nums[i]);
            Console.WriteLine(nums[i - 1] / 2);
            if (nums[i - 2] + nums[i] == (double)nums[i - 1] / 2)
            {
                count++;
            }

        }

        return count;
    }
}
