namespace LeetCodeSolutions._1000._900._30;

/***
URL: https://leetcode.com/problems/maximum-number-of-words-you-can-type
Number: 1935
Difficulty: Easy
 */
public class MaximumNumberofWordsYouCanType
{
    public int CanBeTypedWords(string text, string brokenLetters)
    {
        var words = text.Split(' ');
        var numOfValidWords = words.Length;

        foreach (var word in words)
        {
            foreach (var brokenLetter in brokenLetters)
            {
                if (word.Contains(brokenLetter))
                {
                    numOfValidWords--;
                    break;
                }
            }
        }

        return numOfValidWords;
    }
}
