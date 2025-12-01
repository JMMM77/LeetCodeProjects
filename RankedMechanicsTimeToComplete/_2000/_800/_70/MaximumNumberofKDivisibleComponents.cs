namespace LeetCodeSolutions._2000._800._70;

/***
URL: https://leetcode.com/problems/maximum-number-of-k-divisible-components
Number: 2872
Difficulty: Hard
 */
public class MaximumNumberofKDivisibleComponents
{
    public int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k)
    {
        // Step 1: Build adjacency list
        var adjacencyList = new List<int>[n];
        for (var i = 0; i < n; i++)
        {
            adjacencyList[i] = [];
        }

        foreach (var edge in edges)
        {
            var nodeA = edge[0];
            var nodeB = edge[1];
            adjacencyList[nodeA].Add(nodeB);
            adjacencyList[nodeB].Add(nodeA);
        }

        // Step 2: Track total divisible component count
        var totalDivisibleComponentCount = 0;

        // Step 3: DFS starting at node 0
        this.DepthFirstSearch(
            currentNode: 0,
            parentNode: -1,
            adjacencyList,
            values,
            k,
            divisibleComponentCount: ref totalDivisibleComponentCount
        );

        return totalDivisibleComponentCount;
    }

    private int DepthFirstSearch(
        int currentNode,
        int parentNode,
        List<int>[] adjacencyList,
        int[] values,
        int k,
        ref int divisibleComponentCount)
    {
        // Step 1: Initialize subtree sum
        var subtreeSumModuloK = 0;

        // Step 2: Process all child nodes
        foreach (var neighborNode in adjacencyList[currentNode])
        {
            if (neighborNode != parentNode)
            {
                subtreeSumModuloK += this.DepthFirstSearch(
                    currentNode: neighborNode,
                    parentNode: currentNode,
                    adjacencyList: adjacencyList,
                    values: values,
                    k: k,
                    divisibleComponentCount: ref divisibleComponentCount
                );

                subtreeSumModuloK %= k;
            }
        }

        // Step 3: Add current node's value
        subtreeSumModuloK += values[currentNode];
        subtreeSumModuloK %= k;

        // Step 4: Check if this subtree sum is divisible by k
        if (subtreeSumModuloK == 0)
        {
            divisibleComponentCount++;
        }

        // Step 5: Return modulo sum for parent aggregation
        return subtreeSumModuloK;
    }
}
