namespace LeetCodeSolutions._0._400._90;

/***
URL: https://leetcode.com/problems/diagonal-traverse
Number: 495
Difficulty: Medium
 */
public class DiagonalTraverse
{
    public int[] FindDiagonalOrder(int[][] mat)
    {
        var flip = false;
        var indexX = 0;
        var indexY = 0;
        var yMaxLength = mat[0].Length;
        var returnArray = new int[mat.Length * yMaxLength];

        for (var i = 0; i < returnArray.Length; i++)
        {
            returnArray[i] = mat[indexX][indexY];

            if (flip)
            {
                indexX++;
                indexY--;
            }
            else
            {
                indexX--;
                indexY++;
            }

            if (indexX == -1 && indexY < yMaxLength)
            {
                flip = true;
                indexX = 0;
            }
            else if (indexY == yMaxLength)
            {
                flip = true;
                indexX += 2;
                indexY = yMaxLength - 1;
            }
            else if (indexY == -1 && indexX < mat.Length)
            {
                flip = false;
                indexY = 0;
            }
            else if (indexX == mat.Length)
            {
                flip = false;
                indexY += 2;
                indexX = mat.Length - 1;
            }
        }

        return returnArray;
    }
}
