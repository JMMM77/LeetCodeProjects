namespace LeetCodeSolutions._0._100._90;

/***
URL: https://leetcode.com/problems/reverse-bits
Number: 190
Difficulty: Easy
*/
public class ReverseBitsProblem
{
    public int ReverseBits(int n)
    {
        var returnNum = 0;
        var startingPow = 1;

        for (var i = 31; i >= 0; i--)
        {
            if ((n & (1 << i)) != 0)
            {
                returnNum += startingPow;
            }

            startingPow *= 2;
        }

        return returnNum;
    }
}
