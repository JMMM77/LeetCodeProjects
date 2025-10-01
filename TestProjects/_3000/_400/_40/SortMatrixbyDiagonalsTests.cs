namespace LeetCodeSolutions.Tests._3000._400._40;

public class SortMatrixbyDiagonalsTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] grid, int[][] expectedResult)
    {
        var problem = new SortMatrixbyDiagonals();

        var answer = problem.SortMatrix(grid);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<int[][], int[][]> TestData => new()
    {
        {
            [[1,7,3],[9,8,2],[4,5,6]],
            [[8,2,3],[9,6,7],[4,5,1]]
        }
    };
}
