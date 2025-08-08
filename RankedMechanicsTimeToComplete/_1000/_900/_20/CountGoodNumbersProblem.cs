namespace LeetCodeSolutions._1000._900._20;
/***
URL: https://leetcode.com/problems/count-good-numbers
Number: 1922
Difficulty: Medium
 */
public class CountGoodNumbersProblem
{
    private static int MOD = (int)Math.Pow(10, 9) + 7;

    public int CountGoodNumbers(long n)
    {
        var evenPositions = (n + 1) / 2;
        var oddPositions = n / 2;

        var evenPower = Power(5, evenPositions);
        var oddPower = Power(4, oddPositions);

        return (int)((evenPower * oddPower) % MOD);
    }

    private long Power(long baseVal, long exp)
    {
        long result = 1;

        while (exp > 0)
        {
            if (exp % 2 == 1)
            {
                result = (result * baseVal) % MOD;
            }

            baseVal = (baseVal * baseVal) % MOD;

            exp /= 2;
        }

        return result;
    }
}
