namespace LeetCodeSolutions._3000._300._50;

/***
URL: https://leetcode.com/problems/sum-of-good-subsequences
Number: 3351
Difficulty: Hard
 */
public class SumofGoodSubsequences
{
    private const int MOD = 1000000007;

    public int SumOfGoodSubsequences(int[] nums)
    {
        var count = 0;
        var thisSequence = new List<int>()
        {
            nums[0]
        };

        for (var i = 1; i < nums.Length; i++)
        {
            var dif = nums[i] - nums[i - 1];

            if (dif == 1 || dif == -1)
            {
                thisSequence.Add(nums[i]);
                continue;
            }

            count += GetSumOfSequence(thisSequence);
            thisSequence = [nums[i]];
        }

        count = (count + GetSumOfSequence(thisSequence)) % MOD;

        return count;
    }

    private int GetSumOfSequence(List<int> list)
    {
        var count = 0;
        var totalPowerSet = Math.Pow(2, list.Count);

        for (var mask = 0; mask < totalPowerSet; mask++)
        {
            var subsetTotal = 0;

            for (var i = 1; i < list.Count; i++)
            {
                // Check if the i-th bit in mask is set
                if ((mask & (1 << i)) != 0)
                {
                    subsetTotal += list[i]; // Include nums[i] in subset
                }
            }

            count = (count + subsetTotal) % MOD;
        }

        return count;
    }
}
