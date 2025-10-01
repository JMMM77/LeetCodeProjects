namespace LeetCodeSolutions._0._300._20;

/***
URL: https://leetcode.com/problems/power-of-three
Number: 326
Difficulty: Easy
 */
public class PowerofThree
{
    public bool IsPowerOfThree(int n)
    {
        if (n < 1)
        {
            return false;
        }

        if (n == 1)
        {
            return true;
        }

        if (n % 3 != 0)
        {
            return false;
        }

        // Logarithm Rules: If Log(Length) / log(3) is not an integer, then Length is not a power of 3
        var logRuleResult = Math.Log10(n) / Math.Log10(3);

        return (logRuleResult - (int)logRuleResult) == 0;
    }
}
