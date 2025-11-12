namespace LeetCodeSolutions._0._0._40;

/***
URL: https://leetcode.com/problems/combination-sum-ii
Number: 40
Difficulty: Medium
 */
public class CombinationSumII
{
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        Array.Sort(candidates);

        var results = new List<IList<int>>();
        var current = new List<int>();

        Backtrack(candidates, target, 0, current, results);

        return results;
    }

    private void Backtrack(int[] candidates, int target, int start, List<int> current, List<IList<int>> results)
    {
        if (target == 0)
        {
            results.Add([.. current]);
            return;
        }

        for (var i = start; i < candidates.Length; i++)
        {
            if (i > start && candidates[i] == candidates[i - 1])
            {
                continue; // skip duplicates
            }

            var num = candidates[i];

            if (num > target)
            {
                break; // no need to continue since array is sorted
            }

            current.Add(num);

            Backtrack(candidates, target - num, i + 1, current, results);

            current.RemoveAt(current.Count - 1);
        }
    }
}
