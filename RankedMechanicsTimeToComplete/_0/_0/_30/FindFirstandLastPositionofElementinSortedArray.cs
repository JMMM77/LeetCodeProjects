namespace LeetCodeSolutions._0._0._30;

/***
URL: https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array
Number: 34
Difficulty: Medium
 */
public class FindFirstandLastPositionofElementinSortedArray
{
    public int[] SearchRange(int[] nums, int target)
    {
        var i = Array.BinarySearch(nums, target);

        if (i < 0)
        {
            return [-1, -1];
        }

        var leftIndex = i;

        for (var leftNum = i - 1; leftNum >= 0; leftNum--)
        {
            if (nums[leftNum] == target)
            {
                leftIndex = leftNum;
                continue;
            }

            break;
        }

        var rightIndex = i;

        for (var rightNum = i + 1; rightNum < nums.Length; rightNum++)
        {
            if (nums[rightNum] == target)
            {
                rightIndex = rightNum;
                continue;
            }

            break;
        }

        return [leftIndex, rightIndex];
    }
}
