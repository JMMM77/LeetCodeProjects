namespace LeetCodeSolutions._1000._400._30;

/***
URL: https://leetcode.com/problems/check-if-all-1s-are-at-least-length-k-places-away
Number: 1437
Difficulty: Easy
 */
public class CheckIfAll1sAreatLeastLengthKPlacesAway
{
    public bool KLengthApart(int[] nums, int k)
    {
        var startIndex = -1;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                startIndex = i;
                break;
            }
        }

        if (startIndex == -1)
        {
            return true;
        }

        var lastIndex = startIndex;

        for (var i = startIndex + 1; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                if (i - lastIndex <= k)
                {
                    return false;
                }

                lastIndex = i;
            }
        }

        return true;
    }
}
