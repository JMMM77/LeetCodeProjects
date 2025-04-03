using LeetCodeSolutions._2000._500._0;

namespace TestProjects._2000._500._0;

public class MaximumNumberOfPointsFromGridQueriesProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] grid, int[] queries, int[] expectedResult)
    {
        var problem = new MaximumNumberOfPointsFromGridQueriesProblem();

        var answer = problem.MaxPoints(grid, queries);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<int[][], int[], int[]> TestData => new()
    {
        {
            [[1,2,3],[2,5,7],[3,5,1]],
            [5,6,2],
            [5,8,1]
        },
        {
            [[5,2,1],[1,1,2]],
            [3],
            [0]
        }
    };
}
