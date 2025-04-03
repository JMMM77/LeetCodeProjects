using LeetCodeSolutions._0._0._10;

namespace TestProjects._0._0._10;

public class RegularExpressionMatchingProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string s, string p, bool expectedResult)
    {
        var problem = new RegularExpressionMatchingProblem();

        var answer = problem.IsMatch(s, p);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<string, string, bool> TestData => new()
    {
        {
            "aa",
            "a",
            false
        },
        {
            "aa",
            "a*",
            true
        },
        {
            "ab",
            ".*",
            true
        },
        {
            "ab",
            "a*",
            false
        },
        {
            "aaaaaaaaaaaaaaaaaab",
            "a*b",
            true
        },
        {
            "aab",
            "c*a*b",
            true
        },
        {
            "ab",
            ".*c",
            false
        },
        {
            "aaa",
            "a*a",
            true
        }
    };
}
