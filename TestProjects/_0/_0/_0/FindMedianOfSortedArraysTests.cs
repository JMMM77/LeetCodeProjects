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

    public static IEnumerable<object[]> TestData = [
        [
            new int[]{
                1,3
            },
            new int[]{
                2
            },
            2
        ],
        [
            new int[]{
                1,2
            },
            new int[]{
                3,4
            },
            2.5
        ],
    ];
}
