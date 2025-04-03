namespace LeetCodeSolutions._0._0._10;

/***
URL: https://leetcode.com/problems/container-with-most-water/description/
Number: 11
Difficulty: Medium
 */
public class ContainerWithMostWaterProblem
{
    public int MaxArea(int[] heights)
    {
        // Keep track of the index and height
        var sortedHeights = new SortedSet<(int, int)>(); // Sort by height to be able to review it top to bottom

        for (var i = 0; i < heights.Length; i++)
        {
            sortedHeights.Add((heights[i], i));
        }

        // Get the 2 biggest numbers and their left and right indexes
        var (leftHeight, leftIndex) = sortedHeights.Max;
        sortedHeights.Remove(sortedHeights.Max);

        var (rightHeight, rightIndex) = sortedHeights.Max;
        sortedHeights.Remove(sortedHeights.Max);

        var difference = rightIndex - leftIndex;
        var smallerInitialHeight = rightHeight;

        if (difference < 0)
        {
            (rightIndex, leftIndex) = (leftIndex, rightIndex);
            (rightHeight, leftHeight) = (leftHeight, rightHeight);
            difference *= -1;
        }

        var currentBiggestContainer = difference * smallerInitialHeight;
        var furthestLeftIndex = leftIndex;
        var furthestRightIndex = rightIndex;

        while (sortedHeights.Count != 0)
        {
            var (newHeight, newIndex) = sortedHeights.Max;
            sortedHeights.Remove(sortedHeights.Max);

            if (leftIndex < newIndex && newIndex < rightIndex)
            {
                continue; // If its in between the height is smaller and the difference would be smaller so skip
            }

            int potentialBiggestContainer;
            int potentialBiggestContainerWithFurthestIndex;

            if (furthestLeftIndex > newIndex)
            {
                furthestLeftIndex = newIndex;
            }
            else if (furthestRightIndex < newIndex)
            {
                furthestRightIndex = newIndex;
            }

            potentialBiggestContainerWithFurthestIndex = (furthestRightIndex - furthestLeftIndex) * newHeight;

            var isNewLeftSide = false;
            var isUsingBiggestRangeValues = false;

            if (leftIndex > newIndex)
            {
                potentialBiggestContainer = (rightIndex - newIndex) * newHeight;
                isNewLeftSide = true;
            }
            else
            {
                potentialBiggestContainer = (newIndex - leftIndex) * newHeight;
            }

            if (potentialBiggestContainer < potentialBiggestContainerWithFurthestIndex)
            {
                potentialBiggestContainer = potentialBiggestContainerWithFurthestIndex;
                isUsingBiggestRangeValues = true;
            }

            if (potentialBiggestContainer < currentBiggestContainer && potentialBiggestContainerWithFurthestIndex < currentBiggestContainer)
            {
                continue;
            }

            currentBiggestContainer = potentialBiggestContainer;

            if (isUsingBiggestRangeValues)
            {
                leftIndex = furthestLeftIndex;
                rightIndex = furthestRightIndex;
            }
            else if (isNewLeftSide)
            {
                leftIndex = newIndex;
            }
            else
            {
                rightIndex = newIndex;
            }
        }

        return currentBiggestContainer;
    }

    // Causes timeout on long heights
    public int MaxArea1(int[] height)
    {
        var currentBiggestContainer = 0; // Area = (rightIndex - leftIndex) * minHeight
        var lastIndex = height.Length - 1;
        var maxValueIndex = Array.IndexOf(height, height.Max()); // Used to bail early as going closer to the other pointer would only make the container smaller

        for (var leftIndex = 0; leftIndex <= maxValueIndex; leftIndex++)
        {
            for (var rightIndex = lastIndex; rightIndex >= maxValueIndex; rightIndex--)
            {
                var leftHeight = height[leftIndex];
                var rightHeight = height[rightIndex];
                var potentialNewBiggestContainer = (rightIndex - leftIndex) * (leftHeight < rightHeight ? leftHeight : rightHeight);

                if (potentialNewBiggestContainer > currentBiggestContainer)
                {
                    currentBiggestContainer = potentialNewBiggestContainer;
                }
            }
        }

        return currentBiggestContainer;
    }
}
