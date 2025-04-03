using LeetCodeSolutions._2000._700._80;

namespace TestProjects._2000._700._80;

public class MinimumIndexOfAValidSplitProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(IList<int> nums, int expectedResult)
    {
        var problem = new MinimumIndexOfAValidSplitProblem();

        var answer = problem.MinimumIndex(nums);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<int[], int> TestData => new()
    {
        {
            [1,2,2,2],
            2
        },
        {
            [2,1,3,1,1,1,7,1,2,1],
            4
        },
        {
            [3,3,3,3,7,2,2],
            -1
        }
    };
}
