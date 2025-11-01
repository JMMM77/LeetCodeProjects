namespace LeetCodeSolutions._1000._400._20;

/***
URL: https://leetcode.com/problems/maximum-score-after-splitting-a-string
Number: 1422
Difficulty: Easy
 */
public class MaximumScoreAfterSplittingaString
{
    public int MaxScore(string s)
    {
        var leftPrefixSums = new int[s.Length];
        var numOf0s = 0;

        if (s[0] == '0')
        {
            leftPrefixSums[0] = 1;
            numOf0s++;
        }
        else
        {
            leftPrefixSums[0] = 0;
        }


        for (var i = 1; i < s.Length; i++)
        {
            if (s[i] == '0')
            {
                leftPrefixSums[i] = leftPrefixSums[i - 1] + 1;
                numOf0s++;
            }
            else
            {
                leftPrefixSums[i] = leftPrefixSums[i - 1];
            }
        }

        var maxScore = 0;
        var numOf1s = s.Length - numOf0s;

        for (var i = 0; i < s.Length - 1; i++)
        {
            if (s[i] == '1')
            {
                numOf1s--;
            }

            maxScore = Math.Max(maxScore, numOf1s + leftPrefixSums[i]);
        }

        return maxScore;
    }
}
