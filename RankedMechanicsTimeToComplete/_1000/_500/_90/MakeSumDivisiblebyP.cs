namespace LeetCodeSolutions._1000._500._90;

/***
URL: https://leetcode.com/problems/make-sum-divisible-by-p
Number: 1590
Difficulty: Medium
 */
public class MakeSumDivisiblebyP
{
    public int MinSubarray(int[] nums, int p)
    {
        long total = 0;

        foreach (var n in nums)
        {
            total += n;
        }

        var target = (int)(total % p);

        if (target == 0)
        {
            return 0; // already divisible
        }

        var map = new Dictionary<int, int>
        {
            [0] = -1   // prefix sum before start
        };

        long prefix = 0;
        var result = nums.Length;

        for (var i = 0; i < nums.Length; i++)
        {
            prefix = (prefix + nums[i]) % p;

            var needed = (int)((prefix - target + p) % p);

            if (map.TryGetValue(needed, out var value))
            {
                result = Math.Min(result, i - value);
            }

            map[(int)prefix] = i;
        }

        return result == nums.Length ? -1 : result;
    }
}
