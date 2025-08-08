namespace LeetCodeSolutions._0._0._20;
/***
URL: https://leetcode.com/problems/divide-two-integers
Number: 29
Difficulty: Medium
 */
public class DivideTwoIntegersProblem
{
    public int Divide(int dividend, int divisor)
    {
        if (dividend == 0)
        {
            return 0;
        }

        if (divisor == 1)
        {
            return dividend;
        }
        else if (divisor == -1)
        {
            if (dividend == -2147483648)
            {
                return 2147483647;
            }
            else
            {
                return -dividend;
            }
        }
        else if (divisor == 2)
        {
            return dividend >> 1;
        }
        else if (divisor == -2)
        {
            return -dividend >> 1;
        }

        var dividendLong = (long)dividend;
        var divisorLong = (long)divisor;
        var dividendIsNegative = dividendLong < 0;
        var divisorIsNegative = divisorLong < 0;
        var isResultNegative = dividendIsNegative ^ divisorIsNegative; // XOR


        if (dividendIsNegative)
        {
            dividendLong = -dividendLong;
        }

        if (divisorIsNegative)
        {
            divisorLong = -divisorLong;
        }

        if (dividendLong < divisorLong)
        {
            return 0;
        }

        long count = 0;

        while (dividendLong >= divisorLong)
        {
            dividendLong -= divisorLong;
            count++;

            if (count >= int.MaxValue)
            {
                if (isResultNegative)
                {
                    return int.MinValue;
                }

                return int.MaxValue;
            }
        }

        return (int)(isResultNegative ? 0 - count : count);
    }

    public int Divide2(int dividend, int divisor)
    {
        long count = 0;
        long dividendLong = dividend;
        long divisorLong = divisor;
        var dividendIsNegative = dividendLong < 0;
        var divisorIsNegative = divisorLong < 0;
        var isResultNegative = dividendIsNegative ^ divisorIsNegative; // XOR

        if (dividendIsNegative)
        {
            dividendLong = 0 - dividendLong;
        }

        if (divisorIsNegative)
        {
            divisorLong = 0 - divisorLong;
        }

        if (divisorLong == 1)
        {
            if (dividendLong > int.MaxValue)
            {
                if (isResultNegative)
                {
                    return int.MinValue;
                }

                return int.MaxValue;
            }

            return (int)(isResultNegative ? 0 - dividendLong : dividendLong);
        }

        while (dividendLong >= divisorLong)
        {
            dividendLong -= divisorLong;
            count++;

            if (count > int.MaxValue)
            {
                if (isResultNegative)
                {
                    return int.MinValue;
                }

                return int.MaxValue;
            }
        }

        return (int)(isResultNegative ? 0 - count : count);
    }

    // Cheating
    public int Divide1(int dividend, int divisor)
    {
        var value = (long)dividend / divisor;
        value = long.Min(int.MaxValue, value);
        value = long.Max(int.MinValue, value);
        return (int)value;
    }
}
