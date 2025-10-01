namespace LeetCodeSolutions._1000._0._30;

/***
URL: https://leetcode.com/problems/minimum-score-triangulation-of-polygon 
Number: 1039
Difficulty: Medium
 */
public class MinimumScoreTriangulationofPolygon
{
    private int Length;
    private int[]? Values;
    private readonly Dictionary<int, int> Cache = [];

    public int MinScoreTriangulation(int[] values)
    {
        Length = values.Length;
        Values = values;

        return Dp(0, Length - 1);
    }

    private int Dp(int i, int j)
    {
        // Too small to be valid
        if (i + 2 > j)
        {
            return 0;
        }

        // Last triangle
        if (i + 2 == j)
        {
            return Values![i] * Values[i + 1] * Values[j];
        }

        var key = i * Length + j;

        if (!Cache.TryGetValue(key, out var value))
        {
            var minScore = int.MaxValue;

            for (var k = i + 1; k < j; k++)
            {
                minScore = Math.Min(minScore,
                    Values![i] * Values[k] * Values[j]
                    + Dp(i, k)
                    + Dp(k, j));
            }

            Cache.Add(key, minScore);

            value = minScore;
        }

        return value;
    }
}
