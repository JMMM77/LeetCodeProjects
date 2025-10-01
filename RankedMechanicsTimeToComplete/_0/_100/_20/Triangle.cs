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
