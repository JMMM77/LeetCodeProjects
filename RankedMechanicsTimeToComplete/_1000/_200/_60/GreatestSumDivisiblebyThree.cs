namespace LeetCodeSolutions._1000._200._60;

/***
URL: https://leetcode.com/problems/greatest-sum-divisible-by-three
Number: 1262
Difficulty: Medium
 */
public class GreatestSumDivisiblebyThree
{
    public int MaxSumDivThree(int[] nums)
    {
        var total = 0;
        List<int> rem1 = [];
        List<int> rem2 = [];

        foreach (var x in nums)
        {
            total += x;

            var r = x % 3;

            if (r == 1)
            {
                rem1.Add(x);
            }
            else if (r == 2)
            {
                rem2.Add(x);
            }
        }

        rem1.Sort();
        rem2.Sort();

        if (total % 3 == 0)
        {
            return total;
        }

        // Case: total % 3 == 1
        if (total % 3 == 1)
        {
            var option1 = rem1.Count > 0 ? rem1[0] : int.MaxValue;
            var option2 = rem2.Count >= 2 ? rem2[0] + rem2[1] : int.MaxValue;

            return total - Math.Min(option1, option2);
        }

        // Case: total % 3 == 2
        if (total % 3 == 2)
        {
            var option1 = rem2.Count > 0 ? rem2[0] : int.MaxValue;
            var option2 = rem1.Count >= 2 ? rem1[0] + rem1[1] : int.MaxValue;

            return total - Math.Min(option1, option2);
        }

        return total; // Just for completeness.
    }
}
