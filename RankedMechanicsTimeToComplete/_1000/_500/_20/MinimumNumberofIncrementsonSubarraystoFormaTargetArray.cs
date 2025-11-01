namespace LeetCodeSolutions._1000._500._20;

/***
URL: https://leetcode.com/problems/minimum-number-of-increments-on-subarrays-to-form-a-target-array
Number: 1526
Difficulty: Hard
 */
public class MinimumNumberofIncrementsonSubarraystoFormaTargetArray
{
    public int MinNumberOperations(int[] target)
    {
        var n = target.Length;
        var returnVal = target[0];

        for (var i = 1; i < n; ++i)
        {
            returnVal += Math.Max(target[i] - target[i - 1], 0);
        }

        return returnVal;
    }

    public int MinNumberOperations1(int[] target)
    {
        var returnVal = 0;
        var numToSplit = 0;
        var splitValues = new List<List<int>>() { target.ToList() };

        while (splitValues.Count > 0)
        {
            var newSplitValues = new List<List<int>>();

            for (var i = 0; i < splitValues.Count; i++)
            {
                var thisSplit = new List<int>();

                for (var j = 0; j < splitValues[i].Count; j++)
                {
                    if (splitValues[i][j] <= numToSplit)
                    {
                        if (thisSplit.Count != 0)
                        {
                            newSplitValues.Add(thisSplit);
                            thisSplit = [];
                        }

                        continue;
                    }

                    thisSplit.Add(splitValues[i][j]);
                }

                if (thisSplit.Count != 0)
                {
                    newSplitValues.Add(thisSplit);
                }
            }

            returnVal += newSplitValues.Count;
            splitValues = newSplitValues;
            numToSplit++;
        }

        return returnVal;
    }
}
