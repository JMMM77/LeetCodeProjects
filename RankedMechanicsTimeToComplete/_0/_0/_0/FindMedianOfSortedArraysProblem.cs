namespace LeetCodeSolutions._0._0._0;

/***
URL: https://leetcode.com/problems/median-of-two-sorted-arrays
Topics: Array, Binary Search, Divide and Conquer
Number: 4
Difficulty: Hard
*/
public class FindMedianOfSortedArraysProblem
{
    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var sortedArray = nums1.Concat(nums2).OrderBy(x => x).ToArray();
        var arrayLength = sortedArray.Length;

        if (arrayLength % 2 == 0)
        {
            // Half of even number returns the index of the element on the right side of the middle, so we need to subtract 1 to get the left one
            return (double)(sortedArray[arrayLength / 2 - 1] + sortedArray[arrayLength / 2]) / 2;
        }

        // Half of odd number returns the index of the middle element
        return sortedArray[arrayLength / 2];
    }
}
