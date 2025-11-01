namespace LeetCodeSolutions._1000._400._80;

/***
URL: https://leetcode.com/problems/avoid-flood-in-the-city
Number: 1488
Difficulty: Medium
 */
public class AvoidFloodinTheCity
{
    public int[] AvoidFlood(int[] rains)
    {
        var result = new int[rains.Length];
        var lakeToNextRain = new Dictionary<int, Queue<int>>();

        // Build future rain schedule for each lake
        for (var i = 0; i < rains.Length; i++)
        {
            var rain = rains[i];

            if (rain > 0)
            {
                if (!lakeToNextRain.ContainsKey(rain))
                {
                    lakeToNextRain[rain] = new Queue<int>();
                    lakeToNextRain[rain].Enqueue(0);
                }

                lakeToNextRain[rain].Enqueue(i);
            }
        }

        var fullLakes = new HashSet<int>();
        var dryDays = new SortedSet<int>();

        for (var i = 0; i < rains.Length; i++)
        {
            var rain = rains[i];

            if (rain == 0)
            {
                dryDays.Add(i);
                result[i] = 1;

                continue;
            }

            // Remove this rain day from future queue
            var lastFilled = lakeToNextRain[rain].Dequeue();

            if (fullLakes.Contains(rain))
            {
                var validDryDay = false;

                foreach (var dryDay in dryDays)
                {
                    if (dryDay > i)
                    {
                        break;
                    }

                    if (dryDay < lastFilled)
                    {
                        continue;
                    }

                    result[dryDay] = rain;
                    dryDays.Remove(dryDay);
                    validDryDay = true;

                    break;
                }

                if (!validDryDay)
                {
                    return [];
                }
            }

            fullLakes.Add(rain);
            result[i] = -1;
        }

        return result;
    }
}
