namespace LeetCodeSolutions._0._0._70;

/***
URL: https://leetcode.com/problems/climbing-stairs
Number: 70
Difficulty: Easy
 */
public class ClimbingStairs
{
    public int ClimbStairs(int n)
    {
        var prevNum = 0;
        var currentNum = 1;

        for (var i = 0; i < n; i++)
        {
            var tempNum = currentNum;
            currentNum = prevNum + currentNum;
            prevNum = tempNum;
        }

        return currentNum;
    }
}
