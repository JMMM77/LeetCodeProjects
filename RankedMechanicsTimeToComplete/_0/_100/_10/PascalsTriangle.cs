namespace LeetCodeSolutions._0._100._10;

/***
URL: https://leetcode.com/problems/pascals-triangle
Number: 118
Difficulty: Easy
 */
public class PascalsTriangle
{
    public IList<IList<int>> Generate(int numRows)
    {
        var prevNum = new List<int>() { 1 };
        var firstNumRows = new List<IList<int>>() { prevNum };

        for (var i = 1; i < numRows; i++)
        {
            var newNum = new List<int>() { 1 };

            for (var j = 1; j < prevNum.Count; j++)
            {
                newNum.Add(prevNum[j - 1] + prevNum[j]);
            }

            newNum.Add(1);

            firstNumRows.Add(newNum);
            prevNum = newNum;
        }

        return firstNumRows;
    }
}
