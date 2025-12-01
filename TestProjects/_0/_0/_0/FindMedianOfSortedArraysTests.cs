using LeetCodeSolutions._0._0._0;

namespace LeetCodeSolutions.Tests._0._0._0;

public class FindMedianOfSortedArraysTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] list1, int[] list2, double expectedValue)
    {
        var combinedList = FindMedianOfSortedArraysProblem.FindMedianSortedArrays(list1, list2);

        Assert.Equal(expectedValue, combinedList);
    }
    public static TheoryData<int[], int[], double> TestData => new()
    {
        {
            [1, 3],
            [2],
            2
        },
        {
            [1, 2],
            [3, 4],
            2.5
        },
    };
}
