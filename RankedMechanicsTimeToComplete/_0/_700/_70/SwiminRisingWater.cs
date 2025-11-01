namespace LeetCodeSolutions._0._700._70;

/***
URL: https://leetcode.com/problems/swim-in-rising-water
Number: 778
Difficulty: Hard
 */
public class SwiminRisingWater
{
    private static readonly int[][] Directions = [
        [1,0], // Up
        [-1,0], // Down
        [0,1], // Right
        [0,-1] // Left
    ];

    public int SwimInWater(int[][] grid)
    {
        var yLength = grid.Length;
        var xLength = grid[0].Length;
        var visited = new HashSet<(int, int)>();
        var queue = new PriorityQueue<(int, int), int>();
        var maxTime = 0;

        visited.Add((0, 0));
        queue.Enqueue((0, 0), grid[0][0]);

        while (queue.Count > 0)
        {
            var (y, x) = queue.Dequeue();
            var thisPriority = grid[y][x];

            if (thisPriority > maxTime)
            {
                maxTime = thisPriority;
            }

            if (y == yLength - 1 && x == xLength - 1)
            {
                return maxTime;
            }

            foreach (var direction in Directions)
            {
                var yNext = y + direction[0];
                var xNext = x + direction[1];

                // Is in bounds
                if (yNext < 0 || xNext < 0 || yNext >= yLength || xNext >= xLength)
                {
                    continue;
                }

                // Has not already been visited
                if (visited.Contains((yNext, xNext)))
                {
                    continue;
                }

                visited.Add((yNext, xNext));
                queue.Enqueue((yNext, xNext), grid[yNext][xNext]);
            }
        }

        return maxTime;
    }
}
