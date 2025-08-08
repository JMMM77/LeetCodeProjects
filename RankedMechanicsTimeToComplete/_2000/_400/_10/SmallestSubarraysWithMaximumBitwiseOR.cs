namespace LeetCodeSolutions._0._400._10;

/***
URL: https://leetcode.com/problems/smallest-subarrays-with-maximum-bitwise-or/description
Number: 2411
Difficulty: Medium
 */
public class SmallestSubarraysWithMaximumBitwiseOR
{
    public int[] SmallestSubarrays(int[] nums)
    {
        var returnArray = new int[nums.Length];
        var currentBitPositions = new int[32];
        Array.Fill(currentBitPositions, -1);

        for (var i = nums.Length - 1; i >= 0; i--)
        {
            // Update bit positions for nums[i]
            for (var b = 0; b < 32; b++)
            {
                if ((nums[i] & (1 << b)) != 0) // If this current bit is active then the current number activates this bit
                {
                    currentBitPositions[b] = i;
                }
            }

            var currentMax = currentBitPositions.Max() - i + 1;
            returnArray[i] = currentMax < 1 ? 1 : currentMax;
        }

        return returnArray;
    }
}
