namespace LeetCodeSolutions._0._100._60;

/***
URL: https://leetcode.com/problems/fraction-to-recurring-decimal
Number: 166
Difficulty: Medium
 */
public class FractiontoRecurringDecimal
{
    public string FractionToDecimal(int numerator, int denominator)
    {
        if (numerator == 0)
        {
            return "0";
        }

        var sign = ((numerator < 0) ^ (denominator < 0)) ? "-" : "";
        var absNumer = Math.Abs((long)numerator);
        var absDenom = Math.Abs((long)denominator);

        var divResult = absNumer / absDenom;
        var mod = absNumer % absDenom;

        if (mod == 0)
        {
            return sign + divResult.ToString();
        }

        var fracts = new List<string>();
        var modsPositions = new Dictionary<long, int>();

        var returnString = sign + divResult.ToString() + ".";
        var index = 0;

        while (mod != 0)
        {
            if (modsPositions.TryGetValue(mod, out var repeatStartIndex))
            {
                var nonRepeat = string.Join("", fracts.GetRange(0, repeatStartIndex));
                var repeat = string.Join("", fracts.GetRange(repeatStartIndex, fracts.Count - repeatStartIndex));

                return returnString + nonRepeat + "(" + repeat + ")";
            }

            modsPositions[mod] = index;

            mod *= 10;

            var nextFractionDigit = mod / absDenom;

            fracts.Add(nextFractionDigit.ToString());
            mod %= absDenom;
            index++;
        }

        return returnString + string.Join("", fracts);
    }
}
