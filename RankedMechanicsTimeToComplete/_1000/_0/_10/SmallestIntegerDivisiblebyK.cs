namespace LeetCodeSolutions._1000._0._10;

/***
URL: https://leetcode.com/problems/smallest-integer-divisible-by-k
Number: 1015
Difficulty: Medium
 */
public class SmallestIntegerDivisiblebyK
{
    public int SmallestRepunitDivByK(int k)
    {
        // Cant be divisible by 2 or 5
        if (k % 2 == 0 || k % 5 == 0)
        {
            return -1;
        }

        var remainder = 1;
        var returnLength = 1;

        while (remainder % k != 0)
        {
            var foundNum = (remainder * 10) + 1;
            remainder = foundNum % k;
            returnLength += 1;
        }

        return returnLength;
    }
}
