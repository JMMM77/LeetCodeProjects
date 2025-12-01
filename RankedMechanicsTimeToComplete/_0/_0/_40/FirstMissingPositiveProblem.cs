namespace LeetCodeSolutions._0._0._40;

/***
URL: https://leetcode.com/problems/first-missing-positive
Number: 41
Difficulty: Hard
 */
public class FirstMissingPositiveProblem
{
    public int FirstMissingPositive(int[] nums)
    {
        var n = nums.Length;

        for (var i = 0; i < n; i++)
        {
            // Puts each positive number into its correct position in the array
            while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
            {
                var correctIndex = nums[i] - 1;

                (nums[i], nums[correctIndex]) = (nums[correctIndex], nums[i]);
            }
        }

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != i + 1)
            {
                return i + 1;
            }
        }

        return n + 1;
    }
}
