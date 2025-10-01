namespace LeetCodeSolutions._3000._100._90;

/***
URL: https://leetcode.com/problems/find-the-minimum-Area-to-cover-all-ones-i
Number: 3195
Difficulty: Medium
 */
public class FindtheMinimumAreatoCoverAllOnesI
{
    public int MinimumArea(int[][] grid)
    {
        var minRow = grid.Length;

        var colLength = grid[0].Length;
        var minCol = colLength;
        var maxRow = 0;
        var maxCol = 0;

        for (var row = 0; row < grid.Length; row++)
        {
            for (var col = 0; col < colLength; col++)
            {
                if (grid[row][col] == 0)
                {
                    continue;
                }

                if (row < minRow)
                {
                    minRow = row;
                }
                else if (row > maxRow)
                {
                    maxRow = row;
                }

                if (col < minCol)
                {
                    minCol = col;
                }
                else if (col > maxCol)
                {
                    maxCol = col;
                }
            }
        }

        return (maxCol - minCol + 1) * (maxRow - minRow + 1);
    }
}
