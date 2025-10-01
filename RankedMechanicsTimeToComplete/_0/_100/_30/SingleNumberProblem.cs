namespace LeetCodeSolutions._0._100._30;

/***
URL: https://leetcode.com/problems/single-number
Number: 136
Difficulty: Easy
 */
public class SingleNumberProblem
{
    public int SingleNumber(int[] nums)
    {
        var result = 0;

        foreach (var n in nums)
        {
            result ^= n; // XOR to cancel out previously found Values
        }

        return result;
    }

    public int SingleNumberOld(int[] nums)
    {
        var foundNumbers = new HashSet<int>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (foundNumbers.Contains(nums[i]))
            {
                foundNumbers.Remove(nums[i]);

                continue;
            }

            foundNumbers.Add(nums[i]);
        }

        using var enumerator = foundNumbers.GetEnumerator();

        enumerator.MoveNext();

        return enumerator.Current;
    }
}
