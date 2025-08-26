namespace LeetCodeSolutions._1000._200._70;

/***
URL: https://leetcode.com/problems/count-square-submatrices-with-all-ones
Number: 1277
Difficulty: Medium
 */
public class CountSquareSubmatriceswithAllOnes
{
    public int CountSquares(int[][] matrix)
    {
        var columnLength = matrix[0].Length;

        for (var row = 1; row < matrix.Length; row++)
        {
            for (var col = 1; col < columnLength; col++)
            {
                if (matrix[row][col] == 0)
                {
                    continue;
                }

                matrix[row][col] = 1 +
                    Math.Min(
                        Math.Min(matrix[row - 1][col], matrix[row][col - 1]),
                        matrix[row - 1][col - 1]
                    ); // If the top, left, and top-left are the same then the square is bigger else its just the same size as the smallest one
            }
        }

        return matrix.Sum(x => x.Sum());
    }
}
