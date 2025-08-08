namespace LeetCodeSolutions._0._0._40;
/***
URL: https://leetcode.com/problems/wildcard-matching
Number: 44
Difficulty: Hard
 */
public class WildcardMatchingProblem
{
    public bool IsMatch(string s, string p)
    {
        int sIndex = 0, pIndex = 0;
        int starIndex = -1, match = 0;

        while (sIndex < s.Length)
        {
            if (pIndex < p.Length && (p[pIndex] == s[sIndex] || p[pIndex] == '?'))
            {
                // Characters match or '?'
                sIndex++;
                pIndex++;
            }
            else if (pIndex < p.Length && p[pIndex] == '*')
            {
                // Record star position and matching index
                starIndex = pIndex;
                match = sIndex;
                pIndex++;
            }
            else if (starIndex != -1)
            {
                // Backtrack: retry with one more character absorbed by '*'
                pIndex = starIndex + 1;
                match++;
                sIndex = match;
            }
            else
            {
                return false;
            }
        }

        // Check for remaining '*' in pattern
        while (pIndex < p.Length && p[pIndex] == '*')
        {
            pIndex++;
        }

        return pIndex == p.Length;
    }
}
