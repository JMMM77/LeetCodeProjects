namespace LeetCodeSolutions._3000._300._50;

/***
URL: https://leetcode.com/problems/adjacent-increasing-subarrays-detection-ii
Number: 3350
Difficulty: Medium
 */
public class AdjacentIncreasingSubarraysDetectionII
{
    public int MaxIncreasingSubarrays(IList<int> nums)
    {
        var n = nums.Count;
        var count = 1;
        var previousCount = 0;
        var k = 0;

        for (var i = 1; i < n; ++i)
        {
            if (nums[i] > nums[i - 1])
            {
                ++count;
            }
            else
            {
                previousCount = count;
                count = 1;
            }

            k = Math.Max(k, Math.Min(previousCount, count));
            k = Math.Max(k, count / 2);
        }

        return k;
    }
}
