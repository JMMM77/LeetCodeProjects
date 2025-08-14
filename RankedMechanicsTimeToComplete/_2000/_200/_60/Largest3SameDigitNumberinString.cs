namespace LeetCodeSolutions._2000._200._60;

/***
URL: https://leetcode.com/problems/largest-3-same-digit-number-in-string
Number: 2264
Difficulty: Easy
 */
public class Largest3SameDigitNumberinString
{
    public string LargestGoodInteger(string num)
    {
        var largestSubString = string.Empty;

        for (var i = 0; i < num.Length - 2; i++)
        {
            if (num[i] == num[i + 1] && num[i] == num[i + 2])
            {
                if (largestSubString == "" || largestSubString[0] < num[i])
                {
                    largestSubString = $"{num[i]}{num[i]}{num[i]}";
                }

                i += 2;
            }
        }

        return largestSubString;
    }
}
