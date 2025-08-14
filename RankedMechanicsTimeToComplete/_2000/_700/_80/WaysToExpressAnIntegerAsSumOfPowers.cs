namespace LeetCodeSolutions._2000._700._80;

/***
URL: https://leetcode.com/problems/ways-to-express-an-integer-as-sum-of-powers
Number: 2787
Difficulty: Medium
 */
public class WaysToExpressAnIntegerAsSumOfPowers
{
    private static readonly int MODULO = (int)Math.Pow(10, 9) + 7;

    public int NumberOfWays(int n, int x)
    {
        var availablePowers = new List<int>();

        for (var i = 1; ; i++)
        {
            var currentNum = (int)Math.Pow(i, x);

            if (currentNum > n)
            {
                break;
            }

            availablePowers.Add(currentNum);
        }

        var cacheList = new Dictionary<(int index, int sum), int>();

        return BranchAvailableCombinations(0, 0, n, availablePowers, cacheList);
    }

    private int BranchAvailableCombinations(int currentIndex, int currentSum, int numToCheck, List<int> powers, Dictionary<(int, int), int> mainList)
    {
        if (currentSum == numToCheck)
        {
            return 1;
        }

        if (currentSum > numToCheck || currentIndex == powers.Count)
        {
            return 0;
        }

        var key = (currentIndex, currentSum);
        if (mainList.TryGetValue(key, out var alreadyFound))
        {
            return alreadyFound;
        }

        // Don't take current index
        var numOfWays = BranchAvailableCombinations(currentIndex + 1, currentSum, numToCheck, powers, mainList);

        // Take current index
        numOfWays = (numOfWays + BranchAvailableCombinations(currentIndex + 1, currentSum + powers[currentIndex], numToCheck, powers, mainList)) % MODULO; // Get Modulod answer

        mainList[key] = numOfWays;

        return numOfWays;
    }
}
