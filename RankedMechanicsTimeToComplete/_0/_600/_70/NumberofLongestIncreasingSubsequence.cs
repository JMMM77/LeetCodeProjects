namespace LeetCodeSolutions._0._600._70;

/***
URL: https://leetcode.com/problems/number-of-longest-increasing-subsequence
Number: 673
Difficulty: Medium
 */
public class NumberofLongestIncreasingSubsequence
{
    public class Solution
    {
        public int FindNumberOfLIS(int[] nums)
        {
            var n = nums.Length;

            if (n == 0)
            {
                return 0;
            }

            var lengths = new int[n]; // To store the length of the longest increasing subsequence ending at each index
            var counts = new int[n];  // To store the count of such subsequences

            // Initialize lengths and counts arrays with default values
            for (var i = 0; i < n; i++)
            {
                lengths[i] = 1; // Each element is an increasing subsequence of length 1
                counts[i] = 1;  // Each element itself is a subsequence
            }

            var maxLength = 1;

            for (var i = 1; i < n; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        if (lengths[j] + 1 > lengths[i])
                        {
                            lengths[i] = lengths[j] + 1;
                            counts[i] = counts[j];
                        }
                        else if (lengths[j] + 1 == lengths[i])
                        {
                            counts[i] += counts[j];
                        }
                    }
                }

                maxLength = Math.Max(maxLength, lengths[i]);
            }

            var result = 0;

            for (var i = 0; i < n; i++)
            {
                if (lengths[i] == maxLength)
                {
                    result += counts[i];
                }
            }

            return result;
        }
    }
}
