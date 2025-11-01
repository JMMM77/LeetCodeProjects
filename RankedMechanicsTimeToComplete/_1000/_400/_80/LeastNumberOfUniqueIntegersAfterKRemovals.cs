namespace LeetCodeSolutions._1000._400._80;

/***
URL: https://leetcode.com/problems/least-number-of-unique-integers-after-k-removals
Number: 1481
Difficulty: Medium
 */

public class LeastNumberOfUniqueIntegersAfterKRemovals
{
    public int FindLeastNumOfUniqueInts(int[] arr, int k)
    {
        var foundNums = new Dictionary<int, int>();

        foreach (var num in arr)
        {
            if (!foundNums.TryGetValue(num, out var value))
            {
                value = 0;
                foundNums.Add(num, value);
            }

            foundNums[num]++;
        }

        var numList = new List<int>();
        var numOfUniqueNums = 0;

        foreach (var num in foundNums.Values)
        {
            numList.Add(num);
            numOfUniqueNums++;
        }

        numList.Sort();

        for (var i = 0; i < numList.Count && k > 0; i++)
        {
            if (numList[i] > k)
            {
                break;
            }

            k -= numList[i];
            numOfUniqueNums--;
        }

        return numOfUniqueNums;
    }
}
