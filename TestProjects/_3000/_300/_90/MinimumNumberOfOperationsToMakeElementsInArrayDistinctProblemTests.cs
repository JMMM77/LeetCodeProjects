using LeetCodeSolutions._3000._300._90;

namespace LeetCodeSolutions.Tests._3000._300._90;

public class MinimumNumberOfOperationsToMakeElementsInArrayDistinctProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int expectedResult)
    {
        var problem = new MinimumNumberOfOperationsToMakeElementsInArrayDistinctProblem();

        var answer = problem.MinimumOperations(nums);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<int[], int> TestData => new()
{
    {
        [1,2,3,4,2,3,3,5,7],
        2
    },
    {
        [4,5,6,4,4],
        2
    },
    {
        [6,7,8,9],
        0
    }
};
}
