namespace LeetCodeSolutions._3000._100._90;

/***
URL: https://leetcode.com/problems/find-the-minimum-area-to-cover-all-ones-ii
Number: 3197
Difficulty: Hard
*/
public class FindtheMinimumAreatoCoverAllOnesII
{
    public int MinimumSum(int[][] grid)
    {
        var rotatedGrid = Rotate(grid);

        return Math.Min(GetMinimumSum(grid), GetMinimumSum(rotatedGrid));
    }

    private int[][] Rotate(int[][] grid)
    {
        var rowLength = grid.Length;
        var colLength = grid[0].Length;
        var rotated = new int[colLength][];

        for (var col = 0; col < colLength; col++)
        {
            rotated[col] = new int[rowLength];
        }

        for (var row = 0; row < rowLength; row++)
        {
            for (var col = 0; col < colLength; col++)
            {
                rotated[colLength - col - 1][row] = grid[row][col];
            }
        }

        return rotated;
    }

    private int GetMinimumSum(int[][] grid)
    {
        var rowLength = grid.Length;
        var colLength = grid[0].Length;
        var min = rowLength * colLength;

        // L shape partitions
        for (var row = 0; row + 1 < rowLength; row++)
        {
            for (var col = 0; col + 1 < colLength; col++)
            {
                min = Math.Min(min,
                    MinimumArea(0, row, 0, colLength - 1, grid) +
                    MinimumArea(row + 1, rowLength - 1, 0, col, grid) +
                    MinimumArea(row + 1, rowLength - 1, col + 1, colLength - 1, grid));

                min = Math.Min(min,
                    MinimumArea(0, row, 0, col, grid) +
                    MinimumArea(0, row, col + 1, colLength - 1, grid) +
                    MinimumArea(row + 1, rowLength - 1, 0, colLength - 1, grid));
            }
        }

        // 3 horizontal strips
        for (var row1 = 0; row1 + 2 < rowLength; row1++)
        {
            for (var row2 = row1 + 1; row2 + 1 < rowLength; row2++)
            {
                min = Math.Min(min,
                    MinimumArea(0, row1, 0, colLength - 1, grid) +
                    MinimumArea(row1 + 1, row2, 0, colLength - 1, grid) +
                    MinimumArea(row2 + 1, rowLength - 1, 0, colLength - 1, grid));
            }
        }

        return min;
    }
    private int MinimumArea(int rowStart, int rowEnd, int colStart, int colEnd, int[][] grid)
    {
        var minRow = grid.Length;
        var maxRow = 0;
        var minCol = grid[0].Length;
        var maxCol = 0;

        for (var row = rowStart; row <= rowEnd; row++)
        {
            for (var col = colStart; col <= colEnd; col++)
            {
                if (grid[row][col] == 1)
                {
                    if (row < minRow) { minRow = row; }
                    if (row > maxRow) { maxRow = row; }
                    if (col < minCol) { minCol = col; }
                    if (col > maxCol) { maxCol = col; }
                }
            }
        }

        if (minRow > maxRow)
        {
            return int.MaxValue / 3; // no 1s in region
        }

        return (maxRow - minRow + 1) * (maxCol - minCol + 1);
    }
}
