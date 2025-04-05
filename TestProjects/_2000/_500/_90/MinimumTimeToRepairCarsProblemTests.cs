using LeetCodeSolutions._2000._500._90;

namespace LeetCodeSolutions.Tests._2000._500._90;

public class MinimumTimeToRepairCarsProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test2(int[] ranks, int cars, long expectedValue)
    {
        var timeTaken = MinimumTimeToRepairCarsProblem.RepairCars(ranks, cars);
        Assert.Equal(expectedValue, timeTaken);
    }

    //[Theory]
    //[MemberData(nameof(TestData))]
    //public void Test1(int[] ranks, int cars, long expectedValue)
    //{
    //    var timeTaken = MinimumTimeToRepairCarsProblem.RepairCars(ranks, cars);
    //    Assert.Equal(expectedValue, timeTaken);
    //}

    // Define the test data
    public static IEnumerable<object[]> TestData = [
        [
            new int[] {
                31, 31, 5, 19, 19, 10, 31, 18, 19, 3, 16, 20, 4, 16, 2, 25, 10, 16, 23, 18, 21, 23, 28, 6, 7, 29, 11, 11, 19, 20, 24, 19, 26, 12, 29, 29, 1, 14, 17, 26, 24, 7, 11, 28, 22, 14, 31, 12, 3, 19, 16, 26, 11
            },
            736185,
            2358388332
        ],
        [
            new int[] {
                1
            },
            1,
            1
        ],
        [
            new int[] {
                4,5,5
            },
            1,
            4
        ],
        [
            new int[] {
                5,2,2,5
            },
            2,
            2
        ],
        [
            new int[] {
                5,1,8
            },
            6,
            16
        ]
    ];
}