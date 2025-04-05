using LeetCodeSolutions._2000._100._40;

namespace LeetCodeSolutions.Tests._2000._100._40;

public class SolvingQuestionsWithBrainpowerProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] nums, long expectedResult)
    {
        var problem = new SolvingQuestionsWithBrainpowerProblem();

        var answer = problem.MostPoints(nums);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<int[][], long> TestData => new()
    {
        //{
        //    [[3, 2], [4, 3], [4, 4], [2, 5]],
        //    5
        //},
        //{
        //    [[1,1],[2,2],[3,3],[4,4],[5,5]],
        //    7
        //},
        {
            [[21,5],[92,3],[74,2],[39,4],[58,2],[5,5],[49,4],[65,3]],
            157
        }
    };
}
