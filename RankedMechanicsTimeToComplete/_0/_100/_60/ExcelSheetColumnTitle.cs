namespace LeetCodeSolutions._0._100._60;

/***
URL: https://leetcode.com/problems/linked-list-cycle
Number: 168
Difficulty: Easy
*/
public class ExcelSheetColumnTitle
{
    public string ConvertToTitle(int columnNumber)
    {
        var result = "";
        var baseToConvert = 26;

        while (columnNumber > 0)
        {
            columnNumber--;

            // Add 'A' to shift into the uppercase alphabet range in ASCII.
            result = ((char)((columnNumber) % baseToConvert + 'A')) + result;

            columnNumber = (columnNumber) / baseToConvert;
        }

        return result;
    }
}
