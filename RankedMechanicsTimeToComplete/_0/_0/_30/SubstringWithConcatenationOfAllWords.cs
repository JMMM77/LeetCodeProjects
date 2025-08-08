namespace LeetCodeSolutions._0._0._30;

/***
URL: https://leetcode.com/problems/substring-with-concatenation-of-all-words
Number: 30
Difficulty: Hard
 */
public class SubstringWithConcatenationOfAllWords
{
    public IList<int> FindSubstring(string s, string[] words)
    {
        var lengthOfEachConcat = words[0].Length;
        var totalLengthOfConcat = words[0].Length * words.Length;
        var wordsHashed = new Dictionary<string, int>();

        foreach (var word in words)
        {
            if (wordsHashed.ContainsKey(word))
            {
                wordsHashed[word]++;
                continue;
            }

            wordsHashed.Add(word, 1);
        }

        var indexesToReturn = new List<int>();

        for (var i = 0; i + totalLengthOfConcat <= s.Length; i++)
        {
            var tempHashSet = new Dictionary<string, int>(wordsHashed);
            var thisIndex = i;
            var substring = s.Substring(thisIndex, lengthOfEachConcat);

            while (tempHashSet.TryGetValue(substring, out var val))
            {
                if (val == 1)
                {
                    tempHashSet.Remove(substring);
                }
                else
                {
                    tempHashSet[substring]--;
                }

                thisIndex += lengthOfEachConcat;

                if (thisIndex + lengthOfEachConcat > s.Length)
                {
                    break;
                }

                substring = s.Substring(thisIndex, lengthOfEachConcat);
            }

            if (tempHashSet.Keys.Count == 0)
            {
                indexesToReturn.Add(i);
            }
        }

        return indexesToReturn;
    }
}
