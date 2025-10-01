using System.Text;

namespace LeetCodeSolutions._0._900._60;

/***
URL: https://leetcode.com/problems/vowel-spellchecker
Number: 966
Difficulty: Medium
 */
public class VowelSpellchecker
{
    public string[] Spellchecker(string[] wordlist, string[] queries)
    {
        var exactMatches = new HashSet<string>();
        var caseInsensitiveMatches = new Dictionary<string, string>();
        var vowelMatches = new Dictionary<string, string>();

        foreach (var word in wordlist)
        {
            exactMatches.Add(word);
            caseInsensitiveMatches.TryAdd(word.ToLower(), word);
            vowelMatches.TryAdd(RemoveVowels(word.ToLower()), word);
        }

        var wordsToReturn = new string[queries.Length];

        for (var i = 0; i < queries.Length; i++)
        {
            var word = queries[i];

            if (exactMatches.Contains(word))
            {
                wordsToReturn[i] = word;
                continue;
            }

            var lowerWord = word.ToLower();

            if (caseInsensitiveMatches.TryGetValue(lowerWord, out var caseInsensitiveMatchedWord))
            {
                wordsToReturn[i] = caseInsensitiveMatchedWord;
                continue;
            }

            if (vowelMatches.TryGetValue(RemoveVowels(lowerWord), out var vowelMatchedWord))
            {
                wordsToReturn[i] = vowelMatchedWord;
                continue;
            }

            wordsToReturn[i] = "";
        }

        return wordsToReturn;
    }

    private string RemoveVowels(string word)
    {
        var stringBuilder = new StringBuilder();

        foreach (var ch in word)
        {
            if ("aeiou".Contains(ch))
            {
                stringBuilder.Append('.');
            }
            else
            {
                stringBuilder.Append(ch);
            }
        }

        return stringBuilder.ToString();
    }
}
