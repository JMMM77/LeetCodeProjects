namespace LeetCodeSolutions._0._800._90;

/***
URL: https://leetcode.com/problems/bitwise-ors-of-subarrays
Number: 898
Difficulty: Medium
 */
public class BitwiseORsOfSubarrays
{
    public int SubarrayBitwiseORs(int[] nums)
    {
        var foundBitCombinations = new HashSet<int>();
        var lastFoundBitCombinations = new HashSet<int>();

        foreach (var num in nums)
        {
            var newFoundBits = new HashSet<int>();
            newFoundBits.Add(num);


            foreach (var bit in lastFoundBitCombinations)
            {
                newFoundBits.Add(bit | num);
            }

            lastFoundBitCombinations = newFoundBits;

            foreach (var bit in lastFoundBitCombinations)
            {
                foundBitCombinations.Add(bit);
            }
        }

        return foundBitCombinations.Count;
    }
}
