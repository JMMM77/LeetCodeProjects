using System.Text;

namespace LeetCodeSolutions._2000._700._80;

/***
URL: https://leetcode.com/problems/sort-vowels-in-a-string
Number: 2785
Difficulty: Medium
 */
public class SortVowelsinaString
{
    public string SortVowels(string s)
    {
        var vowels = new HashSet<char>()
        {
            'A','E','I','O','U',
            'a','e','i','o','u'
        };

        var vowelIndexes = new List<int>();
        var foundVowels = new List<char>();

        for (var i = 0; i < s.Length; i++)
        {
            if (vowels.Contains(s[i]))
            {
                vowelIndexes.Add(i);
                foundVowels.Add(s[i]);
            }
        }

        foundVowels.Sort();

        var stringToReturn = new StringBuilder(s);

        for (var i = 0; i < vowelIndexes.Count; i++)
        {
            stringToReturn[vowelIndexes[i]] = foundVowels[i];
        }

        return stringToReturn.ToString();
    }
}
