namespace LeetCodeSolutions._1000._300._10;

/***
URL: https://leetcode.com/problems/convert-integer-to-the-sum-of-two-no-zero-integers
Number: 1317
Difficulty: Easy
 */
public class ConvertIntegertotheSumofTwoNo_ZeroIntegers
{
    public int[] GetNoZeroIntegers(int n)
    {
        for (var i = 0; i <= n / 2; i++)
        {
            if (!i.ToString().Contains('0') && !(n - i).ToString().Contains('0'))
            {
                return [i, n - i];
            }
        }

        return [];
    }
}
