using LeetCodeSolutions._0._300._60;

namespace LeetCodeSolutions.Tests._0._300._60;

public class LargestDivisibleSubsetProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] param1, IList<int> expectedResult)
    {
        var problem = new LargestDivisibleSubsetProblem();

        var answer = problem.LargestDivisibleSubset(param1);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<int[], int[]> TestData => new()
    {
        {
            [1,2,3],
            [3, 1]
        },
        {
            [1,2,4,8],
            [8,4,2,1]
        }
    };
}
