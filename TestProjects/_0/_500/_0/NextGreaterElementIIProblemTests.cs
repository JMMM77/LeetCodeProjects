using LeetCodeSolutions._0._500._0;

namespace LeetCodeSolutions.Tests._0._500._0;

public class NextGreaterElementIIProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int[] expectedResult)
    {
        var problem = new NextGreaterElementIIProblem();

        var answer = problem.NextGreaterElements(nums);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<int[], int[]> TestData => new()
    {
        {
            [1,2,1],
            [2,-1,2]
        },
        {
            [1,2,3,4,3],
            [2,3,4,-1,4]
        }
    };
}
