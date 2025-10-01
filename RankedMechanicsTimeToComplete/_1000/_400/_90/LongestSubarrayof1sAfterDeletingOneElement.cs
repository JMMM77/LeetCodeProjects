namespace LeetCodeSolutions._1000._400._90;

/***
URL: https://leetcode.com/problems/find-the-minimum-Area-to-cover-all-ones-i
Number: 3195
Difficulty: Medium
 */
public class LongestSubarrayof1sAfterDeletingOneElement
{
    public int LongestSubarray(int[] nums)
    {
        if (nums.Length == 1)
        {
            return 0;
        }

        var combinedSubArrayLengths = new List<int>();
        var contains0 = false;
        var prevSubArray = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                if (i > 0 && nums[i - 1] == 0)
                {
                    prevSubArray = 0;
                }

                contains0 = true;
                continue;
            }

            var currentSubLength = 0;

            while (i < nums.Length && nums[i] == 1)
            {
                currentSubLength++;
                i++;
            }

            i--;

            combinedSubArrayLengths.Add(currentSubLength + prevSubArray);
            prevSubArray = currentSubLength;
        }

        if (combinedSubArrayLengths.Count == 0)
        {
            return 0;
        }

        return contains0 ? combinedSubArrayLengths.Max() : combinedSubArrayLengths.Max() - 1;
    }
}
