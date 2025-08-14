namespace LeetCodeSolutions._0._0._30;

/***
URL: https://leetcode.com/problems/search-insert-position
Number: 35
Difficulty: Easy
 */
public class SearchInsertPosition
{
    public int SearchInsert(int[] nums, int target)
    {
        if (nums[0] >= target)
        {
            return 0;
        }

        return BinarySearch(nums, target, 0, nums.Length);
    }

    private int BinarySearch(int[] nums, int target, int leftIndex, int rightIndex)
    {
        var halfway = leftIndex + ((rightIndex - leftIndex) / 2);

        if (nums[halfway] == target)
        {
            return halfway;
        }

        if (nums[halfway] > target)
        {
            rightIndex = halfway;
        }
        else
        {
            leftIndex = halfway;
        }

        var checkArray = nums[leftIndex..rightIndex];

        if (checkArray.Length <= 1)
        {
            if (nums[halfway] > target)
            {
                return halfway;
            }

            return halfway + 1;
        }

        return BinarySearch(nums, target, leftIndex, rightIndex);
    }
}
