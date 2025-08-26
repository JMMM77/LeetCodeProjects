namespace LeetCodeSolutions._0._100._20;

/***
URL: https://leetcode.com/problems/best-time-to-buy-and-sell-stock
Number: 121
Difficulty: Easy
 */
public class ValidPalindrome
{
    public bool IsPalindrome(string s)
    {
        var alphaChars = new HashSet<char>()
        {
            'a',
            'b',
            'c',
            'd',
            'e',
            'f',
            'g',
            'h',
            'i',
            'j',
            'k',
            'l',
            'm',
            'n',
            'o',
            'p',
            'q',
            'r',
            's',
            't',
            'u',
            'v',
            'w',
            'x',
            'y',
            'z',
            '0',
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9',
        };

        var potentialPalindrome = s.ToLower().Where(x => alphaChars.Contains(x)).ToArray();

        for (var i = 0; i < potentialPalindrome.Length / 2; i++)
        {
            if (potentialPalindrome[i] != potentialPalindrome[potentialPalindrome.Length - i - 1])
            {
                return false;
            }
        }

        return true;
    }
}
