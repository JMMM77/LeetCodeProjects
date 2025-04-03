namespace LeetCodeSolutions._0._0._0;

/***
URL: https://leetcode.com/problems/palindrome-number/
Number: 9
Difficulty: Easy
 */

public class PalindromeNumberProblem
{
    public bool IsPalindrome(int x)
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
}
