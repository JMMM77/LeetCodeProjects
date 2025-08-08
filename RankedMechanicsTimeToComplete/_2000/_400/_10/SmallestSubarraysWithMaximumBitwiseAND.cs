namespace LeetCodeSolutions._0._400._10;

/***
URL: https://leetcode.com/problems/longest-subarray-with-maximum-bitwise-and
Number: 2419
Difficulty: Medium
 */
public class BitwiseORsOfSubarrays
{
    public int LongestSubarray(int[] nums)
    {
        var biggestNum = 0;
        var longestSequence = -1;
        var currentSequence = -1;
        var sequenceBroken = false;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > biggestNum)
            {
                biggestNum = nums[i];
                longestSequence = 1;
                currentSequence = 1;
                sequenceBroken = false;
            }
            else if (nums[i] == biggestNum)
            {
                if (sequenceBroken)
                {
                    if (currentSequence > longestSequence)
                    {
                        longestSequence = currentSequence;
                    }

                    currentSequence = 1;
                    sequenceBroken = false;
                }
                else
                {
                    currentSequence++;
                }
            }
            else if (!sequenceBroken)
            {
                sequenceBroken = !sequenceBroken;
            }
        }

        if (currentSequence > longestSequence)
        {
            longestSequence = currentSequence;
        }

        return longestSequence;
    }
}
