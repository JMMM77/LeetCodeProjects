namespace LeetCodeSolutions._2000._700._80;

/***
URL: https://leetcode.com/problems/minimum-index-of-a-valid-split/description
Number: 2780
Difficulty: Medium
 */

public class MinimumIndexOfAValidSplitProblem
{
    public int MinimumIndex(IList<int> nums)
    {
        var numOfElements = nums.Count;
        var leftMap = new Dictionary<int, int>();
        var rightMap = new Dictionary<int, int>();

        // Add all elements of nums to the right map
        foreach (var num in nums)
        {
            if (rightMap.ContainsKey(num))
            {
                rightMap[num]++;
                continue;
            }

            leftMap.Add(num, 0);
            rightMap.Add(num, 1);
        }

        // Check each potential split and see if any splits have the same dominant element
        for (var index = 0; index < numOfElements; index++)
        {
            // Create split at current index
            var num = nums[index];
            leftMap[num]++;
            rightMap[num]--;

            // Check if valid split
            if (leftMap[num] * 2 > index + 1 &&
                rightMap[num] * 2 > numOfElements - index - 1)
            {
                return index;
            }
        }

        return -1;
    }

    public int MinimumIndex1(IList<int> nums)
    {
        var numsOfElementsInMainArray = nums.Count;

        // Get all the numbers and their respective indexes
        var numsAndRespectiveIndexes = new Dictionary<int, List<int>>
        {
            { nums[0], [0] } // The first number at the first index
        };

        for (var i = 1; i < numsOfElementsInMainArray; i++)
        {
            var currentValue = nums[i];

            if (numsAndRespectiveIndexes.ContainsKey(currentValue))
            {
                numsAndRespectiveIndexes[currentValue].Add(i);
                continue;
            }

            numsAndRespectiveIndexes.Add(currentValue, [i]);
        }

        // Get the indexes of the most dominant number
        var allKeys = numsAndRespectiveIndexes.Keys;
        var dominantDictionaryValue = numsAndRespectiveIndexes[allKeys.FirstOrDefault()];

        for (var i = 1; i < numsAndRespectiveIndexes.Count; i++)
        {
            var potentialMoreDominantValue = numsAndRespectiveIndexes[allKeys.ElementAt(i)];

            if (dominantDictionaryValue.Count < potentialMoreDominantValue.Count)
            {
                dominantDictionaryValue = potentialMoreDominantValue;
            }
        }

        var numOfIndexes = dominantDictionaryValue.Count;

        // Its not possible for a value that does not take up more than half the array to be dominant
        if (numOfIndexes < numsOfElementsInMainArray / 2) return -1;

        // Finding split where the values would still be dominant
        for (var indexOfSplit = dominantDictionaryValue[0]; indexOfSplit < numsOfElementsInMainArray - 1; indexOfSplit++)
        {
            var numOfElemsOnLeftSide = indexOfSplit + 1;
            var numOfElemsOnRightSide = numsOfElementsInMainArray - numOfElemsOnLeftSide;
            var domIndexedOnLeftSplit = dominantDictionaryValue.Count(x => x <= indexOfSplit); // Get all elements to the left of the split
            var domIndexedOnRightSplit = numOfIndexes - domIndexedOnLeftSplit; // Get all elements to the left of the split

            if (domIndexedOnLeftSplit * 2 > numOfElemsOnLeftSide && domIndexedOnRightSplit * 2 > numOfElemsOnRightSide) return indexOfSplit; // Found a split
        }

        return -1;
    }
}
