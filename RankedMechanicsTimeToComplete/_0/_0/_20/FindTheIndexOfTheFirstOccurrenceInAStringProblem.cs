namespace LeetCodeSolutions._0._0._20;
/***
URL: https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/
Number: 28
Difficulty: easy
 */
public class FindTheIndexOfTheFirstOccurrenceInAStringProblem
{
    public int StrStr(string haystack, string needle)
    {
        for (var i = 0; i <= haystack.Length - needle.Length; i++)
        {
            if (haystack.Substring(i, needle.Length) == needle)
            {
                return i;
            }
        }

        return -1;
    }

    // Slow
    public int StrStr1(string haystack, string needle)
    {
        return haystack.IndexOf(needle);
    }
}
