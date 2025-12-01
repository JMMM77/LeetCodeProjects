using LeetCodeSolutions._3000._200._20;

namespace LeetCodeSolutions.Tests._3000._200._20;

public class MaximumNumberofOperationstoMoveOnestotheEndTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string s, int expected)
    {
        var problem = new MaximumNumberofOperationstoMoveOnestotheEnd();

        var result = problem.MaxOperations(s);

        Assert.Equal(expected, result);
    }

    public static TheoryData<string, int> TestData => new(){
        {"0", 0},
        {"1", 0},
        {"10", 1},
        {"01", 0},
        {"110", 2},
        {"1001", 2},
        {"1010", 3},
        {"111000", 9},
        {"010110", 4}
    };
}