namespace LeetCodeSolutions._0._900._90;
/***
URL: https://leetcode.com/problems/count-the-number-of-powerful-integers
Number: 2999
Difficulty: Hard
 */
public class CountTheNumberOfPowerfulIntegersProblem
{
    // Genius
    public long NumberOfPowerfulInt(long start, long finish, int limit, string s)
    {
        var start_ = (start - 1).ToString();
        var finish_ = finish.ToString();

        // Finds the difference between all possible Values below finish and all possible Values below start
        return Calculate(finish_, s, limit) - Calculate(start_, s, limit);
    }

    // Calculates how many possible combinations of the suffix can be included in the max number
    private long Calculate(string maxNum, string s, int limit)
    {
        // No Available numbers if the string is bigger than the biggest possible value
        if (maxNum.Length < s.Length)
        {
            return 0;
        }

        // If the Values are the same size then only 1 possible number exists
        if (maxNum.Length == s.Length)
        {
            return string.Compare(maxNum, s) >= 0 ? 1 : 0;
        }

        long count = 0;
        var leadingDigits = maxNum.Length - s.Length;

        for (var i = 0; i < leadingDigits; i++)
        {
            var digit = maxNum[i] - '0';

            if (limit < digit)
            {
                // All digits after this can be anything (we bail early, since nothing beyond this can match).
                count += (long)Math.Pow(limit + 1, leadingDigits - i);
                return count;
            }

            // Count all possible combinations for this digit
            count += (long)digit * (long)Math.Pow(limit + 1, leadingDigits - 1 - i);
        }

        // If the current number's suffix is ≥ s, we include that final candidate.
        var suffix = maxNum.Substring(leadingDigits);

        if (string.Compare(suffix, s) >= 0)
        {
            count++;
        }

        return count;
    }

    // Works but a bit slow
    private int Limit = 0;
    private string Suffix = "";
    private string StartString = "";
    private string FinishString = "";
    private int PreLength = 0; // How many leading digits(from the left) are not part of the required suffix.
    private long[] Memo = []; // Stores the number of valid combinations starting from digit index i, when there are no tight bounds on the digit range

    public long NumberOfPowerfulInt2(long start, long finish, int limit, string s)
    {
        Limit = limit;
        Suffix = s;
        StartString = start.ToString();
        FinishString = finish.ToString();
        var n = FinishString.Length;
        PreLength = n - Suffix.Length;

        StartString = StartString.PadLeft(n, '0'); // align digits

        Memo = new long[n];

        Array.Fill(Memo, -1);

        return Dfs(0, true, true);
    }

    /// <summary>
    /// Digit-by-digit DFS that constructs all valid numbers from most to least significant digit.
    /// </summary>
    /// <param name="digitIndex">The current digit index in the number.</param>
    /// <param name="limitLow">Whether we're still constrained by the lower bound (start).</param>
    /// <param name="limitHigh">Whether we're still constrained by the upper bound (finish).</param>
    /// <returns></returns>

    private long Dfs(int digitIndex, bool limitLow, bool limitHigh)
    {
        // recursive boundary
        if (digitIndex == StartString.Length)
        {
            return 1;
        }

        if (!limitLow && !limitHigh && Memo[digitIndex] != -1)
        {
            return Memo[digitIndex];
        }

        var lo = limitLow ? StartString[digitIndex] - '0' : 0;
        var hi = limitHigh ? FinishString[digitIndex] - '0' : 9;
        long res = 0;

        if (digitIndex < PreLength)
        {
            for (var digit = lo; digit <= Math.Min(hi, Limit); digit++)
            {
                res += Dfs(digitIndex + 1, limitLow && digit == lo, limitHigh && digit == hi);
            }
        }
        else
        {
            var x = Suffix[digitIndex - PreLength] - '0';
            if (lo <= x && x <= Math.Min(hi, Limit))
            {
                res = Dfs(digitIndex + 1, limitLow && x == lo, limitHigh && x == hi);
            }
        }

        if (!limitLow && !limitHigh)
        {
            Memo[digitIndex] = res;
        }

        return res;
    }

    // Doesnt work
    public long NumberOfPowerfulInt1(long start, long finish, int limit, string s)
    {
        var suffixLength = s.Length;
        var suffixValue = 0;

        // Convert the string to an integer
        for (var i = 1; i < suffixLength + 1; i++)
        {
            var intDigit = int.Parse(s[^i].ToString());

            if (intDigit > limit) // Make sure none of the suffix is bigger than the Limit
            {
                return 0;
            }

            var intIndex = Math.Pow(10, i - 1);
            suffixValue += (int)intIndex * intDigit;
        }

        // No Available numbers if the string is bigger than the biggest possible value
        if (finish < suffixValue)
        {
            return 0;
        }

        long count = 0;
        long lastNumOfAddedValues = 1;

        // Calculating the amount of powerful numbers at the start digits mark
        var startNumOfDigits = GetDigitsOfNum(start);
        var currentDigits = suffixLength;

        if (startNumOfDigits > currentDigits)
        {
            var startDigitMultiplier = (long)Math.Pow(10, startNumOfDigits - 1);
            var startFirstDigit = start / startDigitMultiplier; // Get the first digit of the start number
            var startDiff = startNumOfDigits - currentDigits;

            for (var i = 0; i < startDiff; i++)
            {
                lastNumOfAddedValues *= limit;
            }

            if (startFirstDigit == limit)
            {
                count = lastNumOfAddedValues;
            }
            else if (startFirstDigit < limit)
            {
                lastNumOfAddedValues *= (limit - startFirstDigit);

                if (start % Math.Pow(10, suffixLength) > suffixValue)
                {
                    count = lastNumOfAddedValues;
                }
            }

            currentDigits = startNumOfDigits + 1;
        }
        else
        {
            if (start <= suffixValue)
            {
                count++;
            }
            currentDigits++;
        }

        // Calculating the amount of powerful numbers between the start and finish amount of digits
        var finishNumOfDigits = GetDigitsOfNum(finish);

        if (finishNumOfDigits > currentDigits)
        {
            var finishDiff = finishNumOfDigits - currentDigits;

            for (var i = 0; i < finishDiff; i++)
            {
                var toAdd = lastNumOfAddedValues * limit;
                lastNumOfAddedValues = toAdd;
                count += toAdd;
            }

            currentDigits = finishNumOfDigits;
        }

        if (finishNumOfDigits == currentDigits)
        {
            var finishDigitMultiplier = (long)Math.Pow(10, finishNumOfDigits - 1);
            var finishFirstDigit = finish / finishDigitMultiplier; // Get the first digit of the finish number
            long extraValues = limit;

            if (finishFirstDigit <= limit)
            {
                extraValues = finishFirstDigit;

                if (finish % Math.Pow(10, suffixLength) < suffixValue)
                {
                    extraValues--;
                }
            }

            count += lastNumOfAddedValues * (int)extraValues;
        }

        return count;
    }

    private int GetDigitsOfNum(long num)
    {
        if (num < 10L) return 1;
        if (num < 100L) return 2;
        if (num < 1000L) return 3;
        if (num < 10000L) return 4;
        if (num < 100000L) return 5;
        if (num < 1000000L) return 6;
        if (num < 10000000L) return 7;
        if (num < 100000000L) return 8;
        if (num < 1000000000L) return 9;
        if (num < 10000000000L) return 10;
        if (num < 100000000000L) return 11;
        if (num < 1000000000000L) return 12;
        if (num < 10000000000000L) return 13;
        if (num < 100000000000000L) return 14;
        if (num < 1000000000000000L) return 15;
        if (num < 10000000000000000L) return 16;
        if (num < 100000000000000000L) return 17;
        if (num < 1000000000000000000L) return 18;
        return 19;
    }
}
