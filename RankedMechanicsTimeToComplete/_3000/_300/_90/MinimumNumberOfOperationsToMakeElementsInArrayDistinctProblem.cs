namespace LeetCodeSolutions._3000._300._90;

/***
URL: https://leetcode.com/problems/minimum-number-of-operations-to-make-elements-in-array-distinct/description
Number: 3396
Difficulty: Easy
 */
public class MinimumNumberOfOperationsToMakeElementsInArrayDistinctProblem
{
    public int MinimumOperations(int[] nums)
    {
        var maxOps = (nums.Length + 2) / 3; // Round up
        var offset = nums.Length % 3;
        var newSet = new HashSet<int>();

        if (offset > 0)
        {
            for (var i = 0; i < offset; i++)
            {
                if (newSet.Contains(nums[^(i + 1)]))
                {
                    return maxOps;
                }

                newSet.Add(nums[^(i + 1)]);
            }

            maxOps--;
        }

        var ops = maxOps;
        offset += 1;

        for (var i = 0; i < maxOps; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                if (newSet.Contains(nums[^offset]))
                {
                    return ops;
                }

                newSet.Add(nums[^offset]);
                offset++;
            }

            ops--;
        }

        return 0;
    }

    // Works but slow
    public int MinimumOperations1(int[] nums)
    {
        var ops = 0;

        while (nums.Length != (new HashSet<int>(nums)).Count)
        {
            ops++;
            if (nums.Length > 3)
            {
                nums = nums.TakeLast(nums.Length - 3).ToArray();
            }
            else
            {
                nums = [];
            }
        }

        return ops;
    }
}
