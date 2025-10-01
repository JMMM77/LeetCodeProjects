namespace LeetCodeSolutions._3000._300._90;

/***
URL: https://leetcode.com/problems/check-if-grid-can-be-cut-into-sections/description
Number: 3394
Difficulty: Medium
 */

public class CheckIfGridCanBeCutIntoSectionsProblem
{
    public bool CheckValidCuts(int n, int[][] rectangles)
    {
        // Input: Length = 5, rectangles ([startx, starty, endx, endy]) = [[1,0,5,2],[0,2,2,4],[3,2,5,3],[0,4,4,5]]

        var sortedHorizontalValues = new SortedSet<(int, int)>(); // Values for x
        var sortedVerticalValues = new SortedSet<(int, int)>(); // Values for y

        foreach (var rectangle in rectangles)
        {
            sortedHorizontalValues.Add((rectangle[0], rectangle[2]));
            sortedVerticalValues.Add((rectangle[1], rectangle[3]));
        }

        var numOfHorizontalCuts = 0;
        var numOfVerticalCuts = 0;

        var (startx, endx) = sortedHorizontalValues.Min;
        sortedHorizontalValues.Remove(sortedHorizontalValues.Min);

        var (starty, endy) = sortedVerticalValues.Min;
        sortedVerticalValues.Remove(sortedVerticalValues.Min);

        for (var i = 1; i < rectangles.Length; i++)
        {
            var (newStartx, newEndx) = sortedHorizontalValues.Min;
            sortedHorizontalValues.Remove(sortedHorizontalValues.Min);

            var (newStarty, newEndy) = sortedVerticalValues.Min;
            sortedVerticalValues.Remove(sortedVerticalValues.Min);

            if (endx <= newStartx)
            {
                numOfHorizontalCuts++;
            }

            if (endx < newEndx)
            {
                endx = newEndx;
            }

            if (endy <= newStarty)
            {
                numOfVerticalCuts++;
            }

            if (endy < newEndy)
            {
                endy = newEndy;
            }

            if (numOfHorizontalCuts == 2 || numOfVerticalCuts == 2)
            {
                return true;
            }
        }

        return false;
    }
}
