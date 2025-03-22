namespace LeetCodeSolutions.Medium;

/***
URL: https://leetcode.com/problems/longest-substring-without-repeating-characters/

Given a string s, find the length of the longest substring without duplicate characters.

Example 1:

Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.
Example 2:

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
Example 3:

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 
Constraints:

0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.
 */

public class LongestSubstringWithoutRepeatingCharactersProblem
{
    public int LengthOfLongestSubstring(string s)
    {
        var characterList = new List<char>();
        var longestSubString = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var character = s[i];

            var characterIndex = characterList.IndexOf(character);

            if (characterIndex == -1)
            {
                characterList.Add(character);
                continue;
            }

            if (characterList.Count > longestSubString)
            {
                longestSubString = characterList.Count;
            }

            // Reset the character list to include the latest character removing everything before its first instance
            characterList = characterIndex != characterList.Count - 1
                ? characterList.GetRange(characterIndex + 1, characterList.Count - characterIndex - 1)
                : [];

            characterList.Add(character);
        }

        if (characterList.Count > longestSubString)
        {
            longestSubString = characterList.Count;
        }

        return longestSubString;
    }
}
