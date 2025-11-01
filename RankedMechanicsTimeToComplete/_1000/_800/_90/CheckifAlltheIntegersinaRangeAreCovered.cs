namespace LeetCodeSolutions._1000._800._90;

/***
URL: https://leetcode.com/problems/check-if-all-the-integers-in-a-range-are-covered
Number: 1893
Difficulty: Easy
 */
public class CheckifAlltheIntegersinaRangeAreCovered
{
    public bool IsCovered(int[][] ranges, int left, int right)
    {
        var prefixSum = new int[52];

        for (var i = 0; i < ranges.Length; ++i)
        {
            prefixSum[ranges[i][0]] += 1;
            prefixSum[ranges[i][1] + 1] -= 1;
        }

        for (var i = 1; i < prefixSum.Length; ++i)
        {
            prefixSum[i] += prefixSum[i - 1];
        }

        for (var i = left; i <= right; ++i)
        {
            if (prefixSum[i] <= 0)
            {
                return false;
            }
        }

        return true;
    }
}
