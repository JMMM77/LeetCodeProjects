namespace LeetCodeSolutions._3000._500._40;

/***
URL: https://leetcode.com/problems/minimum-operations-to-convert-all-elements-to-zero
Number: 3542
Difficulty: Medium
 */
public class MinimumOperationstoConvertAllElementstoZero
{
    public int MinOperations(int[] nums)
    {
        var s = new List<int>();
        var result = 0;

        foreach (var num in nums)
        {
            while (s.Count > 0 && s[^1] > num)
            {
                s.RemoveAt(s.Count - 1);
            }

            if (num == 0)
            {
                continue;
            }

            if (s.Count == 0 || s[^1] < num)
            {
                result++;
                s.Add(num);
            }
        }

        return result;
    }
}
