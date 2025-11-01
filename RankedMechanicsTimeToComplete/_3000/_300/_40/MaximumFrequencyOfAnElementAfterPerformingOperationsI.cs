namespace LeetCodeSolutions._3000._300._40;

/***
URL: https://leetcode.com/problems/maximum-frequency-of-an-element-after-performing-operations-i
Number: 3346
Difficulty: Medium
 */
public class MaximumFrequencyOfAnElementAfterPerformingOperationsI
{
    public int MaxFrequency(int[] nums, int k, int numOperations)
    {
        Array.Sort(nums);

        var ans = 0;
        var numCount = new Dictionary<int, int>();
        var lastNumIndex = 0;

        for (var i = 0; i < nums.Length; ++i)
        {
            if (nums[i] != nums[lastNumIndex])
            {
                numCount[nums[lastNumIndex]] = i - lastNumIndex;
                ans = Math.Max(ans, i - lastNumIndex);
                lastNumIndex = i;
            }
        }

        numCount[nums[lastNumIndex]] = nums.Length - lastNumIndex;
        ans = Math.Max(ans, nums.Length - lastNumIndex);

        for (var i = nums[0]; i <= nums[^1]; i++)
        {
            var l = LeftBound(nums, i - k);
            var r = RightBound(nums, i + k);

            int tempAns;

            if (numCount.ContainsKey(i))
            {
                tempAns = Math.Min(r - l + 1, numCount[i] + numOperations);
            }
            else
            {
                tempAns = Math.Min(r - l + 1, numOperations);
            }

            ans = Math.Max(ans, tempAns);
        }

        return ans;
    }

    private int LeftBound(int[] nums, int value)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            var mid = (left + right) / 2;

            if (nums[mid] < value)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
    }

    private int RightBound(int[] nums, int value)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            var mid = (left + right + 1) / 2;

            if (nums[mid] > value)
            {
                right = mid - 1;
            }
            else
            {
                left = mid;
            }
        }

        return left;
    }
}
