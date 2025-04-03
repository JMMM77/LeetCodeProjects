namespace LeetCodeSolutions._0._0._10;

/***
URL: https://leetcode.com/problems/regular-expression-matching/description/
Number: 10
Difficulty: Hard
 */
public class RegularExpressionMatchingProblem
{
    public bool IsMatch(string s, string p)
    {
        if (!(p.Contains('.') || p.Contains('*')))
        {
            return p.Equals(s);
        }

        var prevChar = '!';

        for (var i = 0; i < p.Length; i++)
        {
            if (s.Length == 0)
            {
                return false;
            }

            var incrementString = false;
            var thisChar = p[i];

            if (thisChar.Equals('.'))
            {
                incrementString = true;
            }
            else if (thisChar.Equals('*'))
            {
                if (prevChar == '.')
                {
                    if (i + 1 == p.Length)
                    {
                        return true;
                    }

                    while (s.Length != 0 && s[0] != p[i + 1])
                    {
                        s = s[1..];
                    }
                }
                else
                {
                    var incremented = false;
                    var nextChar = i + 1 < p.Length ? p[i + 1] : '!';

                    while (s.Length != 0 && prevChar == s[0] && s[0] != nextChar)
                    {
                        incremented = true;
                        s = s[1..];
                    }

                    if (!incremented && thisChar == s[0])
                    {
                        incrementString = true;
                    }
                }
            }
            else if (thisChar == s[0])
            {
                if (i + 1 < p.Length && p[i + 1].Equals('*'))
                {
                    prevChar = thisChar;
                    continue;
                }

                incrementString = true;
            }
            else
            {
                if (i + 1 < p.Length && p[i + 1].Equals('*'))
                {
                    prevChar = thisChar;
                    continue;
                }

                return false;
            }

            if (s.Length == 0)
            {
                continue;
            }

            if (incrementString)
            {
                s = s[1..];
            }

            prevChar = thisChar;
        }

        return s.Length == 0;
    }
}
