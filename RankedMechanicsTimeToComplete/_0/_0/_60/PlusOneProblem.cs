namespace LeetCodeSolutions._0._0._60;

/***
URL: https://leetcode.com/problems/plus-one
Number: 66
Difficulty: Easy
 */
public class PlusOneProblem
{
    public int[] PlusOne(int[] digits)
    {
        var carryOver = false;

        for (var i = digits.Length - 1; i >= 0; i--)
        {
            if (digits[i] < 9)
            {
                digits[i]++;
                return digits;
            }

            carryOver = true;
            digits[i] = 0;
        }

        if (carryOver)
        {
            return digits.Prepend(1).ToArray();
        }

        return digits;
    }
}
