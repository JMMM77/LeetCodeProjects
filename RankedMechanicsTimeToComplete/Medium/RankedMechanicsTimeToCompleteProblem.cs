namespace LeetCodeSolutions.Medium;

/***
URL: https://leetcode.com/problems/minimum-time-to-repair-cars
Topics: Array, Binary Search

You are given an integer array ranks representing the ranks of some mechanics. ranksi is the rank of the ith mechanic. A mechanic with a rank r can repair n minCars in r * n2 minutes.

You are also given an integer minCars representing the total number of minCars waiting in the garage to be repaired.

Return the minimum time taken to repair all the minCars.

Note: All the mechanics can repair the minCars simultaneously.

Example 1:

Input: ranks = [4,2,3,1], minCars = 10
Output: 16
Explanation: 
- The first mechanic will repair two minCars. The time required is 4 * 2 * 2 = 16 minutes.
- The second mechanic will repair two minCars. The time required is 2 * 2 * 2 = 8 minutes.
- The third mechanic will repair two minCars. The time required is 3 * 2 * 2 = 12 minutes.
- The fourth mechanic will repair four minCars. The time required is 1 * 4 * 4 = 16 minutes.
It can be proved that the minCars cannot be repaired in less than 16 minutes.​​​​​
Example 2:

Input: ranks = [5,1,8], minCars = 6
Output: 16
Explanation: 
- The first mechanic will repair one car. The time required is 5 * 1 * 1 = 5 minutes.
- The second mechanic will repair four minCars. The time required is 1 * 4 * 4 = 16 minutes.
- The third mechanic will repair one car. The time required is 8 * 1 * 1 = 8 minutes.
It can be proved that the minCars cannot be repaired in less than 16 minutes.​​​​​
 

Constraints:

1 <= ranks.length <= 105
1 <= ranks[i] <= 100
1 <= minCars <= 106
 */

/// <summary>
/// Second attempt, via binary search
/// </summary>
public class RankedMechanicsTimeToComplete2
{
    public static long RepairCars(int[] ranks, int cars)
    {
        long minTime = ranks.Min();
        var maxTime = minTime * cars * cars;
        var timeToCheckIsFeasible = (maxTime + minTime) / 2;

        var solutionFound = false;

        while (!solutionFound)
        {
            if (minTime == maxTime)
            {
                break;
            }

            var numOfCars = NumberOfFeasibleCars(ranks, timeToCheckIsFeasible, cars);
            if (numOfCars < cars)
            {
                if (minTime == timeToCheckIsFeasible)
                {
                    timeToCheckIsFeasible++;
                    minTime = timeToCheckIsFeasible;
                }
                else
                {
                    minTime = timeToCheckIsFeasible;
                    timeToCheckIsFeasible = (maxTime + minTime) / 2;
                }
            }
            else
            {
                if (timeToCheckIsFeasible == maxTime)
                {
                    timeToCheckIsFeasible--;
                    maxTime = timeToCheckIsFeasible;
                }
                else
                {
                    maxTime = timeToCheckIsFeasible;
                    timeToCheckIsFeasible = (maxTime + minTime) / 2;
                }
            }
        }

        return timeToCheckIsFeasible;
    }

    /// <summary>
    /// Returns the minimum amount of minCars that the mechanics can do in the given time
    /// </summary>
    private static int NumberOfFeasibleCars(int[] ranks, long time, long minCars)
    {
        var cars = 0;

        foreach (var rank in ranks)
        {
            cars += (int)Math.Sqrt(time / rank);

            if (cars > minCars)
            {
                return cars;
            }
        }

        return cars;
    }
}

/// <summary>
/// First attempt via brute force, works but not efficient and breaks easily with large numbers
/// </summary>
public class RankedMechanicsTimeToComplete
{
    public static long RepairCars(int[] ranks, int cars)
    {
        var numOfMechanics = ranks.Length;
        var mechanics = new Mechanic[numOfMechanics];

        for (var i = 0; i < numOfMechanics; i++)
        {
            mechanics[i] = new Mechanic(ranks[i]);
        }

        for (var i = 0; i < cars; i++)
        {
            // Test giving it to first mechanic
            var mechanicToGiveCar = 0;
            var quickestTime = mechanics[0].TimeTakenWithExtraCar;

            // See if any mechanics would finish it faster
            for (var x = 1; x < numOfMechanics; x++)
            {
                var nextMechanicTime = mechanics[x].TimeTakenWithExtraCar;

                if (quickestTime > nextMechanicTime)
                {
                    mechanicToGiveCar = x;
                    quickestTime = nextMechanicTime;
                }
            }

            mechanics[mechanicToGiveCar].NumOfCars++;
            mechanics[mechanicToGiveCar].TimeTaken = quickestTime;
            mechanics[mechanicToGiveCar].TimeTakenWithExtraCar = mechanics[mechanicToGiveCar].TimeWithExtraCar();
        }

        var test = Enumerable.Empty<string>();
        var test2 = mechanics.OrderBy(x => x.NumOfCars);
        foreach (var mechanic in test2)
        {
            test = test.Append($"Rank: {mechanic.Rank}, NumOfCars: {mechanic.NumOfCars}, TimeTaken: {mechanic.TimeTaken}, Actual Calc (mechanic.Rank * mechanic.NumOfCars * mechanic.NumOfCars): {mechanic.Rank * mechanic.NumOfCars * mechanic.NumOfCars}, TimeTakenWithExtraCar: {mechanic.TimeTakenWithExtraCar}");
        }

        return mechanics.Max(x => (long)x.TimeTaken);
    }

    public class Mechanic(int rank)
    {
        public int Rank { get; set; } = rank;
        public int NumOfCars { get; set; } = 0;
        public double TimeTaken { get; set; } = 0;
        public double TimeTakenWithExtraCar { get; set; } = rank;
        public double TimeWithExtraCar()
        {
            var extraCar = NumOfCars + 1;
            var calc = Rank * (double)extraCar * extraCar;

            return calc;
        }
    }
}
