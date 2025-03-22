using LeetCodeSolutions.Hard;

namespace TestProjects.Hard;

public class FindMedianOfSortedArraysTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] list1, int[] list2, double expectedValue)
    {
        var combinedList = FindMedianOfSortedArrays.FindMedianSortedArrays(list1, list2);

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
