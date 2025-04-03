namespace LeetCodeSolutions._0._0._0;

/***
URL: https://leetcode.com/problems/two-sum/
Topics: Array, Hash Table
Number: 1
Difficulty: Easy
 */
public class TwoSumProblem
{
    public int[] TwoSum(int[] nums, int target)
    {
        // Learning hash maps
        var map = new Dictionary<int, int>();

        // Combines the step of creating the hash map and finding its complement
        for (var i = 0; i < nums.Length; i++)
        {
            var complement = target - nums[i];
            if (map.ContainsKey(complement))
            {
                return new int[] { map[complement], i };
            }
            map[nums[i]] = i;
        }

        return [];
    }
}
