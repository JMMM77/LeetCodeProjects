namespace LeetCodeSolutions._0._300._40;

/***
URL: https://leetcode.com/problems/power-of-four
Number: 342
Difficulty: Easy
 */
public class PowerofFour
{
    public bool IsPowerOfFour(int n)
    {
        if (n < 1)
        {
            return false;
        }

        if (n == 1)
        {
            return true;
        }

        // Logarithm Rules: If Log(Length) / log(4) is not an integer, then Length is not a power of 4
        var logRuleResult = Math.Log10(n) / Math.Log10(4);

        return (logRuleResult - (int)logRuleResult) == 0;
    }
}
