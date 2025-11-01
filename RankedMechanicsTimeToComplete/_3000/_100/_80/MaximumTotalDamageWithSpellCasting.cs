namespace LeetCodeSolutions._3000._100._80;

/***
URL: https://leetcode.com/problems/maximum-total-damage-with-spell-casting
Number: 3186
Difficulty: Medium
 */
public class MaximumTotalDamageWithSpellCasting
{
    public long MaximumTotalDamage(int[] power)
    {
        var powerCount = new SortedDictionary<int, int>();

        foreach (var pow in power)
        {
            if (!powerCount.ContainsKey(pow))
            {
                powerCount.Add(pow, 0);
            }

            powerCount[pow]++;
        }

        var vec = new List<(int, int)>();

        vec.Add((int.MinValue, 0));

        foreach (var pow in powerCount)
        {
            vec.Add((pow.Key, pow.Value));
        }

        var n = vec.Count;
        var f = new long[n];
        long mx = 0, ans = 0;
        var j = 1;

        for (var i = 1; i < n; i++)
        {
            while (j < i && vec[j].Item1 < vec[i].Item1 - 2)
            {
                mx = Math.Max(mx, f[j]);
                j++;
            }

            f[i] = mx + (long)vec[i].Item1 * vec[i].Item2;
            ans = Math.Max(ans, f[i]);
        }

        return ans;
    }
}
