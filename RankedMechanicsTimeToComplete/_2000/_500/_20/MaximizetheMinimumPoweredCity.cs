namespace LeetCodeSolutions._2000._500._20;

/***
URL: https://leetcode.com/problems/maximize-the-minimum-powered-city
Number: 2528
Difficulty: Hard
*/
public class MaximizetheMinimumPoweredCity
{
    public long MaxPower(int[] stations, int r, int k)
    {
        var n = stations.Length;
        var count = new long[n + 1];

        for (var i = 0; i < n; i++)
        {
            var left = Math.Max(0, i - r);
            var right = Math.Min(n, i + r + 1);

            count[left] += stations[i];
            count[right] -= stations[i];
        }

        long lo = stations.Min();
        long res = 0;
        var hi = stations.Sum(x => (long)x) + k;

        while (lo <= hi)
        {
            var mid = lo + (hi - lo) / 2;

            if (Check(count, mid, r, k))
            {
                res = mid;
                lo = mid + 1;
            }
            else
            {
                hi = mid - 1;
            }
        }

        return res;
    }

    private static bool Check(long[] cnt, long val, int r, int k)
    {
        var n = cnt.Length - 1;
        var diff = (long[])cnt.Clone();
        long sum = 0;
        long remaining = k;

        for (var i = 0; i < n; i++)
        {
            sum += diff[i];

            if (sum < val)
            {
                var add = val - sum;

                if (remaining < add)
                {
                    return false;
                }

                var end = Math.Min(n, i + 2 * r + 1);

                remaining -= add;
                diff[end] -= add;
                sum += add;
            }
        }

        return true;
    }
}
