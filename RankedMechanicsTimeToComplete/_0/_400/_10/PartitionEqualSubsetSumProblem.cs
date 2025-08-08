namespace LeetCodeSolutions._0._400._10;

/***
URL: https://leetcode.com/problems/partition-equal-subset-sum
Number: 416
Difficulty: Medium
 */
public class PartitionEqualSubsetSumProblem
{
    public bool CanPartition(int[] nums)
    {
        var total = nums.Sum();

        if (total % 2 == 1)
        {
            return false;
        }

        HashSet<int> subsets = [0];
        var halfTotal = total / 2;

        for (var i = 0; i < nums.Length; i++)
        {
            var tempNewSubset = new HashSet<int>(subsets);

            foreach (var val in tempNewSubset)
            {
                var newVal = val + nums[i];

                if (subsets.Contains(newVal))
                {
                    continue;
                }

                if (newVal == halfTotal)
                {
                    return true;
                }
                else if (newVal < halfTotal)
                {
                    subsets.Add(newVal);
                }
            }
        }

        return false;
    }

    // Out of memory
    public bool CanPartition2(int[] nums)
    {
        var total = nums.Sum();

        if (total % 2 == 1)
        {
            return false;
        }

        List<int[]> subsets = [];

        for (var i = 0; i < nums.Length; i++)
        {
            List<IEnumerable<int>> tempSubset = [];
            var initialSubsetCount = subsets.Count;

            for (var j = 0; j < initialSubsetCount; j++)
            {
                tempSubset.Add(subsets[j].Append(nums[i]));
            }

            subsets.Add([nums[i]]);

            if (tempSubset.Count > 0)
            {
                subsets.AddRange(tempSubset.Select(x => x.ToArray()));
            }
        }

        var halfTotal = total / 2;

        return subsets.Any(x => x.Sum() == halfTotal && nums.Except(x).Sum() == halfTotal);
    }

    // Too slow
    public bool CanPartition1(int[] nums)
    {
        var total = nums.Sum();

        if (total % 2 == 1)
        {
            return false;
        }

        var totalPowerSet = Math.Pow(2, nums.Length);
        var halfTotal = total / 2;

        for (var mask = 0; mask < totalPowerSet; mask++)
        {
            var subsetTotal = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                // Check if the i-th bit in mask is set
                if ((mask & (1 << i)) != 0)
                {
                    subsetTotal += nums[i]; // Include nums[i] in subset
                }
            }

            if (subsetTotal == halfTotal)
            {
                return true;
            }
        }

        return false;
    }
}
