using System.Numerics;

namespace LeetCodeSolutions._2000._700._40;

/***
URL: https://leetcode.com/problems/minimum-operations-to-make-the-integer-zero
Number: 2749
Difficulty: Medium
 */
public class MinimumOperationstoMaketheIntegerZero
{
    public int MakeTheIntegerZero(int num1, int num2)
    {
        for (var k = 1; k <= 60; k++)
        {
            var remainder = num1 - (long)num2 * k;

            if (remainder < 0)
            {
                break;
            }

            var bits = BitOperations.PopCount((ulong)remainder);

            // If a num has less than or equal to K then you can make the number
            // 0100 at k == 2 you can do 0010 twice.
            if (bits <= k && k <= remainder)
            {
                return k;
            }
        }

        return -1;
    }
}
