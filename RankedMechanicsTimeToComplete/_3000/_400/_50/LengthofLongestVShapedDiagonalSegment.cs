namespace LeetCodeSolutions._3000._400._50;

/***
URL: https://leetcode.com/problems/col-of-longest-v-shaped-diagonal-segment
Number: 3459
Difficulty: Hard
 */
public class LengthofLongestVShapedDiagonalSegment
{
    // Note: Read question carefully, turn can ONLY occur clockwise
    private const int TopLeft = 0;
    private const int TopRight = 1;
    private const int BotRight = 2;
    private const int BotLeft = 3;

    private static readonly (int Row, int Col)[] Directions =
    {
        (-1, -1), // TopLeft
        (-1,  1), // TopRight
        ( 1,  1), // BotRight
        ( 1, -1)  // BotLeft
    };

    public int LenOfVDiagonal(int[][] grid)
    {
        var longestSeq = 0;
        var hasOne = false;

        for (var row = 0; row < grid.Length; row++)
        {
            for (var col = 0; col < grid[0].Length; col++)
            {
                if (grid[row][col] != 1)
                {
                    continue;
                }

                hasOne = true;
                var nextDig = 2;

                for (var dir = 0; dir < Directions.Length; dir++)
                {
                    var (dr, dc) = Directions[dir];
                    var nextRow = row + dr;
                    var nextCol = col + dc;

                    if (isInBounds(nextRow, nextCol, grid) && grid[nextRow][nextCol] == nextDig)
                    {
                        var tempVal = GetLongestSequence(nextDig, nextRow, nextCol, dir, false, 1, grid);

                        if (tempVal > longestSeq)
                        {
                            longestSeq = tempVal;
                        }
                    }
                }
            }
        }

        return longestSeq > 0 ? longestSeq : (hasOne ? 1 : 0);
    }

    private int GetLongestSequence(int currentDig, int row, int col, int direction, bool turned, int depth, int[][] grid)
    {
        var biggestDepth = depth + 1; // count current cell
        var nextDig = currentDig == 2 ? 0 : 2;
        var (dr, dc) = Directions[direction];
        var nextRow = row + dr;
        var nextCol = col + dc;
        int tempVal;

        if (isInBounds(nextRow, nextCol, grid) && grid[nextRow][nextCol] == nextDig)
        {
            tempVal = GetLongestSequence(nextDig, nextRow, nextCol, direction, turned, depth + 1, grid);

            if (tempVal > biggestDepth)
            {
                biggestDepth = tempVal;
            }
        }

        if (turned)
        {
            return biggestDepth;
        }

        if (direction == BotLeft)
        {
            biggestDepth = TryTurn(nextDig, row, col, TopLeft, biggestDepth, depth, grid);
        }
        else
        {
            biggestDepth = TryTurn(nextDig, row, col, direction + 1, biggestDepth, depth, grid);
        }

        return biggestDepth;
    }

    private int TryTurn(int nextDig, int row, int col, int newDirection, int biggestDepth, int depth, int[][] grid)
    {
        var (dr, dc) = Directions[newDirection];
        var nextRow = row + dr;
        var nextCol = col + dc;

        if (isInBounds(nextRow, nextCol, grid) && grid[nextRow][nextCol] == nextDig)
        {
            var tempVal = GetLongestSequence(nextDig, nextRow, nextCol, newDirection, true, depth + 1, grid);

            if (tempVal > biggestDepth)
            {
                biggestDepth = tempVal;
            }
        }

        return biggestDepth;
    }

    private bool isInBounds(int row, int col, int[][] grid)
        => row >= 0 && row < grid.Length && col >= 0 && col < grid[0].Length;
}
