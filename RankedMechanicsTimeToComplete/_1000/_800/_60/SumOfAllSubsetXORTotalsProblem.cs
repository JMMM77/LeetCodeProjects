namespace LeetCodeSolutions._1000._800._60;

/***
URL: https://leetcode.com/problems/sum-of-all-subset-xor-totals/description
Number: 1863
Difficulty: Easy
 */
public class SumOfAllSubsetXORTotalsProblem
{
    public int SubsetXORSum(int[] nums)
    {
        var sumOfXors = 0;
        var numOfSubsets = Math.Pow(2, nums.Length); // Power set

        // You can correlate the mask to the index of the array being included in the subset
        // e.g. Mask for 12: 1100 so the subset of the array [5,6,7,8] would be [5,6]
        for (var mask = 0; mask < numOfSubsets; mask++)
        {
            var xor = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                // Check if the i-th bit in mask is set
                if ((mask & (1 << i)) != 0)
                {
                    xor ^= nums[i]; // Include nums[i] in subset
                }
            }

            sumOfXors += xor; // Store XOR of this subset
        }

        return sumOfXors;
    }
}
