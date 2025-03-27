namespace LeetCodeSolutions.Easy;

/***
URL: https://leetcode.com/problems/palindrome-number/

Given an integer x, return true if x is a palindrome, and false otherwise.

 

Example 1:

Input: x = 121
Output: true
Explanation: 121 reads as 121 from left to right and from right to left.
Example 2:

Input: x = -121
Output: false
Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
Example 3:

Input: x = 10
Output: false
Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
 

Constraints:

-231 <= x <= 231 - 1
 

Follow up: Could you solve it without converting the integer to a string?
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
