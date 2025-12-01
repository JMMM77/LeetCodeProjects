namespace LeetCodeSolutions._0._700._50;

/***
URL: https://leetcode.com/problems/set-intersection-size-at-least-two
Number: 757
Difficulty: Hard
 */
public class SetIntersectionSizeAtLeastTwo
{
    public int IntersectionSizeTwo(int[][] intervals)
    {
        Array.Sort(intervals, new EndingFirstComparer());

        var leftIntervalLast = intervals[0][1];
        var leftIntervalSecondLast = intervals[0][1] - 1;
        var minLength = 2;

        for (var i = 1; i < intervals.Length; i++)
        {
            var rightIntervalFirst = intervals[i][0];

            if (rightIntervalFirst <= leftIntervalSecondLast)
            {
                continue;
            }

            var rightIntervalLast = intervals[i][1];

            if (rightIntervalFirst <= leftIntervalLast)
            {
                minLength++;

                if (rightIntervalLast == leftIntervalLast)
                {
                    leftIntervalSecondLast = leftIntervalLast - 1;
                }
                else
                {
                    (leftIntervalLast, leftIntervalSecondLast) = (rightIntervalLast, leftIntervalLast);
                }

                continue;
            }

            minLength += 2;
            (leftIntervalLast, leftIntervalSecondLast) = (rightIntervalLast, rightIntervalLast - 1);
        }

        return minLength;
    }

    private sealed class EndingFirstComparer : Comparer<int[]>
    {
        public override int Compare(int[]? x, int[]? y)
            => x is null || y is null
                ? 0
                : x[1] == y[1]
                    ? x[0].CompareTo(y[0])
                    : x[1].CompareTo(y[1]);
    }
}
