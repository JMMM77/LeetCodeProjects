namespace LeetCodeSolutions._3000._0._0;

/***
URL: https://leetcode.com/problems/maximum-area-of-longest-diagonal-rectangle
Number: 3000
Difficulty: Easy
 */
public class MaximumAreaofLongestDiagonalRectangle
{
    public int AreaOfMaxDiagonal(int[][] dimensions)
    {
        var maxDiag = 0;
        var returnArea = 0;

        foreach (var dim in dimensions)
        {
            var tempDiag = (dim[0] * dim[0]) + (dim[1] * dim[1]);

            if (tempDiag < maxDiag)
            {
                continue;
            }

            var tempArea = dim[0] * dim[1];

            if (tempDiag > maxDiag)
            {
                maxDiag = tempDiag;
                returnArea = tempArea;
            }

            if (tempDiag == maxDiag && tempArea > returnArea)
            {
                returnArea = tempArea;
            }
        }

        return returnArea;
    }
}
