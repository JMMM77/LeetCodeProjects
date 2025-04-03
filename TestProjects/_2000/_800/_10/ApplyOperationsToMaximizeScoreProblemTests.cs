using LeetCodeSolutions._2000._800._10;

namespace TestProjects._2000._800._10;

public class MaximumValueOfAnOrderedTripletIIProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(List<int> nums, int k, int expectedResult)
    {
        var problem = new ApplyOperationsToMaximizeScoreProblem();

        var answer = problem.MaximumScore(nums, k);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<List<int>, int, int> TestData => new()
    {
        {
            [8,3,9,3,8],
            2,
            81
        },
        {
            [19,12,14,6,10,18],
            3,
            4788
        },
        {
            [3289,2832,14858,22011],
            6,
            256720975
        }
    };
}
