using System.Text;

namespace LeetCodeSolutions._0._0._30;

/***
URL: https://leetcode.com/problems/count-and-say
Number: 38
Difficulty: Medium
 */
public class CountandSay
{
    public string CountAndSay(int n)
    {
        if (n == 1)
        {
            return "1";
        }

        var thisRle = "1";

        for (var i = 2; i <= n; i++)
        {
            thisRle = CalcCountAndSay(thisRle);
        }

        return thisRle;
    }

    private static string CalcCountAndSay(string prevRle)
    {
        var returnStringBuilder = new StringBuilder();
        var lastDigit = prevRle[0];
        var lastDigitCount = 1;

        for (var i = 1; i < prevRle.Length; i++)
        {
            var thisChar = prevRle[i];

            if (thisChar == lastDigit)
            {
                lastDigitCount++;
            }
            else
            {
                returnStringBuilder.Append(lastDigitCount);
                returnStringBuilder.Append(lastDigit);
                lastDigit = thisChar;
                lastDigitCount = 1;
            }
        }

        if (lastDigitCount > 0)
        {
            returnStringBuilder.Append(lastDigitCount);
            returnStringBuilder.Append(lastDigit);
        }

        return returnStringBuilder.ToString();
    }
}
