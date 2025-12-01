using LeetCodeSolutions._0._0._0;

namespace LeetCodeSolutions.Tests._0._0._0;

public class ReverseIntegerProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int numToVerify, bool expected)
    {
        var problem = new ReverseIntegerProblem();

        var calculatedValue = problem.Reverse(numToVerify);

        Assert.Equal(expected, calculatedValue);
    }

    public static TheoryData<int, bool> TestData { get; } = new TheoryData<int, bool>
    {
        { 3, true },
        { 121, true },
        { 10, false },
        { -121, false }
    };
}
