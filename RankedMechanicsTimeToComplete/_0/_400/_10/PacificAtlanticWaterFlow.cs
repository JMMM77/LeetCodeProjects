namespace LeetCodeSolutions._0._400._10;

/***
URL: https://leetcode.com/problems/pacific-atlantic-water-flow
Number: 417
Difficulty: Medium
 */
public class PacificAtlanticWaterFlow
{
    private static int[][] Heights = [];
    private static int YHeight = 0;
    private static int XHeight = 0;
    private static readonly int[][] Directions = [
        [1,0], // Up
        [-1,0], // Down
        [0,1], // Right
        [0,-1] // Left
    ];

    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        Heights = heights;
        YHeight = heights.Length;
        XHeight = heights[0].Length;

        var pacificFoundCords = new HashSet<(int, int)>();
        var atlanticFoundCords = new HashSet<(int, int)>();
        var pacificQueue = new Queue<(int, int)>();
        var atlanticQueue = new Queue<(int, int)>();

        // Left and right cordQueue
        for (var i = 0; i < YHeight; i++)
        {
            pacificFoundCords.Add((i, 0));
            pacificQueue.Enqueue((i, 0));
            atlanticFoundCords.Add((i, XHeight - 1));
            atlanticQueue.Enqueue((i, XHeight - 1));
        }

        // Top and Bot cordQueue
        for (var i = 0; i < XHeight; i++)
        {
            pacificFoundCords.Add((0, i));
            pacificQueue.Enqueue((0, i));
            atlanticFoundCords.Add((YHeight - 1, i));
            atlanticQueue.Enqueue((YHeight - 1, i));
        }

        Bfs(pacificQueue, pacificFoundCords);
        Bfs(atlanticQueue, atlanticFoundCords);

        pacificFoundCords.IntersectWith(atlanticFoundCords);

        var result = new List<IList<int>>();

        foreach (var i in pacificFoundCords)
        {
            result.Add([i.Item1, i.Item2]);
        }

        return result;
    }

    private static void Bfs(Queue<(int, int)> cordQueue, HashSet<(int, int)> foundCords)
    {
        while (cordQueue.Count != 0)
        {
            var (y, x) = cordQueue.Dequeue();

            foreach (var direction in Directions)
            {
                var yNext = y + direction[0];
                var xNext = x + direction[1];

                // Is in bounds
                if (yNext < 0 || xNext < 0 || yNext >= YHeight || xNext >= XHeight)
                {
                    continue;
                }

                // Has not already been visited
                if (foundCords.Contains((yNext, xNext)))
                {
                    continue;
                }

                // Make sure its bigger
                if (Heights[yNext][xNext] < Heights[y][x])
                {
                    continue;
                }

                foundCords.Add((yNext, xNext));
                cordQueue.Enqueue((yNext, xNext));
            }
        }
    }
}
