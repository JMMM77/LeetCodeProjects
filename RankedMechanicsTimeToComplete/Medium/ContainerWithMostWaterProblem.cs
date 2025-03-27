namespace LeetCodeSolutions.Medium;
/***
URL: https://leetcode.com/problems/container-with-most-water/description/

You are given an integer array leftHeight of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, leftHeight[i]).

Find two lines that together with the x-axis form a container, such that the container contains the most water.

Return the maximum amount of water a container can store.

Notice that you may not slant the container.

Example 1:

Input: leftHeight = [1,8,6,2,5,4,8,3,7]
Output: 49
Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.
Example 2:

Input: leftHeight = [1,1]
Output: 1
 
Constraints:

n == leftHeight.length
2 <= n <= 105
0 <= leftHeight[i] <= 104
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
