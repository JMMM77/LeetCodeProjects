using LeetCodeSolutions._0._0._0;

namespace TestProjects._0._0._0;

public class LongestPalindromicSubstringProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string s, string expectedResult)
    {
        var testClass = new LongestPalindromicSubstringProblem();

        var answer = testClass.LongestPalindrome(s);

        Assert.Equal(expectedResult, answer);
    }

    public static IEnumerable<object[]> TestData = [
        [
            "babad",
            "aba"
        ],
        [
            "cbbd",
            "bb"
        ]
    ];
}
