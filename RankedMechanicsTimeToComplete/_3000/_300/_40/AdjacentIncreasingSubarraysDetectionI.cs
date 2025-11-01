namespace LeetCodeSolutions._3000._300._40;

/***
URL: https://leetcode.com/problems/adjacent-increasing-subarrays-detection-i
Number: 3349
Difficulty: Easy
 */
public class AdjacentIncreasingSubarraysDetectionI
{
    public bool HasIncreasingSubarrays(IList<int> nums, int k)
    {
        if (k == 1)
        {
            return true;
        }

        var currentList = new List<int>()
        {
            nums[0]
        };
        var foundLists = new List<int>();

        for (var i = 1; i < nums.Count; i++)
        {
            if (currentList[^1] >= nums[i])
            {
                currentList = new List<int>();
                currentList.Add(nums[i]);
                continue;
            }

            currentList.Add(nums[i]);

            if (currentList.Count == k)
            {
                foundLists.Add(i - k);
                currentList.RemoveAt(0);
            }
        }

        for (var i = 0; i < foundLists.Count - 1; i++)
        {
            if (foundLists.Contains(foundLists[i] + k))
            {
                return true;
            }
        }

        return false;
    }
}
