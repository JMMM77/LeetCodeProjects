namespace LeetCodeSolutions._0._0._0;

/***
URL: https://leetcode.com/problems/longest-substring-without-repeating-characters/
Number: 3
Difficulty: Medium
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
