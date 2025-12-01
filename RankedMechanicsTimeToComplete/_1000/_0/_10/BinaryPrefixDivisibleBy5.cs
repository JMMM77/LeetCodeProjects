namespace LeetCodeSolutions._1000._0._10;

/***
URL: https://leetcode.com/problems/binary-prefix-divisible-by-5
Number: 1018
Difficulty: Easy
 */
public class BinaryPrefixDivisibleBy5
{
    public IList<bool> PrefixesDivBy5(int[] nums)
    {
        var prefix = 0;
        var returnList = new bool[nums.Length];

        for (var i = 0; i < nums.Length; i++)
        {
            prefix = ((2 * prefix) + nums[i]) % 5;
            returnList[i] = prefix == 0;
        }

        return returnList;
    }
}
