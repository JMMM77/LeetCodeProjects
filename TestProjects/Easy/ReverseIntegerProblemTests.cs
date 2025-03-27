using LeetCodeSolutions.Easy;

namespace TestProjects.Easy;

public class ReverseIntegerProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int numToVerify, bool expected)
    {
        var problem = new ReverseIntegerProblem();

        var calculatedValue = problem.Reverse(numToVerify);

        Assert.Equal(expected, calculatedValue);
    }

    public static IEnumerable<object[]> TestData = [
        [
            3,
            true
        ],
        [
            121,
            true
        ],
        [
            10,
            false
        ],
        [
            -121,
            false
        ]
    ];
}
