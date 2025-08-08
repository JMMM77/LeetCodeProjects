using LeetCodeSolutions._0._700._90;

namespace LeetCodeSolutions.Tests._2000._700._90;

public class CountCompleteSubarraysInAnArrayProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int expectedResult)
    {
        var problem = new CountCompleteSubarraysInAnArrayProblem();

        var answer = problem.CountCompleteSubarrays(nums);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<int[], int> TestData => new()
    {
        {
            [1,1],
            3
        },
        {
            [1,1,1],
            6
        },
        {
            [1,3,1,2,2],
            4
        },
        {
            [5,5,5,5],
            10
        }
    };
}
