namespace LeetCodeSolutions._2000._500._90;

/***
URL: https://leetcode.com/problems/minimum-time-to-repair-cars
Number: 2594
Difficulty: Medium
 */
public class MinimumTimeToRepairCarsProblem
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

    public static long RepairCars1(int[] ranks, int cars)
    {
        var numOfMechanics = ranks.Length;
        var mechanics = new Mechanic1[numOfMechanics];

        for (var i = 0; i < numOfMechanics; i++)
        {
            mechanics[i] = new Mechanic1(ranks[i]);
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

    public class Mechanic1(int rank)
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