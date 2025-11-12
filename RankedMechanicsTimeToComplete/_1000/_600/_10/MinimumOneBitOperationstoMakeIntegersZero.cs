namespace LeetCodeSolutions._1000._600._10;

/***
URL: https://leetcode.com/problems/minimum-one-bit-operations-to-make-integers-zero
Number: 1611
Difficulty: Hard
*/
public class MinimumOneBitOperationstoMakeIntegersZero
{
    /// <summary>
    /// Gray Code Relationship, consecutive numbers differ by exactly one bit.
    /// </summary>
    public int MinimumOneBitOperations(int n)
    {
        var sign = 1;
        var mask = 1 << 29;
        var ops = 0;

        for (var i = 0; i < 32; i++)
        {
            if ((n & mask) == mask)
            {
                ops += ((mask << 1) - 1) * sign;
                sign *= -1;
            }

            mask >>= 1;
        }

        return ops;
    }
}
