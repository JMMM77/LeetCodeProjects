namespace LeetCodeSolutions._2000._100._0;

/***
URL: https://leetcode.com/problems/maximum-fruits-harvested-after-at-most-k-steps
Number: 2106
Difficulty: Hard
 */
public class MaximumFruitsHarvestedAfteratMostKSteps
{
    public int MaxTotalFruits(int[][] fruits, int startPos, int k)
    {
        var fruitDict = new SortedList<int, int>();
        var maxLeft = startPos - k;
        var maxRight = startPos + k;

        foreach (var fruit in fruits)
        {
            // position, amount within range
            if (fruit[0] >= maxLeft && fruit[0] <= maxRight)
            {
                fruitDict.Add(fruit[0], fruit[1]);
            }
        }

        if (k == 0)
        {
            if (fruitDict.ContainsKey(startPos))
            {
                return fruitDict[startPos];
            }

            return 0;
        }

        // Build arrays for positions and prefix sums
        var positions = fruitDict.Keys.ToArray();
        var prefixSums = new int[positions.Length + 1];

        for (var i = 0; i < positions.Length; i++)
        {
            prefixSums[i + 1] = prefixSums[i] + fruitDict[positions[i]];
        }

        var result = 0;

        // Sliding window: try walking left first, then right
        for (var leftSteps = 0; leftSteps <= k; leftSteps++)
        {
            var rightSteps = k - 2 * leftSteps;

            if (rightSteps < 0)
            {
                continue;
            }

            result = SlidingWindow(startPos, leftSteps, rightSteps, result, positions, prefixSums);
        }

        // Sliding window: try walking right first, then left
        for (var rightSteps = 0; rightSteps <= k; rightSteps++)
        {
            var leftSteps = k - 2 * rightSteps;

            if (leftSteps < 0)
            {
                continue;
            }

            result = SlidingWindow(startPos, leftSteps, rightSteps, result, positions, prefixSums);
        }

        return result;
    }

    private int SlidingWindow(int startPos, int leftSteps, int rightSteps, int result, int[] positions, int[] prefixSums)
    {
        var leftBound = startPos - leftSteps;
        var rightBound = startPos + rightSteps;

        var leftVal = Array.BinarySearch(positions, leftBound);

        if (leftVal < 0)
        {
            leftVal = ~leftVal;
        }

        var rightVal = Array.BinarySearch(positions, rightBound);

        if (rightVal < 0)
        {
            rightVal = ~rightVal - 1;
        }

        if (leftVal <= rightVal)
        {
            result = Math.Max(result, RangeSum(leftVal, rightVal, prefixSums));
        }

        return result;
    }

    private int RangeSum(int left, int right, int[] prefixSums)
    {
        return prefixSums[right + 1] - prefixSums[left];
    }
}