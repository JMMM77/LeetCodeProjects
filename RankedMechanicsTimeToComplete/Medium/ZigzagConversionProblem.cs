namespace LeetCodeSolutions.Medium;

/***
URL: https://leetcode.com/problems/zigzag-conversion/
TOPICS: String

The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

P   A   H   N
A P L S I I G
Y   I   R
And then read line by line: "PAHNAPLSIIGYIR"

Write the code that will take a string and make this conversion given a number of rows:

string convert(string s, int numRows);
 
Example 1:

Input: s = "PAYPALISHIRING", numRows = 3
Output: "PAHNAPLSIIGYIR"
Example 2:

Input: s = "PAYPALISHIRING", numRows = 4
Output: "PINALSIGYAHRPI"
Explanation:
P     I    N
A   L S  I G
Y A   H R
P     I
Example 3:

Input: s = "A", numRows = 1
Output: "A"
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
