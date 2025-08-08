using LeetCodeSolutions._0._400._10;

namespace LeetCodeSolutions.Tests._0._400._10;

public class PartitionEqualSubsetSumProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] param1, bool expectedResult)
    {
        var problem = new PartitionEqualSubsetSumProblem();

        var answer = problem.CanPartition(param1);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<int[], bool> TestData => new()
    {
        {
            [1,2,3],
            true
        },
        {
            [1,2,4,8],
            false
        },
        {
            [1,5,11,5],
            true
        },
        {
            [1,2,3,5],
            false
        }
    };
}
