namespace LeetCodeSolutions._0._400._0;

/***
URL: https://leetcode.com/problems/trapping-rain-water-ii
Number: 407
Difficulty: Hard
 */
public class TrappingRainWaterII
{
    public int TrapRainWater(int[][] heightMap)
    {
        var xLength = heightMap.Length;
        var yLength = heightMap[0].Length;

        var visited = new bool[xLength, yLength];
        var queue = new PriorityQueue<(int r, int c, int h), int>();

        // Push all boundary cells into the min-heap
        for (var x = 0; x < xLength; x++)
        {
            queue.Enqueue((x, 0, heightMap[x][0]), heightMap[x][0]);
            queue.Enqueue((x, yLength - 1, heightMap[x][yLength - 1]), heightMap[x][yLength - 1]);

            visited[x, 0] = true;
            visited[x, yLength - 1] = true;
        }
        for (var y = 1; y < yLength - 1; y++)
        {
            queue.Enqueue((0, y, heightMap[0][y]), heightMap[0][y]);
            queue.Enqueue((xLength - 1, y, heightMap[xLength - 1][y]), heightMap[xLength - 1][y]);

            visited[0, y] = true;
            visited[xLength - 1, y] = true;
        }

        var trapped = 0;
        var waterLevel = 0;
        var dirs = new int[][]
        {
            [1, 0], [-1, 0],
            [0, 1], [0, -1]
        };

        // BFS from boundaries inward
        while (queue.Count > 0)
        {
            var (x, y, height) = queue.Dequeue();

            waterLevel = Math.Max(waterLevel, height);

            foreach (var d in dirs)
            {
                var nextX = x + d[0];
                var nextY = y + d[1];

                if (nextX >= 0
                    && nextX < xLength
                    && nextY >= 0
                    && nextY < yLength
                    && !visited[nextX, nextY])
                {
                    visited[nextX, nextY] = true;

                    if (heightMap[nextX][nextY] < waterLevel)
                    {
                        trapped += waterLevel - heightMap[nextX][nextY];
                    }

                    queue.Enqueue((nextX, nextY, heightMap[nextX][nextY]), heightMap[nextX][nextY]);
                }
            }
        }

        return trapped;
    }
}
