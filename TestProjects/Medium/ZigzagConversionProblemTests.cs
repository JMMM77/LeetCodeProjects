using LeetCodeSolutions.Medium;

namespace TestProjects.Medium;

public class ZigzagConversionProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string initialString, int numOfRows, string expectedString)
    {
        var ZigzagConversionProblem = new ZigzagConversionProblem();

        var combinedList = ZigzagConversionProblem.Convert(initialString, numOfRows);

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
