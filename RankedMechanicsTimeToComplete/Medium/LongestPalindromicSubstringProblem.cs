namespace LeetCodeSolutions.Medium;

public class LongestPalindromicSubstringProblem
{
    public string LongestPalindrome(string s)
    {
        // Learning dynamic programming
        var n = s.Length;
        var dp = new bool[n, n];
        int[] ans = [0, 0];

        // All substrings of length 1 are palindromes
        for (var i = 0; i < n; i++)
        {
            dp[i, i] = true;
        }

        // "i, i + 1" is a palindrome if "s[i] == s[i + 1]"
        for (var i = 0; i < n - 1; i++)
        {
            if (s[i] == s[i + 1])
            {
                dp[i, i + 1] = true;
                ans = [i, i + 1];
            }
        }

        // do the same step as a above but instead of just for 2 length do it up to n length
        for (var diff = 2; diff < n; diff++)
        {
            for (var i = 0; i < n - diff; i++)
            {
                var j = i + diff;
                if (s[i] == s[j] && dp[i + 1, j - 1])
                {
                    dp[i, j] = true;
                    ans = [i, j]; // Starting from smallest to largest so every new palindrome is the new longest
                }
            }
        }

        var start = ans[0];
        var end = ans[1];
        return s.Substring(start, end - start + 1);
    }

    // Brute force
    public string LongestPalindrome1(string s)
    {
        var longestPalindrome = string.Empty;

        // Loop from start to end and end to start
        for (var i = 0; i < s.Length; i++)
        {
            for (var x = s.Length - 1; x >= i; x--)
            {
                // If at any time the pointers are equal start checking for palindrome
                if (s[i].Equals(s[x]))
                {
                    var potentialPalindrome = s[i].ToString();
                    var isPalindrome = true;

                    // Make sure each character from start to end and end to start are equal
                    for (var y = 1; y <= x - i; y++)
                    {
                        var leftPointer = i + y;
                        var rightPointer = x - y;
                        var leftCharacter = s[leftPointer];
                        var rightCharacter = s[rightPointer];

                        // Break whenever we realise it is not a palindrome
                        if (!leftCharacter.Equals(rightCharacter) && leftPointer <= rightPointer)
                        {
                            isPalindrome = false;
                            break;
                        }

                        // Getting to the middle of the string so finish creating potential palindrome
                        if (leftPointer == rightPointer - 1)
                        {
                            potentialPalindrome = potentialPalindrome + leftCharacter + rightCharacter + string.Concat(potentialPalindrome.Reverse());
                            break;
                        }
                        else if (leftPointer == rightPointer)
                        {
                            potentialPalindrome = potentialPalindrome + leftCharacter + string.Concat(potentialPalindrome.Reverse());
                            break;
                        }

                        potentialPalindrome += leftCharacter;
                    }

                    if (isPalindrome && potentialPalindrome == string.Concat(potentialPalindrome.Reverse()) && potentialPalindrome.Length > longestPalindrome.Length)
                    {
                        longestPalindrome = potentialPalindrome;
                    }
                }
            }
        }

        return longestPalindrome;
    }
}
