namespace LeetCodeSolutions._0._0._10;

/***
URL: https://leetcode.com/problems/integer-to-roman/
Number: 12
Difficulty: Medium
 */
public class IntegerToRomanProblem
{
    private static Dictionary<int, char> hashMap = new()
        {
            { 1, 'I' },
            { 5, 'V' },
            { 10, 'X' },
            { 50, 'L' },
            { 100, 'C' },
            { 500, 'D' },
            { 1000, 'M' }
        };

    public string IntToRoman(int num)
    {
        var romanNumber = new List<char>();

        var digitMulti = 1;

        while (num != 0)
        {
            var digitNum = num % 10;

            if (digitNum != 0)
            {
                romanNumber.AddRange(IntToRomanDigit(digitNum, digitMulti));
                num -= digitNum;
            }

            num /= 10;
            digitMulti *= 10;
        }

        romanNumber.Reverse();

        return string.Concat(romanNumber);
    }

    private List<char> IntToRomanDigit(int numDigit, int digitMultiplier)
    {
        var romanNumber = new List<char>();

        if (numDigit < 4)
        {
            while (numDigit != 0)
            {
                romanNumber.Add(hashMap[1 * digitMultiplier]);
                numDigit--;
            }
        }
        else if (numDigit == 4)
        {
            romanNumber.Add(hashMap[1 * digitMultiplier]);
            romanNumber.Add(hashMap[5 * digitMultiplier]);
        }
        else if (numDigit < 9)
        {
            romanNumber.Add(hashMap[5 * digitMultiplier]);
            numDigit -= 5;

            while (numDigit != 0)
            {
                romanNumber.Add(hashMap[1 * digitMultiplier]);
                numDigit--;
            }
        }
        else
        {
            romanNumber.Add(hashMap[1 * digitMultiplier]);
            romanNumber.Add(hashMap[10 * digitMultiplier]);
        }

        romanNumber.Reverse();

        return romanNumber;
    }
}
