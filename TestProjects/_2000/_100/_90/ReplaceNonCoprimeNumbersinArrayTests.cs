using LeetCodeSolutions._2000._100._90;

namespace LeetCodeSolutions.Tests._2000._100._90;

public class ReplaceNonCoprimeNumbersinArrayTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int[] expectedResult)
    {
        var problem = new ReplaceNonCoprimeNumbersinArray();

        var answer = problem.ReplaceNonCoprimes(nums);

        Assert.Equal(expectedResult, answer);
    }

    public static TheoryData<int[], int[]> TestData => new()
    {
        {
            [6,4,3,2,7,6,2],
            [12,7,6]
        },
        {
            [2,2,1,1,3,3,3],
            [2,1,1,3]
        }
    };
}
