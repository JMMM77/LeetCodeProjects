namespace LeetCodeSolutions._0._0._40;

/***
URL: https://leetcode.com/problems/trapping-rain-water
Number: 42
Difficulty: Hard
 */
public class TrappingRainWater
{
    public int Trap(int[] height)
    {
        if (height.Length < 3)
        {
            return 0;
        }

        var n = height.Length;
        var visited = new bool[n];

        visited[0] = true;
        visited[n - 1] = true;

        var queue = new PriorityQueue<(int index, int thisHeight), int>();

        // Push boundary bars into the priority queue
        queue.Enqueue((0, height[0]), height[0]);
        queue.Enqueue((n - 1, height[n - 1]), height[n - 1]);

        var trapped = 0;
        var waterLevel = 0;

        // BFS expansion from boundaries inward
        while (queue.Count > 0)
        {
            var (index, thisHeight) = queue.Dequeue();

            waterLevel = Math.Max(waterLevel, thisHeight);

            // Check neighbors
            foreach (var nei in new int[] { index - 1, index + 1 })
            {
                if (nei >= 0 && nei < n && !visited[nei])
                {
                    visited[nei] = true;

                    if (height[nei] < waterLevel)
                    {
                        trapped += waterLevel - height[nei];
                    }

                    queue.Enqueue((nei, height[nei]), height[nei]);
                }
            }
        }

        return trapped;
    }
}
