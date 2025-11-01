namespace LeetCodeSolutions._3000._200._80;

/***
URL: https://leetcode.com/problems/the-two-sneaky-numbers-of-digitville
Number: 3289
Difficulty: Easy
*/
public class TheTwoSneakyNumbersofDigitville
{
    public int[] GetSneakyNumbers(int[] nums)
    {
        Array.Sort(nums);
        var returnValues = new List<int>();

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1])
            {
                returnValues.Add(nums[i]);
            }
        }

        return [.. returnValues];
    }
}
