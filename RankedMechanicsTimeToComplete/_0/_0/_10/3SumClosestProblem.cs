namespace LeetCodeSolutions._0._0._10;

/***
URL: https://leetcode.com/problems/3sum-closest/
Number: 16
Difficulty: Medium
 */
public class _3SumClosestProblem
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        var closestSolutionFound = 0;
        var smallestDifference = int.MaxValue;

        Array.Sort(nums);

        for (var i = 0; i < nums.Length - 2; i++)
        {
            var iNum = nums[i];

            if (i > 0 && iNum == nums[i - 1]) // If the values the same as the last checked value it must have already found all possible solutions so skip
            {
                continue;
            }

            var leftPointer = i + 1; // i.e. jPointer
            var rightPointer = nums.Length - 1; // i.e. kPointer

            while (leftPointer < rightPointer)
            {
                var leftNum = nums[leftPointer];
                var rightNum = nums[rightPointer];

                var potentialSolution = iNum + leftNum + rightNum;
                var currentDifference = potentialSolution > target ? potentialSolution - target : target - potentialSolution;

                if (smallestDifference > currentDifference)
                {
                    smallestDifference = currentDifference;
                    closestSolutionFound = potentialSolution;
                }

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
                    return target; // Confirmed a valid solution is possible
                }
            }
        }

        return closestSolutionFound;
    }
}
