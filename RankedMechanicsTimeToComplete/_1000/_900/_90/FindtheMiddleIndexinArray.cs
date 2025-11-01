namespace LeetCodeSolutions._1000._900._90;

/***
URL: https://leetcode.com/problems/find-the-middle-index-in-array
Number: 1991
Difficulty: Easy
 */
public class FindtheMiddleIndexinArray
{
    public int FindMiddleIndex(int[] nums)
    {
        if (nums.Length == 1)
        {
            return 0;
        }

        for (var i = 1; i < nums.Length; i++)
        {
            nums[i] += nums[i - 1];
        }

        // middleIndex == 0
        if (nums[^1] == nums[0])
        {
            return 0;
        }

        for (var i = 1; i < nums.Length - 1; i++)
        {
            if (nums[i - 1] == nums[^1] - nums[i])
            {
                return i;
            }
        }

        if (nums[^2] == 0)
        {
            return nums.Length - 1;
        }

        return -1;
    }
}
