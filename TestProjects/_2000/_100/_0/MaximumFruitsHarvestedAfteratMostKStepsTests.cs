using LeetCodeSolutions._2000._100._0;

namespace LeetCodeSolutions.Tests._2000._100._0;

public class MaximumFruitsHarvestedAfteratMostKStepsTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] fruits, int startPos, int k, int expectedResult)
    {
        var problem = new MaximumFruitsHarvestedAfteratMostKSteps();

        var answer = problem.MaxTotalFruits(fruits, startPos, k);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<int[][], int, int, int> TestData => new()
    {
        {
            [[2,8],[6,3],[8,6]],
            5,
            4,
            9
        },
        {
            [[0,9],[4,1],[5,7],[6,2],[7,4],[10,9]],
            5,
            4,
            14
        },
        {
            [[0,3],[6,4],[8,5]],
            3,
            2,
            0
        },
        {
            [[200000,10000]],
            200000,
            200000,
            10000
        },
        {
            [[0,10000]],
            200000,
            200000,
            10000
        }
    };
}
