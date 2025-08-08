using LeetCodeSolutions._0._100._40;

namespace LeetCodeSolutions.Tests._2000._100._40;

public class CountTheHiddenSequencesProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] differences, int lower, int upper, int expectedResult)
    {
        var problem = new CountTheHiddenSequencesProblem();

        var answer = problem.NumberOfArrays(differences, lower, upper);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<int[], int, int, int> TestData => new()
    {
        {
            [1, -3, 4],
            1,
            6,
            2
        }
    };
}
