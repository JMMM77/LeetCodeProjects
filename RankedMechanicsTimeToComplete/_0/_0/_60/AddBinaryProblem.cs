namespace LeetCodeSolutions._0._0._60;

/***
URL: https://leetcode.com/problems/add-binary
Number: 67
Difficulty: Easy
 */
public class AddBinaryProblem
{
    public string AddBinary(string a, string b)
    {
        var carryOvered = '0';
        var currentIndex = 0;
        var aReversed = a.Reverse().ToArray();
        var bReversed = b.Reverse().ToArray();
        var returnString = Enumerable.Empty<char>();

        while (currentIndex < a.Length || currentIndex < b.Length)
        {
            var aValue = '0';

            if (currentIndex < a.Length)
            {
                aValue = aReversed[currentIndex];
            }

            var bValue = '0';
            if (currentIndex < b.Length)
            {
                bValue = bReversed[currentIndex];
            }

            currentIndex++;

            if (aValue == '0' && bValue == '0')
            {
                returnString = returnString.Prepend(carryOvered);
                carryOvered = '0';
                continue;
            }

            if (aValue == '1' && bValue == '1')
            {
                returnString = returnString.Prepend(carryOvered);
                carryOvered = '1';
                continue;
            }

            if (carryOvered == '1')
            {
                returnString = returnString.Prepend('0');
                continue;
            }

            returnString = returnString.Prepend('1');
        }

        if (carryOvered == '1')
        {
            returnString = returnString.Prepend('1');
        }

        return string.Join("", returnString);
    }
}
