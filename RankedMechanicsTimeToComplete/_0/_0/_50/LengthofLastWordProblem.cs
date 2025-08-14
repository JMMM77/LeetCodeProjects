namespace LeetCodeSolutions._0._0._50;

/***
URL: https://leetcode.com/problems/length-of-last-word
Number: 58
Difficulty: Easy
 */
public class LengthofLastWordProblem
{
    public int LengthOfLastWord(string s)
    {
        var foundLetter = false;
        var lengthOfWordToReturn = 0;

        for (var i = s.Length - 1; i >= 0; i--)
        {
            var isSpace = s[i] == ' ';

            if (foundLetter && isSpace)
            {
                break;
            }

            if (isSpace)
            {
                continue;
            }

            foundLetter = true;
            lengthOfWordToReturn++;
        }

        return lengthOfWordToReturn;
    }
}
