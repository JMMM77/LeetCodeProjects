namespace LeetCodeSolutions._1000._700._30;

/***
URL: https://leetcode.com/problems/find-the-highest-altitude
Number: 1732
Difficulty: Easy
 */
public class FindtheHighestAltitude
{
    public int LargestAltitude(int[] gain)
    {
        var maxHeight = Math.Max(0, gain[0]);

        for (var i = 1; i < gain.Length; i++)
        {
            gain[i] += gain[i - 1];
            maxHeight = Math.Max(maxHeight, gain[i]);
        }

        return maxHeight;
    }
}
