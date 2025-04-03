using LeetCodeSolutions._0._0._0;

namespace TestProjects._0._0._0;

public class ZigzagConversionProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string initialString, int numOfRows, string expectedString)
    {
        var problem = new ZigzagConversionProblem();

        var combinedList = problem.Convert(initialString, numOfRows);

        Assert.Equal(expectedString, combinedList);
    }

    public static IEnumerable<object[]> TestData = [
        [
            "PAYPALISHIRING",
            3,
            "PAHNAPLSIIGYIR"
        ],
        [
            "PAYPALISHIRING",
            4,
            "PINALSIGYAHRPI"
        ],
        [
            "A",
            1,
            "A"
        ]
    ];
}
