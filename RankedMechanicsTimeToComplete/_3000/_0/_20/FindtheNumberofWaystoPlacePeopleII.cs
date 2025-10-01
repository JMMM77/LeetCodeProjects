namespace LeetCodeSolutions._3000._0._20;

/***
URL: https://leetcode.com/problems/find-the-number-of-ways-to-place-people-ii
Number: 3026
Difficulty: Hard
 */
public class FindtheNumberofWaystoPlacePeopleII
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

        Array.Sort(points, (a, b) =>
        {
            if (a[0] != b[0])
            {
                return a[0].CompareTo(b[0]);
            }

            return b[1].CompareTo(a[1]);
        });

        var numOfCords = 0;

        for (var i = 0; i < points.Length - 1; i++)
        {
            var pointA = points[i];
            var xMin = pointA[0] - 1;
            var xMax = int.MaxValue;
            var yMin = int.MinValue;
            var yMax = pointA[1] + 1;

            for (var j = i + 1; j < points.Length; j++)
            {
                var pointB = points[j];

                if (pointB[0] > xMin
                    && pointB[0] < xMax
                    && pointB[1] > yMin
                    && pointB[1] < yMax)
                {
                    numOfCords++;
                    xMin = pointB[0];
                    yMin = pointB[1];
                }
            }
        }

        return numOfCords;
    }
}
