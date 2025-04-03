namespace LeetCodeSolutions._2000._800._70;
/***
URL: https://leetcode.com/problems/maximum-value-of-an-ordered-triplet-i/
Number: 2873
Difficulty: Easy
 */
public class MaximumValueOfAnOrderedTripletIProblem
{
    public long MaximumTripletValue(int[] nums)
    {
        long result = 0; // Stores the maximum possible value of the triplet nums[i] - nums[j] + nums[k].
        long ijMax = 0; // Stores the maximum value of nums[i] - nums [j] encountered so far.
        long iMax = 0; // Stores the maximum value of nums[i] encountered so far while iterating through the array.

        for (var k = 0; k < nums.Length; k++)
        {
            var currentNum = nums[k];
            var potentialMaxResult = ijMax * currentNum;

            if (result < potentialMaxResult)
            {
                result = potentialMaxResult;
            }

            var potenialMaxMultiplier = iMax - nums[k];

            if (ijMax < potenialMaxMultiplier)
            {
                ijMax = potenialMaxMultiplier;
            }

            if (iMax < nums[k])
            {
                iMax = nums[k];
            }
        }

        return result;
    }
}
