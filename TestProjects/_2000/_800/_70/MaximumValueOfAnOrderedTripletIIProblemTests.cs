using LeetCodeSolutions._2000._800._70;

namespace TestProjects._2000._800._70;

public class MaximumValueOfAnOrderedTripletIIProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, long expectedResult)
    {
        var problem = new MaximumValueOfAnOrderedTripletIIProblem();

        var answer = problem.MaximumTripletValue(nums);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<int[], long> TestData => new()
    {
        {
            [12,6,1,2,7],
            77
        },
        {
            [1,10,3,4,19],
            133
        },
        {
            [1,2,3],
            0
        }
    };
}
