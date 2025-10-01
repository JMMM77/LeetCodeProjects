namespace LeetCodeSolutions._3000._400._80;

/***
URL: https://leetcode.com/problems/design-spreadsheet
Number: 3484
Difficulty: Medium
 */
public class DesignSpreadsheet
{
    public class Spreadsheet
    {
        private readonly int[][] SpreadSheet = new int[26][];

        public Spreadsheet(int rows)
        {
            for (var i = 0; i < 26; i++)
            {
                SpreadSheet[i] = new int[rows];

                for (var j = 0; j < rows; j++)
                {
                    SpreadSheet[i][j] = 0;
                }
            }
        }

        public void SetCell(string cell, int value)
        {
            var (colIndex, rowIndex) = GetColumnIndex(cell);

            SpreadSheet[colIndex][rowIndex] = value;
        }

        public void ResetCell(string cell)
        {
            var (colIndex, rowIndex) = GetColumnIndex(cell);
            SpreadSheet[colIndex][rowIndex] = 0;
        }

        public int GetValue(string formula)
        {
            var formSplit = formula.Split('+');
            var leftSide = formSplit[0][1..];
            var rightSide = formSplit[1];

            return GetNum(leftSide) + GetNum(rightSide);
        }

        private (int colIndex, int rowIndex) GetColumnIndex(string cell)
        {
            var colIndex = cell[0] - 'A';
            var rowIndex = int.Parse(cell[1..]) - 1;

            return (colIndex, rowIndex);
        }

        private int GetNum(string num)
        {
            if (!int.TryParse(num, out var realNum))
            {
                var (colIndex, rowIndex) = GetColumnIndex(num);

                return SpreadSheet[colIndex][rowIndex];
            }

            return realNum;
        }
    }
}
