namespace LeetCodeSolutions._2000._200._50;

/***
URL: https://leetcode.com/problems/count-unguarded-cells-in-the-grid
Number: 2257
Difficulty: Medium
*/
public class CountUnguardedCellsintheGrid
{
    public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
    {
        var unguardedCells = new int[m][];

        for (var i = 0; i < m; i++)
        {
            var newRow = new int[n];

            for (var j = 0; j < n; j++)
            {
                newRow[j] = 0;
            }

            unguardedCells[i] = newRow;
        }

        foreach (var guard in guards)
        {
            unguardedCells[guard[0]][guard[1]] = 2;
        }

        foreach (var wall in walls)
        {
            unguardedCells[wall[0]][wall[1]] = 2;
        }

        foreach (var guard in guards)
        {
            var row = guard[0];
            var col = guard[1];

            unguardedCells[row][col] = 2;

            // guard north
            for (var i = row - 1; i >= 0; i--)
            {
                if (unguardedCells[i][col] == 2)
                {
                    break;
                }

                unguardedCells[i][col] = 1;
            }

            // guard east
            for (var j = col - 1; j >= 0; j--)
            {
                if (unguardedCells[row][j] == 2)
                {
                    break;
                }

                unguardedCells[row][j] = 1;
            }

            // guard south
            for (var i = row + 1; i < m; i++)
            {
                if (unguardedCells[i][col] == 2)
                {
                    break;
                }

                unguardedCells[i][col] = 1;
            }

            // guard west
            for (var j = col + 1; j < n; j++)
            {
                if (unguardedCells[row][j] == 2)
                {
                    break;
                }

                unguardedCells[row][j] = 1;
            }
        }

        var ungaurded = 0;

        foreach (var row in unguardedCells)
        {
            foreach (var val in row)
            {
                if (val == 0)
                {
                    ungaurded++;
                }
            }
        }

        return ungaurded;
    }
}
