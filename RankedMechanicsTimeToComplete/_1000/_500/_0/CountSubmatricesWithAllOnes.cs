namespace LeetCodeSolutions._1000._500._0;

/***
URL: https://leetcode.com/problems/count-submatrices-with-all-ones
Number: 1504
Difficulty: Medium
 */
public class CountSubmatricesWithAllOnes
{
    public int NumSubmat(int[][] mat)
    {
        var columnLength = mat[0].Length;

        // Set Heights
        for (var row = 1; row < mat.Length; row++)
        {
            for (var col = 0; col < columnLength; col++)
            {
                if (mat[row][col] == 0)
                {
                    continue;
                }

                mat[row][col] += mat[row - 1][col];
            }
        }

        var count = 0;

        for (var row = 0; row < mat.Length; row++)
        {
            for (var col = 0; col < columnLength; col++)
            {
                var minHeight = int.MaxValue;

                for (var backCol = col; backCol >= 0; backCol--)
                {
                    if (mat[row][backCol] == 0)
                    {
                        break;
                    }

                    minHeight = Math.Min(minHeight, mat[row][backCol]);
                    count += minHeight;
                }
            }
        }

        return count;
    }
}
