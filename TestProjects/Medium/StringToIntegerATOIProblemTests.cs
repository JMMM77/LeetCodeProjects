using LeetCodeSolutions.Medium;

namespace TestProjects.Medium;

public class StringToIntegerATOIProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string s, int expectedResult)
    {
        var problem = new StringToIntegerATOIProblem();

        var answer = problem.MyAtoi(s);

        Assert.Equal(expectedResult, answer);
    }

    public static IEnumerable<object[]> TestData = [
        [
            "42",
            42
        ],
        [
            "   -042",
            -42
        ],
        [
            "1337c0d3",
            1337
        ],
        [
            "",
            0
        ],
        [
            "21474836460",
            2147483647
        ]
    ];
}
