namespace LeetCodeSolutions._0._0._20;

/***
URL: https://leetcode.com/problems/valid-parentheses/description/
Number: 20
Difficulty: easy
 */
public class ValidParenthesesProblem
{
    public bool IsValid(string s)
    {
        var validParentheses = new Stack<char>();
        var parenthesesMapping = new Dictionary<char, char>()
        {
            {')', '('},
            {'}', '{'},
            {']', '['},
        };

        foreach (var sChar in s)
        {
            if (parenthesesMapping.ContainsValue(sChar)) // It is a opening bracket
            {
                validParentheses.Push(sChar);
                continue;
            }
            else if (validParentheses.Peek() == parenthesesMapping[sChar]) // It is a closing bracket which has a corresponding opening bracket.
            {
                validParentheses.Pop();
                continue;
            }
            else
            {
                return false;
            }
        }

        return validParentheses.Count == 0;
    }
}
