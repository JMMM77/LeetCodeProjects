using LeetCodeSolutions._0._0._10;

namespace LeedCodeSolutions.Tests._0._0._10;

public class IntegerToRomanProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int param1, string expectedResult)
    {
        var problem = new IntegerToRomanProblem();

        var answer = problem.IntToRoman(param1);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<int, string> TestData => new()
    {
        {
            3749,
            "MMMDCCXLIX"
        },
        {
            58,
            "LVIII"
        },
        {
            1994,
            "MCMXCIV"
        }
    };
}
