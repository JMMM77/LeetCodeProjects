namespace LeetCodeSolutions._0._0._20;
/***
URL: https://leetcode.com/problems/remove-element/
Number: 27
Difficulty: easy
 */
public class RemoveElementProblem
{
    public int RemoveElement(int[] nums, int val)
    {
        var currentIndex = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == val)
            {
                continue;
            }

            nums[currentIndex] = nums[i];
            currentIndex++;
        }

        return currentIndex;
    }
}
