namespace LeetCodeSolutions._0._700._90;

public class CountCompleteSubarraysInAnArrayProblem
{
    public int CountCompleteSubarrays(int[] nums)
    {
        var numOfDistinctElements = nums.Distinct().Count();
        var numOfFoundElements = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var thisList = new HashSet<int>() { nums[i] };
            var j = i + 1;

            while (j < nums.Length && numOfDistinctElements != thisList.Count)
            {
                if (!thisList.Contains(nums[j]))
                {
                    thisList.Add(nums[j]);
                }

                j++;
            }

            if (thisList.Count != numOfDistinctElements)
            {
                return numOfFoundElements;
            }

            numOfFoundElements += nums.Length - j + 1;
        }

        return numOfFoundElements;
    }
}
