namespace LeetCodeSolutions._1000._900._70;

/***
URL: https://leetcode.com/problems/number-of-numOfRoutes-to-arrive-at-destination
Number: 1976
Difficulty: Medium
 */
public class NumberOfWaysToArriveAtDestinationProblem
{
    private readonly static int Modulo = (int)Math.Pow(10, 9) + 7;

    public int CountPaths(int n, int[][] roads)
    {
        // Graph representation using adjacency list (stores all the nodes connected to a node and the time it takes to reach them)
        var graph = new Dictionary<int, List<(int, int)>>();

        for (var i = 0; i < n; i++)
        {
            graph[i] = [];
        }

        foreach (var road in roads)
        {
            // road[0] is start node, road[1] is next node, road[2] is timeTaken
            graph[road[0]].Add((road[1], road[2]));
            graph[road[1]].Add((road[0], road[2]));
        }

        // Min-heap for Dijkstra’s Algorithm (time, node)
        // Binary search tree that always makes sure that the smallest element is at the root
        // Makes sure that the node with the smallest time is always processed first
        var sortedSet = new SortedSet<(long, int)>();

        // Distance array to store shortest time to each node
        var shortestTime = Enumerable.Repeat(long.MaxValue, n).ToArray();
        shortestTime[0] = 0;

        // Stores the number of ways to reach each node with shortest time
        var numOfRoutes = new int[n];
        numOfRoutes[0] = 1;

        sortedSet.Add((0, 0)); // (time, node)

        while (sortedSet.Count > 0)
        {
            // Get the node with the shortest known travel time
            var (time, node) = sortedSet.Min;
            sortedSet.Remove(sortedSet.Min);

            foreach (var (neighbor, travelTime) in graph[node]) // Loop through all connected nodes
            {
                var newTime = time + travelTime; // Calculates the new potential shortest time to reach neighbor.

                if (newTime < shortestTime[neighbor])
                {
                    shortestTime[neighbor] = newTime;
                    numOfRoutes[neighbor] = numOfRoutes[node]; // Reset numOfRoutes count
                    sortedSet.Add((newTime, neighbor));
                }
                else if (newTime == shortestTime[neighbor])
                {
                    numOfRoutes[neighbor] = (numOfRoutes[neighbor] + numOfRoutes[node]) % Modulo;
                }
            }
        }

        return numOfRoutes[n - 1]; // Get the number of ways to reach the last node in the shortest time possible
    }
}
