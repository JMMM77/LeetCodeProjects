using LeetCodeSolutions.Medium;

namespace TestProjects.Medium;

public class CountDaysWithoutMeetingsProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int days, int[][] meetings, int expectedResult)
    {
        var problem = new CountDaysWithoutMeetingsProblem();

        var answer = problem.CountDays(days, meetings);

        Assert.Equal(expectedResult, answer);
    }

    public static IEnumerable<object[]> TestData = [
        [
            10,
            ConvertTo2DIntArray([[5,7],[1,3],[9,10]]),
            2
        ],
        [
            5,
            ConvertTo2DIntArray([[2,4],[1,3]]),
            1
        ],
        [
            6,
            ConvertTo2DIntArray([[1,6]]),
            0
        ]
    ];
    private static int[][] ConvertTo2DIntArray(int[][] intList)
    {
        return intList;
    }
}
