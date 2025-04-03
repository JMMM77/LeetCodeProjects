namespace LeetCodeSolutions._0._0._0;

/***
URL: https://leetcode.com/problems/string-to-integer-atoi/
Number: 8
Difficulty: Medium
 */

public class StringToIntegerATOIProblem
{
    public int MyAtoi(string s)
    {
        var trimmedString = s.Trim();
        var isNegative = false;
        var pointer = 0;

        // Handles if string is empty or just whitespace
        if (string.IsNullOrWhiteSpace(trimmedString))
        {
            return 0;
        }

        if (trimmedString[0].Equals('-'))
        {
            isNegative = true;
            pointer++;
        }
        else if (trimmedString[0].Equals('+'))
        {
            pointer++;
        }

        var numberBuilder = "";

        for (var i = pointer; i < trimmedString.Length; i++)
        {
            var charToCheck = trimmedString[i].ToString();

            if (!int.TryParse(charToCheck, out _))
            {
                break; // No longer a number
            }

            numberBuilder += charToCheck;
        }

        long convertedString;

        try
        {
            convertedString = int.Parse(numberBuilder);
        }
        catch (OverflowException)
        {
            // Edge case if it overflows the implicit conversion from long to int seems to flip its value
            // Easier to manually state what the overflow return should be
            if (isNegative)
            {
                return -2147483648;
            }
            else
            {
                return 2147483647;
            }
        }
        catch (Exception)
        {
            return 0; // If the string is invalid just return 0
        }

        return (int)(isNegative ? -1 * convertedString : convertedString);
    }
}
