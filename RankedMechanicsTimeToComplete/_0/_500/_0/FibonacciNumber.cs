namespace LeetCodeSolutions._0._500._0;

/***
URL: https://leetcode.com/problems/fibonacci-number
Number: 509
Difficulty: Easy
 */
public class FibonacciNumber
{
    public int Fib(int n)
    {
        if (n < 2)
        {
            return n;
        }

        var prevNum = 0;
        var currentNum = 1;

        for (var i = 1; i < n; i++)
        {
            var tempNum = currentNum;

            currentNum = prevNum + currentNum;
            prevNum = tempNum;
        }

        return currentNum;
    }
}
