using static LeetCodeSolutions._3000._400._80.DesignSpreadsheet;

namespace LeetCodeSolutions.Tests._3000._400._0;

public class DesignSpreadsheetTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int rows, string[] commands, string[][] inputs, int?[] expectedResults)
    {
        var problem = new Spreadsheet(rows);

        for (var i = 0; i < commands.Length; i++)
        {
            var command = commands[i];
            int? answer = null;

            switch (command)
            {
                case Commands.SetCell:
                    problem.SetCell(inputs[i][0], int.Parse(inputs[i][1]));
                    break;

                case Commands.ResetCell:
                    problem.ResetCell(inputs[i][0]);
                    break;

                case Commands.GetValue:
                    answer = problem.GetValue(inputs[i][0]);
                    break;
            }

            Assert.Equal(expectedResults[i], answer);
        }
    }

    public static TheoryData<int, string[], string[][], int?[]> TestData => new()
    {
        {
            3,
            ["getValue","setCell","getValue","setCell","getValue","resetCell","getValue"],
            [["=5+7"],["A1","10"],["=A1+6"],["B2","15"],["=A1+B2"],["A1"],["=A1+B2"]],
            [12, null, 16, null, 25, null, 15]
        },
        {
            24,
            ["setCell","resetCell"],
            [["B24","66688"],["O15"]],
            [null,null]
        }
    };

    internal class Commands
    {
        public const string GetValue = "getValue";
        public const string SetCell = "setCell";
        public const string ResetCell = "resetCell";
    }
}
