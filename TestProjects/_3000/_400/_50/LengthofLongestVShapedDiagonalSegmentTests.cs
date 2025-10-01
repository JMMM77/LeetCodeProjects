using LeetCodeSolutions._3000._400._50;

namespace LeetCodeSolutions.Tests._3000._400._50;

public class LengthofLongestVShapedDiagonalSegmentTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] grid, int expectedResult)
    {
        var problem = new LengthofLongestVShapedDiagonalSegment();

        var answer = problem.LenOfVDiagonal(grid);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<int[][], int> TestData => new()
    {
        {
            [[2,2,1,2,2],[2,0,2,2,0],[2,0,1,1,0],[1,0,2,2,2],[2,0,0,2,2]],
            5
        },
        {
            [[2,2,2,2,2],[2,0,2,2,0],[2,0,1,1,0],[1,0,2,2,2],[2,0,0,2,2]],
            4
        },
        {
            [[1,2,2,2,2],[2,2,2,2,0],[2,0,0,0,0],[0,0,2,2,2],[2,0,0,2,0]],
            5
        },
        {
            [[1]],
            1
        },
        {
            [[1,1,1,2,0,0],
             [0,0,0,0,1,2]],
            2
        }
    };
}
