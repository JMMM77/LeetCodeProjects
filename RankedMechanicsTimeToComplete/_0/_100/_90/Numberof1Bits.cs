using System.Numerics;

namespace LeetCodeSolutions._0._100._90;

/***
URL: https://leetcode.com/problems/number-of-1-bits
Number: 191
Difficulty: Easy
*/
public class Numberof1Bits
{
    public int HammingWeight(int n)
    {
        var numOfBits = 0;

        for (var i = 0; i < 32; i++)
        {
            if ((n & (1 << i)) != 0)
            {
                numOfBits++;
            }
        }

        return numOfBits;
    }

    public int HammingWeight1(int n)
    {
        return BitOperations.PopCount((uint)n);
    }
}
