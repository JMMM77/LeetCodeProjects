namespace LeetCodeSolutions._0._800._80;
/***
URL: https://leetcode.com/problems/count-symmetric-integers
Number: 2843
Difficulty: Easy
 */
public class CountSymmetricIntegersProblem
{
    public int CountSymmetricIntegers(int low, int high)
    {
        var count = 0;

        if (low < 100)
        {
            var highEnd = high < 100 ? high : 100;

            for (var i = low; i <= highEnd; i++)
            {
                if (i % 11 == 0)
                {
                    i += 10;
                    count++;
                }
            }
        }

        if (high < 1000)
        {
            return count;
        }

        var lowEnd = low < 1000 ? 1000 : low;
        var maxEnd = high < 10000 ? high : 9999;

        for (var i = lowEnd; i <= maxEnd; i++)
        {
            var numAsString = i.ToString();

            if (numAsString[0] + numAsString[1] == numAsString[2] + numAsString[3])
            {
                count++;
            }
        }

        return count;
    }

    // Calculates all the symmetric integers below this number
    private int Calculate(int num)
    {
        if (num < 11)
        {
            return 0;
        }

        var count = (num % 100) / 11; // e.g. 11, 22, 33, 44, 55, 66, 77, 88, and 99.

        // Known constraints is nums is not bigger than 10000
        // There are only two symmetric digits under 10000: XXXX e.g. 1234 and XX e.g. 12
        if (num < 1000)
        {
            return count;
        }

        // The number has 4 digits
        var numString = num.ToString();
        var currentDigit = numString[0] - '0';

        return count;
    }
}
