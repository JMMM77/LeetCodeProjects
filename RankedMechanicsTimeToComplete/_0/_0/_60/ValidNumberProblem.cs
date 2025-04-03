namespace LeetCodeSolutions._0._0._60;
/***
URL: https://leetcode.com/problems/valid-number/description/
Number: 65
Difficulty: Hard
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
