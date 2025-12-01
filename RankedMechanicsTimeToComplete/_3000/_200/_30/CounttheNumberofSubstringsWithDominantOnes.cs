namespace LeetCodeSolutions._3000._200._30;

/***
URL: https://leetcode.com/problems/count-the-number-of-substrings-with-dominant-ones
Number: 3234
Difficulty: Medium
 */
public class CounttheNumberofSubstringsWithDominantOnes
{
    public int NumberOfSubstrings(string s)
    {
        var n = s.Length;
        // Stores the index of the closest position ≤ i-1 where a '0' occurred
        // OR if the last character at i-1 is '0', then pre[i] = i-1
        // To jump backwards over zeros
        var pre = new int[n + 1];

        pre[0] = -1;

        for (var i = 0; i < n; i++)
        {
            pre[i + 1] = i == 0 || (i > 0 && s[i - 1] == '0') ? i : pre[i];
        }

        var result = 0;

        for (var i = 1; i <= n; i++)
        {
            var numOfZeros = s[i - 1] == '0' ? 1 : 0;
            var j = i;

            // Backtrack
            while (j > 0 && numOfZeros * numOfZeros <= n)
            {
                var numOfOnes = i - pre[j] - numOfZeros;

                if (numOfZeros * numOfZeros <= numOfOnes)
                {
                    result += Math.Min(j - pre[j], numOfOnes - (numOfZeros * numOfZeros) + 1);
                }

                j = pre[j];
                numOfZeros++;
            }
        }

        return result;
    }
}
