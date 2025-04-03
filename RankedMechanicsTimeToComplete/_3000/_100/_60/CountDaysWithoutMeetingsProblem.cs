using System.Collections.Immutable;

namespace LeetCodeSolutions._3000._100._60;

/***
URL: https://leetcode.com/problems/count-days-without-meetings/description
Number: 3169
Difficulty: Medium
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
