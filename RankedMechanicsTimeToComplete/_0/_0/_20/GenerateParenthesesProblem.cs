namespace LeetCodeSolutions._0._0._20;
/***
URL: https://leetcode.com/problems/generate-parentheses/description/
Number: 22
Difficulty: Medium
 */
public class GenerateParenthesesProblem
{
    public IList<string> GenerateParenthesis(int n)
    {
        var validParentheses = new Dictionary<string, int[]>()
        {
            { "(", [1, 0] } // current parenthesis, [numOfOpenParentheses, numOfClosedParentheses]
        };

        var stepsToIterate = n * 2 - 1;

        for (var i = 0; i < stepsToIterate; i++)
        {
            var newList = new Dictionary<string, int[]>();

            foreach (var parentheses in validParentheses)
            {
                if (parentheses.Value[0] > parentheses.Value[1])
                {
                    newList.Add(parentheses.Key + ")", [parentheses.Value[0], parentheses.Value[1] + 1]);
                }

                if (parentheses.Value[0] < n)
                {
                    newList.Add(parentheses.Key + "(", [parentheses.Value[0] + 1, parentheses.Value[1]]);
                }
            }

            validParentheses = newList;
        }

        return validParentheses.Keys.ToList();
    }
}
