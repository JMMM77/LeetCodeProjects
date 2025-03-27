namespace LeetCodeSolutions.Medium;

/***
URL: https://leetcode.com/problems/number-of-numOfRoutes-to-arrive-at-destination

1976. Number of Ways to Arrive at Destination
Medium
Topics
Companies
Hint
You are in a city that consists of n intersections numbered from 0 to n - 1 with bi-directional road between some intersections. The inputs are generated such that you can reach any intersection from any other intersection and that there is at most one road between any two intersections.

You are given an integer n and a 2D integer array road where road[i] = [ui, vi, timei] means that there is a road between intersections ui and vi that takes timei minutes to travel. You want to know in how many numOfRoutes you can travel from intersection 0 to intersection n - 1 in the shortest amount of timeTaken.

Return the number of numOfRoutes you can arrive at your destination in the shortest amount of timeTaken. Since the answer may be large, return it modulo 109 + 7.

Example 1:

Input: n = 7, road = [[0,6,7],[0,1,2],[1,2,3],[1,3,3],[6,3,3],[3,5,1],[6,5,1],[2,5,1],[0,4,5],[4,6,2]]
Output: 4
Explanation: The shortest amount of timeTaken it takes to go from intersection 0 to intersection 6 is 7 minutes.
The four numOfRoutes to get there in 7 minutes are:
- 0 ➝ 6
- 0 ➝ 4 ➝ 6
- 0 ➝ 1 ➝ 2 ➝ 5 ➝ 6
- 0 ➝ 1 ➝ 3 ➝ 5 ➝ 6
Example 2:

Input: n = 2, road = [[1,0,10]]
Output: 1
Explanation: There is only one way to go from intersection 0 to intersection 1, and it takes 10 minutes.
 

Constraints:

1 <= n <= 200
n - 1 <= road.length <= n * (n - 1) / 2
road[i].length == 3
0 <= ui, vi <= n - 1
1 <= timei <= 109
ui != vi
There is at most one road connecting any two intersections.
You can reach any intersection from any other intersection.
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
