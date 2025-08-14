namespace LeetCodeSolutions._0._0._60;

/***
URL: https://leetcode.com/problems/sqrtx
Number: 69
Difficulty: Easy
 */
public class SqrtX
{
    public int MySqrt(int x)
    {
        double currentNum = 0;

        while ((currentNum * currentNum) <= x)
        {
            currentNum++;
        }

        return (int)currentNum - 1;
    }
}
