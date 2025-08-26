namespace LeetCodeSolutions._0._100._10;

/***
URL: https://leetcode.com/problems/pascals-triangle-ii
Number: 119
Difficulty: Easy
 */
public class PascalsTriangleII
{
    public IList<int> GetRow(int rowIndex)
    {
        var row = new List<int>() { 1 };

        for (var i = 1; i <= rowIndex; i++)
        {
            var newRow = new List<int>() { 1 };

            for (var j = 1; j < row.Count; j++)
            {
                newRow.Add(row[j - 1] + row[j]);
            }

            newRow.Add(1);

            row = newRow;
        }

        return row;
    }

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
