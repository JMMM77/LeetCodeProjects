using LeetCodeSolutions._3000._300._90;

namespace TestProjects._3000._300._90;

public class CheckIfGridCanBeCutIntoSectionsProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int[][] rectangles, bool expectedResult)
    {
        var problem = new CheckIfGridCanBeCutIntoSectionsProblem();

        var answer = problem.CheckValidCuts(n, rectangles);

        Assert.Equal(expectedResult, answer);
    }

    public static IEnumerable<object[]> TestData = [
        [
            5,
            ConvertTo2DIntArray([[1,0,5,2],[0,2,2,4],[3,2,5,3],[0,4,4,5]]),
            true
        ],
        [
            4,
            ConvertTo2DIntArray([[0,0,1,1],[2,0,3,4],[0,2,2,3],[3,0,4,3]]),
            true
        ],
        [
            4,
            ConvertTo2DIntArray([[0,2,2,4],[1,0,3,2],[2,2,3,4],[3,0,4,2],[3,2,4,4]]),
            false
        ]
    ];

    private static int[][] ConvertTo2DIntArray(int[][] intList)
    {
        return intList;
    }
}
