using LeetCodeSolutions._0._900._90;

namespace LeetCodeSolutions.Tests._2000._900._90;

public class CountTheNumberOfPowerfulIntegersProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(long start, long finish, int limit, string s, long expectedResult)
    {
        var problem = new CountTheNumberOfPowerfulIntegersProblem();

        var answer = problem.NumberOfPowerfulInt(start, finish, limit, s);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<long, long, int, string, long> TestData => new()
    {
        {
            1,
            6372000,
            4,
            "124",
            5
        },
        {
            1,
            6000,
            4,
            "124",
            5
        },
        {
            15,
            215,
            6,
            "10",
            2
        },
        {
            1000,
            2000,
            4,
            "3000",
            0
        },
        {
            141,
            148,
            9,
            "9",
            0
        },
        {
            1,
            971,
            9,
            "17",
            10
        },
        {
            20,
            1159,
            5,
            "20",
            8
        }
    };
}
