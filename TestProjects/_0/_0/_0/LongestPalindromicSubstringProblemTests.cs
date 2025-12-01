using LeetCodeSolutions._0._0._0;

namespace LeetCodeSolutions.Tests._0._0._0;

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
    public static TheoryData<string, string> TestData => new()
    {
        { "a", "a" },
        { "ac", "a" },
        { "bb", "bb" },
        { "babad", "aba" },
        { "cbbd", "bb" },
        { "aacabdkacaa", "aca" },
        { "forgeeksskeegfor", "geeksskeeg" }
    };
}
