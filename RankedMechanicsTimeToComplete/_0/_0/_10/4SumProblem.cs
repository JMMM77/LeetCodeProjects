namespace LeetCodeSolutions._0._0._10;

/***
URL: https://leetcode.com/problems/4sum/description/
Number: 18
Difficulty: Medium
 */
public class _4SumProblem
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        var foundCombinationsList = new List<IList<int>>();
        Array.Sort(nums);

        for (var aIndex = 0; aIndex < nums.Length - 3; aIndex++)
        {
            var aNum = (long)nums[aIndex];

            if (aIndex > 0 && aNum == nums[aIndex - 1]) // If the values the same as the last checked value it must have already found all possible solutions so skip
            {
                continue;
            }

            for (var bIndex = aIndex + 1; bIndex < nums.Length - 2; bIndex++)
            {
                var bNum = nums[bIndex];

                if (bIndex > aIndex + 1 && bNum == nums[bIndex - 1]) // If the values the same as the last checked value it must have already found all possible solutions so skip
                {
                    continue;
                }

                var leftPointer = bIndex + 1; // i.e. jPointer
                var rightPointer = nums.Length - 1; // i.e. kPointer

                while (leftPointer < rightPointer)
                {
                    var leftNum = nums[leftPointer];
                    var rightNum = nums[rightPointer];

                    var potentialSolution = aNum + bNum + leftNum + rightNum;

                    if (potentialSolution > target)
                    {
                        rightPointer--;
                    }
                    else if (potentialSolution < target)
                    {
                        leftPointer++;
                    }
                    else
                    {
                        foundCombinationsList.Add([(int)aNum, bNum, leftNum, rightNum]);
                        leftPointer++;

                        while (nums[leftPointer] == nums[leftPointer - 1] && leftPointer < rightPointer) // Same thing, no need to calculate the same value since rightPointer and aIndex cant/wont change
                        {
                            leftPointer++;
                        }
                    }
                }
            }
        }

        return foundCombinationsList;
    }
}
