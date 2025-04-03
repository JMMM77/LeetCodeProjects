using LeetCodeSolutions._2000._200._10;

namespace TestProjects._2000._200._10;

public class FindAllPossibleRecipesFromGivenSuppliesTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] recipes, List<IList<string>> ingredients, string[] supplies, string[] expectedResult)
    {
        var testClass = new FindAllPossibleRecipesFromGivenSuppliesProblem();

        var answer = testClass.FindAllRecipes(recipes, ingredients, supplies);

        Assert.Equal(expectedResult, answer);
    }

    public static IEnumerable<object[]> TestData = [
        [
            new string[] {
                "bread"
            },
            ConvertListListToListIList([
                ["yeast", "flour"],
            ]),
            new string[] {
                "yeast","flour","corn"
            },
            new string[] {
                "bread"
            }
        ],
        [
            new string[] {
                "bread", "sandwich"
            },
            ConvertListListToListIList([
                ["yeast", "flour"],
                ["bread", "meat"]
            ]),
            new string[] {
                "yeast","flour","meat"
            },
            new string[] {
                "bread","sandwich"
            }
        ],
        [
            new string[] {
                "bread","sandwich","burger"
            },
            ConvertListListToListIList([
                ["yeast", "flour"],
                ["bread", "meat"],
                ["sandwich", "meat", "bread"]
            ]),
            new string[] {
                "yeast","flour","meat"
            },
            new string[] {
                "bread","sandwich","burger"
            }
        ],
        [
            new string[] {
                "ju","fzjnm","x","e","zpmcz","h","q"
            },
            ConvertListListToListIList([
                ["d"],
                ["hveml","f","cpivl"],
                ["cpivl","zpmcz","h","e","fzjnm","ju"],
                ["cpivl","hveml","zpmcz","ju","h"],
                ["h","fzjnm","e","q","x"],
                ["d","hveml","cpivl","q","zpmcz","ju","e","x"],
                ["f","hveml","cpivl"]
            ]),
            new string[] {
                "f","hveml","cpivl","d"
            },
            new string[] {
                "ju","fzjnm","q"
            }
        ]
    ];

    private static List<IList<string>> ConvertListListToListIList(List<List<string>> ingredients)
    {
        var convertedList = new List<IList<string>>();
        foreach (var ingredient in ingredients)
        {
            convertedList.Add(ingredient);
        }
        return convertedList;
    }

}
