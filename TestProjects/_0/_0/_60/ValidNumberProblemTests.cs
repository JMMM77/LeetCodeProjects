using LeetCodeSolutions._0._0._60;

namespace LeetCodeSolutions.Tests._0._0._60;

public class ValidNumberProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string s, bool expectedValue)
    {
        var problem = new ValidNumberProblem();

        var result = problem.IsNumber(s);

        Assert.Equal(expectedValue, result);
    }

    public static IEnumerable<object[]> TestData = [
        [
            "0",
            true
        ],
        [
            "e",
            false
        ],
        [
            ".",
            false
        ],
        [
            "2",
            true
        ],
        [
            "0089",
            true
        ],
        [
            "-0.1",
            true
        ],
        [
            "+3.14",
            true
        ],
        [
            "4.",
            true
        ],
        [
            "-.9",
            true
        ],
        [
            "2e10",
            true
        ],
        [
            "-90E3",
            true
        ],
        [
            "3e+7",
            true
        ],
        [
            "+6e-1",
            true
        ],
        [
            "53.5e93",
            true
        ],
        [
            "-123.456e789",
            true
        ],
        [
            "abc",
            false
        ],
        [
            "1a",
            false
        ],
        [
            "1e",
            false
        ],
        [
            "e3",
            false
        ],
        [
            "99e2.5",
            false
        ],
        [
            "-+3",
            false
        ],
        [
            "95a54e53",
            false
        ],
        [
            "-.7e+-0435",
            false
        ],
        [
            "6+1",
            false
        ],
        [
            "4e+",
            false
        ],
        [
            "46.e3",
            true
        ],
        [
            ".e1",
            false
        ],
        [
            "459277e38+",
            false
        ],
        [
            "+",
            false
        ]
    ];
}