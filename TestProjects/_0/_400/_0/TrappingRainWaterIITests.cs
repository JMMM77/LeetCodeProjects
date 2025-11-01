using LeetCodeSolutions._0._400._0;

namespace LeetCodeSolutions.Tests._0._400._0;

public class TrappingRainWaterIITests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] param1, int expectedResult)
    {
        var problem = new TrappingRainWaterII();

        var answer = problem.TrapRainWater(param1);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<int[][], int> TestData => new()
    {
        {
            [[1,4,3,1,3,2],[3,2,1,3,2,4],[2,3,3,2,3,1]],
            4
        },
        {
            [[3,3,3,3,3],[3,2,2,2,3],[3,2,1,2,3],[3,2,2,2,3],[3,3,3,3,3]],
            10
        }
    };
}
