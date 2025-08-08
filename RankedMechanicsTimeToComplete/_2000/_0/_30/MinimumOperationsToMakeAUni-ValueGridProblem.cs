namespace LeetCodeSolutions._0._0._30;
/***
URL: https://leetcode.com/problems/minimum-operations-to-make-a-uni-value-grid/
Number: 2033
Difficulty: Medium
 */
public class MinimumOperationsToMakeAUni_ValueGridProblem
{
    public int MinOperations(int[][] grid, int x)
    {
        var flatGrid = new List<int>();
        var targetModulus = grid[0][0] % x; // All elements can be equal if they all have the same modulus

        foreach (var row in grid)
        {
            foreach (var element in row)
            {
                if (element % x != targetModulus)
                {
                    return -1;
                }

                flatGrid.Add(element);
            }
        }

        // To get the minimum number of operations possible requires the median
        // This converges all elements to the middle rather than being affected by potential outliers
        var median = flatGrid.Order().ToList()[flatGrid.Count / 2];
        var numOfOperations = 0;

        foreach (var element in flatGrid)
        {
            var difference = median - element;

            numOfOperations += (difference < 0 ? -1 * difference : difference) / x; // The amount of operations it takes to meet the difference 
        }

        return numOfOperations;
    }
}
