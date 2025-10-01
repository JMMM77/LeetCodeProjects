namespace LeetCodeSolutions.Tests._3000._0._20;

/***
URL: https://leetcode.com/problems/find-the-number-of-ways-to-place-people-i
Number: 3025
Difficulty: Medium
 */
public class FindtheNumberofWaystoPlacePeopleI
{
    public int NumberOfPairs(int[][] points)
    {
        if (points.Length == 2)
        {
            var leftX = points[0][0];
            var leftY = points[0][1];
            var rightX = points[1][0];
            var rightY = points[1][1];

            if ((leftX <= rightX && leftY >= rightY)
                || (leftX >= rightX && leftY <= rightY))
            {
                return 1;
            }

            return 0;
        }

        var numOfCords = 0;

        for (var i = 0; i < points.Length; i++)
        {
            var thisX = points[i][0];
            var thisY = points[i][1];

            for (var j = i + 1; j < points.Length; j++)
            {
                var testX = points[j][0];
                var testY = points[j][1];

                if (!((thisX <= testX && thisY >= testY)
                    || (thisX >= testX && thisY <= testY)))
                {
                    continue;
                }

                var minX = Math.Min(thisX, testX);
                var minY = Math.Min(thisY, testY);
                var maxX = Math.Max(thisX, testX);
                var maxY = Math.Max(thisY, testY);

                var containsOverlap = false;

                for (var k = 0; k < points.Length; k++)
                {
                    if (k == i || k == j)
                    {
                        continue;
                    }

                    var thisCord = points[k];

                    if ((thisCord[0] >= minX && thisCord[0] <= maxX)
                        && (thisCord[1] >= minY && thisCord[1] <= maxY))
                    {
                        containsOverlap = true;
                        break;
                    }
                }

                if (!containsOverlap)
                {
                    numOfCords++;
                }
            }
        }

        return numOfCords;
    }
}
