using LeetCodeSolutions._0._0._0;

namespace LeetCodeSolutions.Tests._0._0._0;

public class LongestSubstringWithoutRepeatingCharactersProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string s, int expectedResult)
    {
        var testClass = new LongestSubstringWithoutRepeatingCharactersProblem();

        var answer = testClass.LengthOfLongestSubstring(s);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<string, int> TestData { get; } = new TheoryData<string, int>
    {
        { "dvdf", 3 },
        { "abcabcbb", 3 },
        { "bbbbb", 1 },
        { "pwwkew", 3 }
    };
}
