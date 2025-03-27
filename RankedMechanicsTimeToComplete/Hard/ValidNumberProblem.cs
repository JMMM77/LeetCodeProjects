namespace LeetCodeSolutions.Hard;
/***
URL: https://leetcode.com/problems/valid-number/description/

Given a string s, return whether s is a valid number.

For example, all the following are valid numbers: "2", "0089", "-0.1", "+3.14", "4.", "-.9", "2e10", "-90E3", "3e+7", "+6e-1", "53.5e93", "-123.456e789", while the following are not valid numbers: "abc", "1a", "1e", "e3", "99e2.5", "--6", "-+3", "95a54e53".

Formally, a valid number is defined using one of the following definitions:

An integer number followed by an optional exponent.
A decimal number followed by an optional exponent.
An integer number is defined with an optional sign '-' or '+' followed by digits.

A decimal number is defined with an optional sign '-' or '+' followed by one of the following definitions:

Digits followed by a dot '.'.
Digits followed by a dot '.' followed by digits.
A dot '.' followed by digits.
An exponent is defined with an exponent notation 'e' or 'E' followed by an integer number.

The digits are defined as one or more digits.

Example 1:

Input: s = "0"

Output: true

Example 2:

Input: s = "e"

Output: false

Example 3:

Input: s = "."

Output: false

Constraints:

1 <= s.length <= 20
s consists of only English letters (both uppercase and lowercase), digits (0-9), plus '+', minus '-', or dot '.'.
 */
public class ValidNumberProblem
{
    private static readonly char[] CharactersForNumber = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
    private static readonly char[] Symbol = ['-', '+'];
    private const char Pointer = '.';
    private static readonly char[] AllValidCharacters = CharactersForNumber.Concat(Symbol).Append(Pointer).Append('e').ToArray();

    public bool IsNumber(string s)
    {
        var trimmedString = s.Trim().ToLower();

        if (!OnlyContainsValidCharacters(trimmedString))
        {
            return false;
        }

        if (trimmedString.StartsWith('-') || trimmedString.StartsWith('+'))
        {
            trimmedString = trimmedString.Substring(1);
        }

        if (string.IsNullOrWhiteSpace(trimmedString))
        {
            return false;
        }

        var firstChar = trimmedString[0];

        if (!CharactersForNumber.Contains(firstChar)
            && !firstChar.Equals(Pointer))
        {
            return false; // After removing leading 0's, whitespace and symbols it should only start with a number or pointer
        }

        // Check if its a valid exponent
        if (trimmedString.Contains('e'))
        {
            if (trimmedString.EndsWith('e'))
            {
                return false;
            }

            var tempString = trimmedString.Split('e');

            var leftString = tempString[0];
            var lastCharacterOfLeftSide = leftString[^1];

            if (!CharactersForNumber.Contains(lastCharacterOfLeftSide)
                && !(lastCharacterOfLeftSide.Equals(Pointer)
                && leftString.Length != 1))
            {
                return false;
            }

            var firstCharacterOfRightSide = tempString[1][0];
            var firstCharacterIsSymbol = Symbol.Contains(firstCharacterOfRightSide);

            if (firstCharacterIsSymbol && tempString[1].Length == 1)
            {
                return false;
            }

            if (!CharactersForNumber.Contains(firstCharacterOfRightSide)
                && !firstCharacterIsSymbol)
            {
                return false;
            }

            if (tempString[1].Contains(Pointer))
            {
                return false;
            }

            if ((trimmedString.Contains('-') || trimmedString.Contains('+'))
                && !(Symbol.Contains(firstCharacterOfRightSide) || Symbol.Contains(lastCharacterOfLeftSide)))
            {
                return false; // Handles: "459277e38+"
            }

            trimmedString = trimmedString.Replace("e", "").Replace("+", "").Replace("-", "");
        }

        if (trimmedString.Contains('-') || trimmedString.Contains('+'))
        {
            return false;
        }

        return !string.IsNullOrWhiteSpace(trimmedString.Replace(".", ""));
    }

    private bool OnlyContainsValidCharacters(string s)
    {
        var numOfPlusOrMinus = 0;
        var alreadyHasE = false;
        var alreadyHasPoint = false;

        foreach (var character in s)
        {
            if (!AllValidCharacters.Contains(character))
            {
                return false;
            }

            if (Symbol.Contains(character))
            {
                numOfPlusOrMinus++;

                if (numOfPlusOrMinus > 2)
                {
                    return false; // Shouldn't be a scenario with more than two symbols e.g. -2e-2
                }
            }

            if (character.Equals('e'))
            {
                if (alreadyHasE)
                {
                    return false; // Shouldn't be a scenario with more than 1 e
                }

                alreadyHasE = true;
            }

            if (character.Equals(Pointer))
            {
                if (alreadyHasPoint)
                {
                    return false; // Shouldn't be a scenario with more than 1 .
                }

                alreadyHasPoint = true;
            }
        }

        return true;
    }
}
