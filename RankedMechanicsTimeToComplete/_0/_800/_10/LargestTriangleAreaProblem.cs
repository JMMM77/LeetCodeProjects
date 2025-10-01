namespace LeetCodeSolutions._0._800._10;

/***
URL: https://leetcode.com/problems/largest-triangle-Area
Number: 812
Difficulty: Easy
 */
public class LargestTriangleAreaProblem
{
    public double LargestTriangleArea(int[][] points)
    {
        var N = points.Length;
        double ans = 0;

        for (var point1 = 0; point1 < N; point1++)
        {
            for (var point2 = point1 + 1; point2 < N; point2++)
            {
                for (var point3 = point2 + 1; point3 < N; point3++)
                {
                    ans = Math.Max(ans, Area(points[point1], points[point2], points[point3]));
                }
            }
        }

        return ans;
    }

    public static double Area(int[] point1, int[] point2, int[] point3)
        => 0.5
        * Math.Abs(
            ((point1[0] * point2[1]) + (point2[0] * point3[1]) + (point3[0] * point1[1]))
            - (point1[1] * point2[0]) - (point2[1] * point3[0]) - (point3[1] * point1[0]));
}
