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
        var sLen = s.Length;
        var pLen = p.Length;
        var dp = new bool[sLen + 1, pLen + 1];

        // Base case: empty string matches empty pattern
        dp[0, 0] = true;

        // Pre-fill cases where pattern contains '*' at even indices
        for (var j = 2; j <= pLen; j += 2)
        {
            if (p[j - 1] == '*')
            {
                dp[0, j] = dp[0, j - 2]; // '*' can remove preceding character
            }
        }

        // Fill DP table
        for (var i = 1; i <= sLen; i++)
        {
            for (var j = 1; j <= pLen; j++)
            {
                var sChar = s[i - 1]; // Current character in string
                var pChar = p[j - 1]; // Current character in pattern

                if (pChar == sChar || pChar == '.')
                {
                    // Direct match or '.' wildcard
                    dp[i, j] = dp[i - 1, j - 1];
                }
                else if (pChar == '*')
                {
                    var precedingChar = p[j - 2]; // Character before '*'

                    // '*' can act as zero occurrence (remove precedingChar)
                    dp[i, j] = dp[i, j - 2];

                    // '*' can also match one or more occurrences of precedingChar
                    if (precedingChar == sChar || precedingChar == '.')
                    {
                        dp[i, j] |= dp[i - 1, j];
                    }
                }
            }
        }

        // Final answer is whether full string matches full pattern
        return dp[sLen, pLen];
    }

    // Doesnt work in some cases
    public bool IsMatch1(string s, string p)
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
