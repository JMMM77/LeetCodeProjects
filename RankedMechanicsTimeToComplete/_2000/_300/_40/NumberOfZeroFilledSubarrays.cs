namespace LeetCodeSolutions._2000._300._40;

/***
URL: https://leetcode.com/problems/number-of-zero-filled-subarrays
Number: 2348
Difficulty: Medium
 */
public class NumberOfZeroFilledSubarrays
{
    public long ZeroFilledSubarray(int[] nums)
    {
        long numOf0SubArrays = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                long numOfConsecutive0s = 0;

                while (i < nums.Length && nums[i] == 0)
                {
                    numOfConsecutive0s++;
                    i++;
                }

                numOf0SubArrays += (numOfConsecutive0s * (numOfConsecutive0s + 1)) / 2;
            }
        }

        return numOf0SubArrays;
    }
}
