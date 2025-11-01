namespace LeetCodeSolutions._2000._0._10;

/***
URL: https://leetcode.com/problems/final-value-of-variable-after-performing-operations
Number: 2011
Difficulty: Easy
 */
public class FinalValueofVariableAfterPerformingOperations
{
    public int FinalValueAfterOperations(string[] operations)
    {
        var ops = new string[] {
            "++X",
            "X++",
            "--X",
            "X--"
        };

        var x = 0;

        foreach (var operation in operations)
        {
            if (operation.Equals(ops[0]) || operation.Equals(ops[1]))
            {
                x++;
            }
            else
            {
                x--;
            }
        }

        return x;
    }
}
