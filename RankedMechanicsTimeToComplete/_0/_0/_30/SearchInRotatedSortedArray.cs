namespace LeetCodeSolutions._0._0._30;

/***
URL: https://leetcode.com/problems/search-in-rotated-sorted-array
Number: 33
Difficulty: Medium
 */

public class SearchInRotatedSortedArray
{
    public int Search(int[] nums, int target)
    {
        var n = nums.Length;
        var leftIndex = 0;
        var rightIndex = n - 1;

        while (leftIndex <= rightIndex)
        {
            var index = leftIndex + (rightIndex - leftIndex) / 2;

            var thisNum = nums[index];

            if (thisNum == target)
            {
                return index;
            }

            // Check if left half is sorted
            if (nums[leftIndex] <= thisNum)
            {
                if (target >= nums[leftIndex] && target < thisNum)
                {
                    rightIndex = index - 1;
                }
                else
                {
                    leftIndex = index + 1;
                }
            }
            else
            {
                // Right half is sorted
                if (target > thisNum && target <= nums[rightIndex])
                {
                    leftIndex = index + 1;
                }
                else
                {
                    rightIndex = index - 1;
                }
            }
        }

        return -1;
    }
}
