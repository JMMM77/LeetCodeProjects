using LeetCodeSolutions._0._0._10;

namespace LeetCodeSolutions.Tests._0._0._10;

public class RomanToIntegerProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string romanNumerables, int expectedResult)
    {
        var problem = new RomanToIntegerProblem();

        var answer = problem.RomanToInt(romanNumerables);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<string, int> TestData => new()
    {
        {
            "III",
            3
        },
        {
            "LVIII",
            58
        },
        {
            "MCMXCIV",
            1994
        }
    };
}
