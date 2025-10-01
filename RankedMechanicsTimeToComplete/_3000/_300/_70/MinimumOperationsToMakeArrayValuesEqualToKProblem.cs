namespace LeetCodeSolutions._3000._300._70;

/***
URL: https://leetcode.com/problems/minimum-operations-to-make-array-Values-equal-to-k
Number: 3375
Difficulty: Easy
 */
public class MinimumOperationsToMakeArrayValuesEqualToKProblem
{
    public int MinOperations(int[] nums, int k)
    {
        var sortedSet = new HashSet<int>();

        foreach (var num in nums)
        {
            if (num < k) // No point calculating further since its impossible to get k
            {
                return -1;
            }

            sortedSet.Add(num);
        }

        if (sortedSet.Contains(k))
        {
            return sortedSet.Count - 1;
        }

        return sortedSet.Count;
    }
}
