namespace LeetCodeSolutions._0._100._70;

/***
URL: https://leetcode.com/problems/excel-sheet-column-number
Number: 171
Difficulty: Easy
 */
public class ExcelSheetColumnNumber
{
    public int TitleToNumber(string columnTitle)
    {
        var result = 0;
        var baseToConvert = 26;
        var currentPow = 1;
        var baseNum = (int)'A' - 1;

        for (var i = 1; i <= columnTitle.Length; i++)
        {
            result += currentPow * ((int)columnTitle[columnTitle.Length - i] - baseNum);
            currentPow *= baseToConvert;
        }

        return result;
    }
}
