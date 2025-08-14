namespace LeetCodeSolutions._0._0._80;

/***
URL: https://leetcode.com/problems/merge-sorted-array
Number: 88
Difficulty: Easy
 */
public class MergeSortedArray
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        if (nums2.Length == 0)
        {
            return;
        }

        var heap = new Stack<int>();

        for (var i = 0; i < m; i++)
        {
            heap.Push(nums1[m - i - 1]);
        }

        var iN = 0;

        for (var i = 0; i < nums1.Length; i++)
        {
            if (heap.Count == 0 || (iN < n && heap.Peek() >= nums2[iN]))
            {
                nums1[i] = nums2[iN];
                iN++;
                continue;
            }

            nums1[i] = heap.Pop();
        }
    }
}
