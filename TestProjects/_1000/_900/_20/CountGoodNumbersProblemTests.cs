using LeetCodeSolutions._1000._900._20;

namespace LeetCodeSolutions.Tests._1000._900._20;

public class CountGoodNumbersProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(long initialString, int expectedResult)
    {
        var problem = new CountGoodNumbersProblem();

        var result = problem.CountGoodNumbers(initialString);

        Assert.Equal(expectedResult, result);
    }

    public static TheoryData<long, int> TestData => new() {
        {
            1,
            5
        },
        {
            4,
            400
        },
        {
            50,
            564908303
        },
        {
            1000000000000000,
            711414395
        }
    };
}
