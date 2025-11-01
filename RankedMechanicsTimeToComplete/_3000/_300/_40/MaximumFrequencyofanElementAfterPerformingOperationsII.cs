namespace LeetCodeSolutions._3000._300._40;

/***
URL: https://leetcode.com/problems/maximum-frequency-of-an-element-after-performing-operations-ii
Number: 3347
Difficulty: Hard
 */
public class MaximumFrequencyofanElementAfterPerformingOperationsII
{
    public int MaxFrequency(int[] nums, int k, int numOperations)
    {
        Array.Sort(nums);

        var ans = 0;
        var numCount = new Dictionary<int, int>();
        var modes = new SortedSet<int>();

        Action<int> addMode = (value) =>
        {
            modes.Add(value);

            if (value - k >= nums[0])
            {
                modes.Add(value - k);
            }

            if (value + k <= nums[nums.Length - 1])
            {
                modes.Add(value + k);
            }
        };

        var lastNumIndex = 0;

        for (var i = 0; i < nums.Length; ++i)
        {
            if (nums[i] != nums[lastNumIndex])
            {
                numCount[nums[lastNumIndex]] = i - lastNumIndex;
                ans = Math.Max(ans, i - lastNumIndex);

                addMode(nums[lastNumIndex]);

                lastNumIndex = i;
            }
        }

        numCount[nums[lastNumIndex]] = nums.Length - lastNumIndex;
        ans = Math.Max(ans, nums.Length - lastNumIndex);

        addMode(nums[lastNumIndex]);

        Func<int, int> leftBound = (value) =>
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
        };

        Func<int, int> rightBound = (value) =>
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
        };

        foreach (var mode in modes)
        {
            var l = leftBound(mode - k);
            var r = rightBound(mode + k);
            int tempAns;

            if (numCount.ContainsKey(mode))
            {
                tempAns = Math.Min(r - l + 1, numCount[mode] + numOperations);
            }
            else
            {
                tempAns = Math.Min(r - l + 1, numOperations);
            }

            ans = Math.Max(ans, tempAns);
        }

        return ans;
    }
}
