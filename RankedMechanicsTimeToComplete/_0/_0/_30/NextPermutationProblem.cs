namespace LeetCodeSolutions._0._0._30;

/***
URL: https://leetcode.com/problems/next-permutation
Number: 31
Difficulty: Medium
 */
public class NextPermutationProblem
{
    public void NextPermutation(int[] nums)
    {
        if (nums.Length == 1)
        {
            return;
        }

        var isAscending = true;
        var index = nums.Length - 1;
        var swapNumber = nums[index];
        var pastNumbers = new List<int>() { nums[index] };

        while (isAscending && index > 0)
        {
            index--;

            if (swapNumber > nums[index])
            {
                isAscending = false;
            }

            swapNumber = nums[index];
            pastNumbers.Add(nums[index]);
        }

        if (isAscending) // Max Permutation
        {
            for (var i = 0; i < nums.Length / 2; i++)
            {
                (nums[nums.Length - i - 1], nums[i]) = (nums[i], nums[nums.Length - i - 1]);
            }

            return;
        }

        var originalPosId = index;
        var foundNextHigher = false;
        pastNumbers.Sort();

        for (var i = 0; i < pastNumbers.Count; i++)
        {
            if (!foundNextHigher && pastNumbers[i] > swapNumber)
            {
                nums[originalPosId] = pastNumbers[i];
                foundNextHigher = true;
                continue;
            }

            index++;
            nums[index] = pastNumbers[i];
        }
    }
}
