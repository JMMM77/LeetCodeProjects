using LeetCodeSolutions._0._600._10;

namespace LeetCodeSolutions.Tests._0._600._10;

public class ValidTriangleNumberTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] param1, int expectedResult)
    {
        var problem = new ValidTriangleNumber();

        var answer = problem.TriangleNumber(param1);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<int[], int> TestData => new()
    {
        {
            [2,2,3,4],
            3
        },
        {
            [4,2,3,4],
            4
        }
    };
}
