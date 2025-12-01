namespace LeetCodeSolutions._2000._100._40;

/***
URL: https://leetcode.com/problems/maximum-running-time-of-n-computers
Number: 2141
Difficulty: Hard
 */
public class MaximumRunningTimeofNComputers
{
    public long MaxRunTime(int n, int[] batteries)
    {
        Array.Sort(batteries);

        var live = new long[n];

        for (var i = 0; i < n; i++)
        {
            live[n - i - 1] = batteries[^(i + 1)];
        }

        long extraTime = 0;

        for (var i = batteries.Length - n - 1; i >= 0; i--)
        {
            extraTime += batteries[i];
        }

        for (var i = 0; i < n - 1; i++)
        {
            var need = (live[i + 1] - live[i]) * (i + 1);

            if (extraTime < need)
            {
                // We can't fully level up to live[i+1]
                return live[i] + (extraTime / (i + 1));
            }

            extraTime -= need;
            live[i] = live[i + 1];
        }

        return live[n - 1] + (extraTime / n);
    }
}
