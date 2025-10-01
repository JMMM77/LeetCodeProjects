namespace LeetCodeSolutions._0._0._30;

/***
URL: https://leetcode.com/problems/sudoku-solver
Number: 3021
Difficulty: Medium
 */
public class SudokuSolver
{
    public void SolveSudoku(char[][] board)
    {
        Solve(board);
    }

    private bool Solve(char[][] board)
    {
        for (var rowIndex = 0; rowIndex < 9; rowIndex++)
        {
            for (var columnIndex = 0; columnIndex < 9; columnIndex++)
            {
                if (board[rowIndex][columnIndex] != '.')
                {
                    continue;
                }

                for (var candidateDigit = '1'; candidateDigit <= '9'; candidateDigit++)
                {
                    if (!IsValidPlacement(board, rowIndex, columnIndex, candidateDigit))
                    {
                        continue;
                    }

                    board[rowIndex][columnIndex] = candidateDigit;

                    if (Solve(board))
                    {
                        return true;
                    }

                    board[rowIndex][columnIndex] = '.';
                }

                return false;
            }
        }

        return true;
    }

    private bool IsValidPlacement(char[][] board, int rowIndex, int columnIndex, char digit)
    {
        // Validate row and column
        for (var i = 0; i < 9; i++)
        {
            if (board[rowIndex][i] == digit || board[i][columnIndex] == digit)
            {
                return false;
            }
        }

        // Validate 3x3 sub-box
        var subBoxRowStart = (rowIndex / 3) * 3;
        var subBoxColumnStart = (columnIndex / 3) * 3;

        for (var row = subBoxRowStart; row < subBoxRowStart + 3; row++)
        {
            for (var col = subBoxColumnStart; col < subBoxColumnStart + 3; col++)
            {
                if (board[row][col] == digit)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
