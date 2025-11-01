namespace LeetCodeSolutions._3000._400._90;

/***
URL: https://leetcode.com/problems/find-the-minimum-amount-of-time-to-brew-potions
Number: 3494
Difficulty: Medium
 */
public class FindtheMinimumAmountofTimetoBrewPotions
{
    public long MinTime(int[] skill, int[] mana)
    {
        var n = skill.Length;
        var m = mana.Length;
        var times = new long[n];

        for (var j = 0; j < m; j++)
        {
            long curTime = 0;

            for (var i = 0; i < n; i++)
            {
                curTime = Math.Max(curTime, times[i]) + (long)skill[i] * mana[j];
            }

            times[n - 1] = curTime;

            for (var i = n - 2; i >= 0; i--)
            {
                times[i] = times[i + 1] - (long)skill[i + 1] * mana[j];
            }
        }

        return times[n - 1];
    }
}
