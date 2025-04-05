namespace LeetCodeSolutions._0._0._10;

/***
URL: https://leetcode.com/problems/3sum/description/
Number: 15
Difficulty: Medium
 */
public class _3SumProblem
{
    // Better solution (Locking i instead of K)
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var foundCombinationsList = new List<IList<int>>();
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

                if (potentialSolution > 0)
                {
                    rightPointer--;
                }
                else if (potentialSolution < 0)
                {
                    leftPointer++;
                }
                else
                {
                    foundCombinationsList.Add([iNum, leftNum, rightNum]);
                    leftPointer++;

                    while (nums[leftPointer] == nums[leftPointer - 1] && leftPointer < rightPointer) // Same thing, no need to calculate the same value since rightPointer and i cant/wont change
                    {
                        leftPointer++;
                    }
                }
            }
        }

        return foundCombinationsList;
    }

    // My way which does work but only beats 9%
    public IList<IList<int>> ThreeSum1(int[] nums)
    {
        var foundCombinations = new HashSet<(int, int, int)>();
        var foundCombinationsList = new List<IList<int>>();
        var orderedNums = nums.Order().ToArray();
        var previousKNum = orderedNums[2] - 1;
        var recurrence = 0;

        for (var k = 2; k < orderedNums.Length; k++)
        {
            var kNum = orderedNums[k];

            if (previousKNum == kNum && recurrence > 2)
            {
                continue;
            }
            else if (previousKNum != kNum && recurrence > 0)
            {
                recurrence = 0;
            }
            else
            {
                recurrence++;
            }

            previousKNum = kNum;

            var numToCompareTo = kNum * -1;
            var jPointer = k - 1;

            for (var i = 0; i < jPointer; i++)
            {
                var currentCombo = 0;
                var iNum = orderedNums[i];

                for (var j = jPointer; i < j; j--)
                {
                    var jNum = orderedNums[j];
                    currentCombo = iNum + jNum;

                    if (currentCombo < numToCompareTo) // No point decreasing j if the combo is already smaller than k
                    {
                        break;
                    }

                    if (currentCombo == numToCompareTo && !foundCombinations.Contains((iNum, jNum, kNum)))
                    {
                        foundCombinations.Add((iNum, jNum, kNum));
                        foundCombinationsList.Add([iNum, jNum, kNum]);
                    }
                }

                if (currentCombo > numToCompareTo) // No point increasing i if the combo is already bigger than k
                {
                    break;
                }
            }
        }

        return foundCombinationsList;
    }
}
