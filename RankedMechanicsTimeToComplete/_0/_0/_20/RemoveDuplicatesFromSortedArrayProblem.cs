namespace LeetCodeSolutions._0._0._20;

/***
URL: https://leetcode.com/problems/remove-duplicates-from-sorted-array/
Number: 26
Difficulty: easy
 */
public class RemoveDuplicatesFromSortedArrayProblem
{
    public int RemoveDuplicates(int[] nums)
    {
        var currentIndex = 0;
        var currentNum = -101;

        for (var i = 0; i < nums.Length; i++)
        {
            if (currentNum != nums[i])
            {
                currentNum = nums[i];
                nums[currentIndex] = currentNum;
                currentIndex++;
            }
            else if (currentNum == 100) // LeetCode constraints to 100, as its ordered there wont be any new numbers from here
            {
                break;
            }
        }

        return currentIndex;
    }
}
