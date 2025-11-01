namespace LeetCodeSolutions._3000._400._60;

/***
URL: https://leetcode.com/problems/check-if-digits-are-equal-in-string-after-operations-i
Number: 3461
Difficulty: Easy
 */
public class CheckIfDigitsAreEqualinStringAfterOperationsI
{
    public bool HasSameDigits(string s)
    {
        var sArray = new int[s.Length];

        for (var i = 0; i < sArray.Length; i++)
        {
            sArray[i] = s[i] - '0';
        }

        while (sArray.Length != 2)
        {
            var nextArray = new int[sArray.Length - 1];

            for (var i = 0; i < nextArray.Length; i++)
            {
                nextArray[i] = (sArray[i] + sArray[i + 1]) % 10;
            }

            sArray = nextArray;
        }

        return sArray[0] == sArray[1];
    }
}
