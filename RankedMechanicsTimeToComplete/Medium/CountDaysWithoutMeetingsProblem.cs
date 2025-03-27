using System.Collections.Immutable;

namespace LeetCodeSolutions.Medium;

/***
URL: https://leetcode.com/problems/count-days-without-meetings/description

You are given a positive integer days representing the total number of days an employee is available for work (starting from day 1). You are also given a 2D array meetings of size n where, meetings[i] = [start_i, end_i] represents the starting and ending days of meeting i (inclusive).

Return the count of days when the employee is available for work but no meetings are scheduled.

Note: The meetings may overlap.

Example 1:

Input: days = 10, meetings = [[5,7],[1,3],[9,10]]

Output: 2

Explanation:

There is no meeting scheduled on the 4th and 8th days.

Example 2:

Input: days = 5, meetings = [[2,4],[1,3]]

Output: 1

Explanation:

There is no meeting scheduled on the 5th day.

Example 3:

Input: days = 6, meetings = [[1,6]]

Output: 0

Explanation:

Meetings are scheduled for all working days.

Constraints:

1 <= days <= 109
1 <= meetings.length <= 105
meetings[i].length == 2
1 <= meetings[i][0] <= meetings[i][1] <= days
 */
public class CountDaysWithoutMeetingsProblem
{
    public int CountDays(int days, int[][] meetings)
    {
        var shortenedMeetings = new List<int[]>();
        var orderedMeetings = meetings.OrderBy(meeting => meeting[0]).ToImmutableArray();

        shortenedMeetings.Add(orderedMeetings[0]);

        for (var i = 1; i < orderedMeetings.Length; i++)
        {
            var latestMeeting = shortenedMeetings[^1][1];

            // There is definetly no overlap in this scenario e.g. [4,5] > [1,2]
            if (orderedMeetings[i][0] > latestMeeting + 1) // Will skip scenario [3,4] > [1,2] => [1,4]
            {
                shortenedMeetings.Add(orderedMeetings[i]);
                continue;
            }

            // Handles scenario [2,3] > [1,2] => [1,3]
            if (orderedMeetings[i][1] > latestMeeting)
            {
                shortenedMeetings[^1][1] = orderedMeetings[i][1];
            }
        }

        var meetingDays = shortenedMeetings.Sum(x => 1 + x[1] - x[0]);

        return days - meetingDays;
    }

    public int CountDays1(int days, int[][] meetings)
    {
        var daysWithMeetings = new bool[days];

        foreach (var meeting in meetings)
        {
            for (var i = meeting[0] - 1; i <= meeting[1] - 1; i++)
            {
                daysWithMeetings[i] = true;
            }
        }

        var daysWithoutMeetings = daysWithMeetings.Where(isMeetingDay => !isMeetingDay);

        return daysWithoutMeetings.Count();
    }
}
