namespace LeetCodeSolutions._0._300._60;

/***
URL: https://leetcode.com/problems/largest-divisible-subset
Number: 368
Difficulty: Medium
 */
public class LargestDivisibleSubsetProblem
{
    public IList<int> LargestDivisibleSubset(int[] nums)
    {
        Array.Sort(nums);

        var foundValidSubsets = new IList<int>[nums.Length];
        IList<int> biggestSubset = [nums[0]];

        for (var i = nums.Length - 1; i > -1; i--)
        {
            IList<int> thisBiggestSubset = [nums[i]];

            for (var j = nums.Length - 1; i < j; j--)
            {
                if (nums[j] % nums[i] == 0 && foundValidSubsets[j].Count + 1 > thisBiggestSubset.Count)
                {
                    var tempArray = new int[foundValidSubsets[j].Count];
                    foundValidSubsets[j].CopyTo(tempArray, 0);
                    thisBiggestSubset = tempArray.ToList();
                    thisBiggestSubset.Add(nums[i]);
                }
            }

            if (thisBiggestSubset.Count > biggestSubset.Count)
            {
                biggestSubset = thisBiggestSubset;
            }

            foundValidSubsets[i] = thisBiggestSubset;

        }

        return biggestSubset;
    }
}
