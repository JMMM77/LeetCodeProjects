namespace LeetCodeSolutions._1000._400._0;

/***
URL: https://leetcode.com/problems/minimum-value-to-get-positive-step-by-step-sum
Number: 1413
Difficulty: Easy
 */
public class MinimumValuetoGetPositiveStepbyStepSum
{
    public int MinStartValue(int[] nums)
    {
        var smallestPoint = 0;
        var prevNum = 0;

        foreach (var num in nums)
        {
            prevNum += num;

            if (smallestPoint > prevNum)
            {
                smallestPoint = prevNum;
            }
        }

        if (smallestPoint >= 0)
        {
            return 1;
        }

        return smallestPoint < 0 ? -1 * smallestPoint + 1 : 1;
    }
}
