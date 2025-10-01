namespace LeetCodeSolutions._0._0._30;

/***
URL: https://leetcode.com/problems/valid-sudoku
Number: 36
Difficulty: Medium
 */
public class ValidSudoku
{
    public bool IsValidSudoku(char[][] board)
    {
        // Validate rows and cols
        for (var i = 0; i < 9; i++)
        {
            var rows = new HashSet<char>();

            for (var row = 0; row < 9; row++)
            {
                var thisVal = board[i][row];

                if (thisVal == '.')
                {
                    continue;
                }

                if (rows.Contains(thisVal))
                {
                    return false;
                }

                rows.Add(thisVal);
            }

            var cols = new HashSet<char>();

            for (var col = 0; col < 9; col++)
            {
                var thisVal = board[col][i];

                if (thisVal == '.')
                {
                    continue;
                }

                if (cols.Contains(thisVal))
                {
                    return false;
                }

                cols.Add(thisVal);
            }
        }

        // Validate Squares
        for (var row = 0; row < 9; row += 3)
        {
            for (var col = 0; col < 9; col += 3)
            {
                var endRow = row + 3;
                var endCol = col + 3;
                var nums = new HashSet<char>();

                for (var squareRow = row; squareRow < endRow; squareRow++)
                {
                    for (var squareCol = col; squareCol < endCol; squareCol++)
                    {
                        var thisVal = board[squareRow][squareCol];

                        if (thisVal == '.')
                        {
                            continue;
                        }

                        if (nums.Contains(thisVal))
                        {
                            return false;
                        }

                        nums.Add(board[squareRow][squareCol]);
                    }
                }
            }
        }

        return true;
    }
}
