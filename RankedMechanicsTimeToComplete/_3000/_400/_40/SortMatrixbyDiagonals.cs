namespace LeetCodeSolutions.Tests._3000._400._40;

/***
URL: https://leetcode.com/problems/sort-matrix-by-diagonals
Number: 3446
Difficulty: Medium
 */
public class SortMatrixbyDiagonals
{
    public int[][] SortMatrix(int[][] grid)
    {
        var numOfMoves = grid.Length + grid.Length - 1;
        var halfWay = numOfMoves / 2;
        var currentRow = grid.Length - 1;
        var currentCol = 0;
        var moveUp = true;

        for (var i = 0; i < numOfMoves; i++)
        {
            var diagVals = new List<int>()
            {
                grid[currentRow][currentCol]
            };

            // Get all top left side
            var startRow = currentRow;
            var startCol = currentCol;

            while (startRow > 0 && startCol > 0)
            {
                startRow--;
                startCol--;
                diagVals.Add(grid[startRow][startCol]);
            }

            // Get all bot right side
            var tempRow = currentRow;
            var tempCol = currentCol;

            while (tempRow < grid.Length - 1 && tempCol < grid.Length - 1)
            {
                tempRow++;
                tempCol++;
                diagVals.Add(grid[tempRow][tempCol]);
            }

            diagVals.Sort();

            if (i > halfWay)
            {
                for (var index = 0; index < diagVals.Count; index++)
                {
                    grid[startRow][startCol] = diagVals[index];
                    startRow++;
                    startCol++;
                }
            }
            else
            {
                for (var index = diagVals.Count - 1; index >= 0; index--)
                {
                    grid[startRow][startCol] = diagVals[index];
                    startRow++;
                    startCol++;
                }
            }

            if (moveUp)
            {
                currentRow--;
                moveUp = !moveUp;
                continue;
            }

            // Move right
            currentCol++;
            moveUp = !moveUp;
        }

        return grid;
    }
}