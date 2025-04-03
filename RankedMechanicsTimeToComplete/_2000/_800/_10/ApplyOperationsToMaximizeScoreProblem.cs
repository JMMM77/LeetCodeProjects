namespace LeetCodeSolutions._2000._800._10;

/***
URL: https://leetcode.com/problems/apply-operations-to-maximize-score/description
Number: 2818
Difficulty: Hard
 */
public class ApplyOperationsToMaximizeScoreProblem
{
    private const int MOD = 1000000007;

    public int MaximumScore(IList<int> nums, int k)
    {
        var n = nums.Count;
        var primeScores = new int[n];

        // Calculate the prime score for each number in nums
        for (var index = 0; index < n; index++)
        {
            var num = nums[index];

            // Check for prime factors from 2 to sqrt(n)
            for (var factor = 2; factor * factor <= num; factor++)
            {
                if (num % factor == 0)
                {
                    // Increment prime score for each prime factor
                    primeScores[index]++;

                    // Remove all occurrences of the prime factor from num
                    while (num % factor == 0)
                    {
                        num /= factor;
                    }
                }
            }

            // If num is still greater than or equal to 2, it's a prime factor
            if (num >= 2)
            {
                primeScores[index]++;
            }
        }

        // Initialize next and previous dominant index arrays
        var nextDominant = new int[n];
        Array.Fill(nextDominant, n);
        var prevDominant = new int[n];
        Array.Fill(prevDominant, -1);

        // Stack to store indices for monotonic decreasing prime score
        var decreasingPrimeScoreStack = new Stack<int>();

        // Calculate the next and previous dominant indices for each number
        for (var index = 0; index < n; index++)
        {
            while (decreasingPrimeScoreStack.Count > 0
                && primeScores[decreasingPrimeScoreStack.Peek()] < primeScores[index])
            {
                var topIndex = decreasingPrimeScoreStack.Pop();
                nextDominant[topIndex] = index;
            }

            if (decreasingPrimeScoreStack.Count > 0)
            {
                prevDominant[index] = decreasingPrimeScoreStack.Peek();
            }

            decreasingPrimeScoreStack.Push(index);
        }

        // Calculate the number of subarrays in which each element is dominant
        var numOfSubarrays = new long[n];

        for (var index = 0; index < n; index++)
        {
            numOfSubarrays[index] = (long)(nextDominant[index] - index) * (index - prevDominant[index]);
        }

        // Priority queue to process elements in decreasing order of their value
        var processingQueue = new PriorityQueue<(int, int), int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        for (var index = 0; index < n; index++)
        {
            processingQueue.Enqueue((nums[index], index), nums[index]);
        }

        long score = 1;

        // Process elements while there are operations left
        while (k > 0)
        {
            var (num, index) = processingQueue.Dequeue();

            var operations = Math.Min(k, numOfSubarrays[index]);

            score = score * Power(num, operations) % MOD;
            k -= (int)operations;
        }

        return (int)score;
    }

    // Helper function to compute the power of a number modulo MOD
    private long Power(long baseValue, long exponent)
    {
        long res = 1;

        while (exponent > 0)
        {
            if (exponent % 2 == 1)
            {
                res = res * baseValue % MOD;
            }
            baseValue = baseValue * baseValue % MOD;
            exponent /= 2;
        }

        return res;
    }

    public int MaximumScore1(IList<int> nums, int k)
    {
        var numOfNums = nums.Count;
        var primeScores = new Dictionary<int, int>();
        var sortedNums = new SortedDictionary<int, List<int>>();

        // Compute prime scores and group indices by number
        for (var i = 0; i < numOfNums; i++)
        {
            if (!primeScores.ContainsKey(nums[i]))
            {
                primeScores[nums[i]] = GetPrimeScore(nums[i]);
            }
            if (!sortedNums.ContainsKey(nums[i]))
            {
                sortedNums[nums[i]] = new List<int>();
            }
            sortedNums[nums[i]].Add(i);
        }

        long score = 1;
        var operations = k;

        foreach (var kvp in sortedNums.Reverse())
        {
            var value = kvp.Key;
            var indices = kvp.Value;
            var primeScore = primeScores[value];

            foreach (var index in indices)
            {
                int numOnLeft = 1, numOnRight = 1;

                for (var i = index - 1; i >= 0 && primeScore > primeScores[nums[i]] && operations > 0; i--)
                {
                    numOnLeft++;
                    operations--;
                }

                for (var i = index + 1; i < numOfNums && primeScore >= primeScores[nums[i]] && operations > 0; i++)
                {
                    numOnRight++;
                    operations--;
                }

                var numOfOps = numOnLeft * numOnRight;
                operations -= numOfOps - (numOnLeft + numOnRight - 2);
                var numOfOpsUsed = Math.Min(numOfOps, numOfOps + operations);

                for (var i = 0; i < numOfOpsUsed; i++)
                {
                    score = score * value % MOD;
                }

                if (operations <= 0) return (int)score;
            }
        }

        return (int)score;
    }

    // Get the number of distinct prime factors
    private int GetPrimeScore(int num)
    {
        var numOfPrimeFactors = 0;

        if (num % 2 == 0)
        {
            numOfPrimeFactors++;
            while (num % 2 == 0) num /= 2;
        }

        for (var i = 3; i * i <= num; i += 2) // No need to process even numbers anymore
        {
            if (num % i == 0)
            {
                numOfPrimeFactors++;
                while (num % i == 0) num /= i;
            }
        }

        if (num > 1) numOfPrimeFactors++;

        return numOfPrimeFactors;
    }
}
