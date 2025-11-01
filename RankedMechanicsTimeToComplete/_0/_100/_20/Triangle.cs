namespace LeetCodeSolutions._0._100._20;

/***
URL: https://leetcode.com/problems/triangle
Number: 120
Difficulty: Medium
 */
public class Triangle
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        var botLength = triangle[^1].ToArray();

        for (var i = triangle.Count - 2; i >= 0; i--)
        {
            var newList = new int[botLength.Length - 1];
            newList[0] = botLength[0] + triangle[i][0];

            for (var j = 1; j < botLength.Length - 1; j++)
            {
                newList[j - 1] = Math.Min(newList[j - 1], botLength[j] + triangle[i][j - 1]);
                newList[j] = (botLength[j] + triangle[i][j]);
            }

            newList[^1] = Math.Min(newList[^1], botLength[^1] + triangle[i][^1]);
            botLength = newList;
        }

        return botLength[0];
    }

    public int MinimumTotal1(IList<IList<int>> triangle)
    {
        if (triangle == null || triangle.Count == 0)
        {
            return 0;
        }

        var dp = triangle[triangle.Count - 1].ToArray();

        for (var row = triangle.Count - 2; row >= 0; row--)
        {
            for (var col = 0; col < triangle[row].Count; col++)
            {
                dp[col] = triangle[row][col] + Math.Min(dp[col], dp[col + 1]);
            }
        }

        return dp[0];
    }
}
