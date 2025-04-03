namespace LeetCodeSolutions._0._0._0;

/***
URL: https://leetcode.com/problems/reverse-integer
Number: 7
Difficulty: Medium
 */
public class ReverseIntegerProblem
{
    public bool Reverse(int x)
    {
        var reversedNumber = 0;
        var originalNumber = x;

        while (x > 0)
        {
            reversedNumber *= 10;
            reversedNumber += x % 10;
            x /= 10;
        }

        return reversedNumber == originalNumber;
    }

    public bool Reverse1(int x)
    {
        var xString = x.ToString();
        return xString.Equals(string.Concat(xString.Reverse()));
    }
}
