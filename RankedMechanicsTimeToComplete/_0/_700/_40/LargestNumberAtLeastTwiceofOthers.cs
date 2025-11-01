namespace LeetCodeSolutions._0._700._40;

/***
URL: https://leetcode.com/problems/largest-number-at-least-twice-of-others
Number: 747
Difficulty: Easy
 */
public class LargestNumberAtLeastTwiceofOthers
{
    public int DominantIndex(int[] nums)
    {
        var maxVal = new int[2];
        var secondMaxVal = new int[2];

        if (nums[0] >= nums[1])
        {
            maxVal[0] = nums[0];
            maxVal[1] = 0;

            secondMaxVal[0] = nums[1];
            secondMaxVal[1] = 1;
        }
        else
        {
            maxVal[0] = nums[1];
            maxVal[1] = 1;

            secondMaxVal[0] = nums[0];
            secondMaxVal[1] = 0;
        }

        for (var i = 2; i < nums.Length; i++)
        {
            var thisNum = nums[i];

            if (thisNum > maxVal[0])
            {
                secondMaxVal[0] = maxVal[0];
                secondMaxVal[1] = maxVal[1];
                maxVal[0] = thisNum;
                maxVal[1] = i;

                continue;
            }

            if (thisNum > secondMaxVal[0])
            {
                secondMaxVal[0] = thisNum;
                secondMaxVal[1] = i;
            }
        }

        return maxVal[0] - secondMaxVal[0] >= secondMaxVal[0] ? maxVal[1] : -1;
    }
}
