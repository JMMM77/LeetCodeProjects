using LeetCodeSolutions._0._0._40;

namespace LeetCodeSolutions.Tests._0._0._40;

public class WildcardMatchingProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string s, string p, bool expectedResult)
    {
        var problem = new WildcardMatchingProblem();

        var answer = problem.IsMatch(s, p);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<string, string, bool> TestData => new()
    {
        {
            "aa",
            "aa",
            true
        }
    };
}
