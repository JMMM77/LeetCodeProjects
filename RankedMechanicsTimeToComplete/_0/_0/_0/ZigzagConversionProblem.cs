namespace LeetCodeSolutions._0._0._0;

/***
URL: https://leetcode.com/problems/zigzag-conversion/
TOPICS: String
Number: 6
Difficulty: Medium
 */

public class ZigzagConversionProblem
{
    public string Convert(string s, int numRows)
    {
        if (numRows == 1)
        {
            return s;
        }

        var rows = new string[numRows];
        var incrementing = true;
        var rowIndex = 0;

        // Loop through all characters and add them to their respective row.
        for (var i = 0; i < s.Length; i++)
        {
            var characterToAdd = s[i].ToString();
            rows[rowIndex] = rows[rowIndex] + characterToAdd;

            // Makes sure the row index is going in the correct direction
            if (rowIndex == numRows - 1)
            {
                incrementing = false;
            }
            else if (rowIndex == 0)
            {
                incrementing = true;
            }

            // Go to the next row
            if (incrementing)
            {
                rowIndex++;
            }
            else
            {
                rowIndex--;
            }
        }

        return string.Join("", rows);
    }
}
