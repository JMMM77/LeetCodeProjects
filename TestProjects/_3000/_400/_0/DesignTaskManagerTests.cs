using static LeetCodeSolutions._3000._400._0.DesignTaskManager;

namespace LeetCodeSolutions.Tests._3000._400._0;

public class DesignTaskManagerTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] tasks, string[] commands, int[][] inputs, List<int?> expectedResults)
    {
        var problem = new TaskManager(tasks);

        for (var i = 0; i < commands.Length; i++)
        {
            var command = commands[i];
            int? answer = null;

            switch (command)
            {
                case Commands.Add:
                    problem.Add(inputs[i][0], inputs[i][1], inputs[i][2]);
                    break;

                case Commands.Edit:
                    problem.Edit(inputs[i][0], inputs[i][1]);
                    break;

                case Commands.Remove:
                    problem.Rmv(inputs[i][0]);
                    break;

                case Commands.Exec:
                    answer = problem.ExecTop();
                    break;
            }

            Assert.Equal(expectedResults[i], answer);
        }
    }

    public static TheoryData<int[][], string[], int[][], List<int?>> TestData => new()
    {
        {
            [[1, 101, 10], [2, 102, 20], [3, 103, 15]],
            ["add", "edit", "execTop", "rmv", "add", "execTop"],
            [[4, 104, 5], [102, 8], [], [101], [5, 105, 15], []],
            [null, null, 3, null, null, 5]
        },
        {
            [[3,12,11],[6,2,46],[2,1,46],[5,23,21]],
            ["execTop"],
            [[]],
            [6]
        },
        {
            [[1,101,8],[2,102,20],[3,103,5]],
            ["add","edit","execTop","rmv","add","execTop"],
            [[4,104,5],[102,9],[],[101],[50,101,8],[]],
            [null,null,2,null,null,50]
        },
        {
            [[9,5,8],[0,7,36]],
            ["rmv","execTop"],
            [[7],[]],
            [null,9]
        }
    };

    internal class Commands
    {
        public const string Add = "add";
        public const string Edit = "edit";
        public const string Remove = "rmv";
        public const string Exec = "execTop";
    }
}
