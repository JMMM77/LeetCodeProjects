namespace LeetCodeSolutions._0._0._60;

/***
URL: https://leetcode.com/problems/minimum-path-sum
Number: 64
Difficulty: Medium
 */
public class MinimumPathSum
{
    public int MinPathSum(int[][] grid)
    {
        var xLength = grid.Length;
        var yLength = grid[0].Length;
        var visited = new Dictionary<(int x, int y), int>();
        var priorityQueue = new PriorityQueue<(int x, int y), int>();
        visited.Add((0, 0), grid[0][0]);

        if (xLength > 1)
        {
            priorityQueue.Enqueue((1, 0), grid[1][0] + grid[0][0]);
        }

        if (yLength > 1)
        {
            priorityQueue.Enqueue((0, 1), grid[0][1] + grid[0][0]);
        }

        while (priorityQueue.Count > 0)
        {
            var (x, y) = priorityQueue.Dequeue();

            if (visited.ContainsKey((x, y)))
            {
                continue;
            }

            var leftVal = visited.TryGetValue((x - 1, y), out var potLeftVal) ? potLeftVal : int.MaxValue;
            var topVal = visited.TryGetValue((x, y - 1), out var potRightVal) ? potRightVal : int.MaxValue;
            var valToAdd = grid[x][y] + Math.Min(leftVal, topVal);

            visited.Add((x, y), valToAdd);

            if (x == xLength - 1 && y == yLength - 1)
            {
                return valToAdd;
            }

            if (x + 1 < xLength)
            {
                var xValToAdd = valToAdd + grid[x + 1][y];

                if (visited.TryGetValue((x + 1, y), out var foundXValue))
                {
                    if (foundXValue > xValToAdd)
                    {
                        visited[(x + 1, y)] = xValToAdd;
                    }
                }
                else
                {
                    priorityQueue.Enqueue((x + 1, y), xValToAdd);
                }
            }

            if (y + 1 < yLength)
            {
                var yValToAdd = valToAdd + grid[x][y + 1];

                if (visited.TryGetValue((x, y + 1), out var foundYValue))
                {
                    if (foundYValue > yValToAdd)
                    {
                        visited[(x, y + 1)] = yValToAdd;
                    }
                }
                else
                {
                    priorityQueue.Enqueue((x, y + 1), yValToAdd);
                }
            }
        }

        return grid[0][0];
    }
}
