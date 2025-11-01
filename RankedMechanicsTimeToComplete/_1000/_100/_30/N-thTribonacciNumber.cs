namespace LeetCodeSolutions._1000._100._30;

/***
URL: https://leetcode.com/problems/n-th-tribonacci-number
Number: 1137
Difficulty: Easy
 */
public class N_thTribonacciNumber
{
    public int Tribonacci(int n)
    {
        if (n == 0)
        {
            return 0;
        }

        if (n == 1 || n == 2)
        {
            return 1;
        }

        var current = 0;
        var num1 = 0;
        var num2 = 1;
        var num3 = 1;

        for (var i = 3; i <= n; i++)
        {
            current = num1 + num2 + num3;
            num1 = num2;
            num2 = num3;
            num3 = current;
        }

        return current;
    }
}
