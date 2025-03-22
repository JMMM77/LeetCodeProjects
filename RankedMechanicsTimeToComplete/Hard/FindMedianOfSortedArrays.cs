namespace LeetCodeSolutions.Hard;

/***
URL: https://leetcode.com/problems/median-of-two-sorted-arrays
Topics: Array, Binary Search, Divide and Conquer

Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.

The overall run time complexity should be O(log (m+n)).

Example 1:

Input: nums1 = [1, 3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1, 2, 3] and median is 2.
Example 2:

Input: nums1 = [1, 2], nums2 = [3, 4]
Output: 2.50000
Explanation: merged array = [1, 2, 3, 4] and median is (2 + 3) / 2 = 2.5.

Constraints:

nums1.length == m
nums2.length == n
0 <= m <= 1000
0 <= n <= 1000
1 <= m + n <= 2000
-106 <= nums1[i], nums2[i] <= 106
*/
public class FindMedianOfSortedArrays
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
