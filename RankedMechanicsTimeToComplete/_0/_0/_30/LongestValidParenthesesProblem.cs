namespace LeetCodeSolutions._0._0._30;

/***
URL: https://leetcode.com/problems/longest-valid-parentheses
Number: 32
Difficulty: Hard
 */
public class LongestValidParenthesesProblem
{
    public int LongestValidParentheses(string s)
    {
        var maxLen = 0;
        var stack = new Stack<int>();
        stack.Push(-1); // base index

        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                stack.Push(i);
                continue;
            }

            stack.Pop();

            if (stack.Count == 0)
            {
                stack.Push(i); // reset base
                continue;
            }

            maxLen = Math.Max(maxLen, i - stack.Peek());
        }

        return maxLen;
    }
}
