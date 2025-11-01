namespace LeetCodeSolutions._0._900._30;

/***
URL: https://leetcode.com/problems/minimum-falling-path-sum
Number: 931
Difficulty: Medium
 */
public class MinimumFallingPathSum
{
    public int MinFallingPathSum(int[][] matrix)
    {
        var yLength = matrix[0].Length;
        var prevArray = matrix[^1];

        for (var i = matrix.Length - 2; i >= 0; i--)
        {
            var thisRow = matrix[i];
            var newArray = new int[yLength];
            newArray[0] = thisRow[0] + prevArray[0];
            newArray[1] = thisRow[1] + prevArray[0];

            for (var j = 1; j < yLength; j++)
            {
                if (j - 1 >= 0)
                {
                    newArray[j - 1] = Math.Min(newArray[j - 1], thisRow[j - 1] + prevArray[j]);
                }

                newArray[j] = Math.Min(newArray[j], thisRow[j] + prevArray[j]);

                if (j + 1 < yLength)
                {
                    newArray[j + 1] = thisRow[j + 1] + prevArray[j];
                }
            }

            prevArray = newArray;
        }

        return prevArray.Min();
    }
}
