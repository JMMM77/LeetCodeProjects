namespace LeetCodeSolutions._1000._500._70;

/***
URL: https://leetcode.com/problems/minimum-time-to-make-rope-colorful
Number: 1578
Difficulty: Medium
*/
public class MinimumTimetoMakeRopeColorful
{
    public int MinCost(string colors, int[] neededTime)
    {
        var timeToRemove = 0;
        var prevColor = colors[0];
        var maxNum = neededTime[0];
        var timeRequired = maxNum;

        for (var i = 1; i < colors.Length; i++)
        {
            var thisColor = colors[i];
            var thisReqTime = neededTime[i];

            if (thisColor == prevColor)
            {
                maxNum = Math.Max(maxNum, thisReqTime);
                timeRequired += thisReqTime;
                continue;
            }

            timeToRemove += timeRequired - maxNum;
            prevColor = thisColor;
            maxNum = thisReqTime;
            timeRequired = maxNum;
        }

        timeToRemove += timeRequired - maxNum;

        return timeToRemove;
    }
}
