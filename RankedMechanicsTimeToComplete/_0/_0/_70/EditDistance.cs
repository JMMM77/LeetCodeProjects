namespace LeetCodeSolutions._0._0._70;

/***
URL: https://leetcode.com/problems/edit-distance
Number: 72
Difficulty: Medium
 */
public class EditDistance
{
    public int MinDistance(string word1, string word2)
    {
        var n = word1.Length;
        var m = word2.Length;

        if (n == 0)
        {
            return m;
        }

        if (m == 0)
        {
            return n;
        }

        var dp = new int[n + 1][];

        for (var i = 0; i <= n; i++)
        {
            dp[i] = new int[m + 1];
        }

        // Initialize base cases
        for (var i = 0; i <= n; i++)
        {
            dp[i][0] = i; // Transforming the first i characters of word1 to an empty string requires i deletions.
        }

        for (var j = 0; j <= m; j++)
        {
            dp[0][j] = j; // Transforming an empty string to the first j characters of word2 requires j insertions.
        }

        for (var i = 1; i <= n; i++)
        {
            for (var j = 1; j <= m; j++)
            {
                if (word1[i - 1] == word2[j - 1])
                {
                    dp[i][j] = dp[i - 1][j - 1];
                    continue;
                }

                // try insert
                var thisLetterIt = dp[i][j - 1];

                // try replace
                thisLetterIt = Math.Min(thisLetterIt, dp[i - 1][j - 1]);

                // try remove
                thisLetterIt = Math.Min(thisLetterIt, dp[i - 1][j]);

                dp[i][j] = thisLetterIt + 1;
            }
        }

        return dp[n][m];
    }
}
