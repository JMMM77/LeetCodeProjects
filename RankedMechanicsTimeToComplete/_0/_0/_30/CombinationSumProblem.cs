namespace LeetCodeSolutions._0._0._30;

/***
URL: https://leetcode.com/problems/combination-sum
Number: 39
Difficulty: Medium
 */
public class CombinationSumProblem
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        Array.Sort(candidates);

        var result = new List<IList<int>>();

        CombinationSearch(0, target, [], candidates, result);

        return result;
    }

    public void CombinationSearch(int startIndex, int remainingTarget, List<int> currentCombination, int[] candidates, IList<IList<int>> result)
    {
        if (remainingTarget == 0)
        {
            result.Add([.. currentCombination]);

            return;
        }

        if (remainingTarget < 0)
        {
            return;
        }

        for (var i = startIndex; i < candidates.Length; i++)
        {
            if (candidates[i] > remainingTarget)
            {
                break;
            }

            currentCombination.Add(candidates[i]);

            CombinationSearch(i, remainingTarget - candidates[i], currentCombination, candidates, result);

            currentCombination.RemoveAt(currentCombination.Count - 1);
        }
    }
}
