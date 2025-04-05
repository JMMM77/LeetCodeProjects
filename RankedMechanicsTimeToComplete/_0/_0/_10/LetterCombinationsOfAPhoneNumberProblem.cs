namespace LeetCodeSolutions._0._0._10;

/***
URL: https://leetcode.com/problems/letter-combinations-of-a-phone-number/
Number: 17
Difficulty: Medium
 */
public class LetterCombinationsOfAPhoneNumberProblem
{
    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0)
        {
            return [];
        }

        var phoneMapping = new Dictionary<char, char[]>()
        {
            { '2', ['a', 'b', 'c']},
            { '3', ['d', 'e', 'f']},
            { '4', ['g', 'h', 'i']},
            { '5', ['j', 'k', 'l']},
            { '6', ['m', 'n', 'o']},
            { '7', ['p', 'q', 'r', 's']},
            { '8', ['t', 'u', 'v']},
            { '9', ['w', 'x', 'y', 'z']},
        };

        var initialDigits = phoneMapping[digits[0]];
        var potentialAnswers = new List<char[]>();

        foreach (var digit in initialDigits)
        {
            potentialAnswers.Add([digit]);
        }

        for (var i = 1; i < digits.Length; i++)
        {
            var charsForCurrentNum = phoneMapping[digits[i]];
            var updatedAnswers = new List<char[]>();

            foreach (var potentialAnswer in potentialAnswers)
            {
                foreach (var letter in charsForCurrentNum)
                {
                    updatedAnswers.Add(potentialAnswer.Append(letter).ToArray());
                }
            }

            potentialAnswers = updatedAnswers;
        }

        return potentialAnswers.Select(x => string.Concat(x)).ToList();
    }
}
