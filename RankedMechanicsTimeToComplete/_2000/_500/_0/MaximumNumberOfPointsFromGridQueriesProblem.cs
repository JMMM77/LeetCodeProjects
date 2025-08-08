namespace LeetCodeSolutions._0._500._0;

/***
URL: https://leetcode.com/problems/maximum-number-of-points-from-grid-queries
Number: 2503
Difficulty: Hard
*/
public class MaximumNumberOfPointsFromGridQueriesProblem
{
    public int[] MaxPoints(int[][] grid, int[] queries)
    {
        // Start from the beginning
        // Look up, right, down, left if its smaller than the query navigate to it
        // If its been visited before then don't bother going to it and increase the answer by one;
        var answer = new int[queries.Length];
        var rowCount = grid.Length;
        var colCount = grid[0].Length;

        var orderedQueries = new SortedSet<(int, int)>(); // value, index

        for (var i = 0; i < queries.Length; i++)
        {
            orderedQueries.Add((queries[i], i));
        }

        var gridElementsToAddNavigate = new PriorityQueue<(int value, int row, int col), int>();
        gridElementsToAddNavigate.Enqueue((grid[0][0], 0, 0), grid[0][0]); // Keep track of cells to process

        var visitedElements = new HashSet<(int, int)>(); // Keep track of visited cords

        var (value, yCord, xCord) = gridElementsToAddNavigate.Peek();
        var prevQuery = -1;
        var prevIndex = -1;

        // Need to verify for each query
        foreach (var (currentQuery, index) in orderedQueries)
        {
            if (grid[0][0] >= currentQuery)
            {
                answer[index] = 0;
                continue;
            }
            else if (prevQuery == currentQuery)
            {
                answer[index] = answer[prevIndex];
                continue;
            }

            while (gridElementsToAddNavigate.Count > 0 && value < currentQuery)
            {
                gridElementsToAddNavigate.Dequeue();
                visitedElements.Add((yCord, xCord));

                // Look up
                var aboveCord = yCord - 1;

                if (aboveCord > -1 && !visitedElements.Contains((aboveCord, xCord)))
                {
                    gridElementsToAddNavigate.Enqueue((grid[aboveCord][xCord], aboveCord, xCord), grid[aboveCord][xCord]);
                }

                // Look right
                var rightCord = xCord + 1;

                if (rightCord < colCount && !visitedElements.Contains((yCord, rightCord)))
                {
                    gridElementsToAddNavigate.Enqueue((grid[yCord][rightCord], yCord, rightCord), grid[yCord][rightCord]);
                }

                // Look down
                var downCord = yCord + 1;

                if (downCord < rowCount && !visitedElements.Contains((downCord, xCord)))
                {
                    gridElementsToAddNavigate.Enqueue((grid[downCord][xCord], downCord, xCord), grid[downCord][xCord]);
                }

                // Look right
                var leftCord = xCord - 1;

                if (leftCord > -1 && !visitedElements.Contains((yCord, leftCord)))
                {
                    gridElementsToAddNavigate.Enqueue((grid[yCord][leftCord], yCord, leftCord), grid[yCord][leftCord]);
                }

                if (gridElementsToAddNavigate.Count > 0)
                {
                    (value, yCord, xCord) = gridElementsToAddNavigate.Peek();
                }
            }

            prevQuery = currentQuery;
            prevIndex = index;

            answer[index] = visitedElements.Count;
        }

        return answer;
    }
}
