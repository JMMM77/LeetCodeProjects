namespace LeetCodeSolutions._0._100._0;

/***
URL: https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree
Number: 108
Difficulty: Easy
 */
public class ConvertSortedArraytoBinarySearchTree
{
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return ConvertToTreeNode(nums, 0, nums.Length - 1)!;
    }

    private TreeNode? ConvertToTreeNode(int[] nums, int leftIndex, int rightIndex)
    {
        if (leftIndex > rightIndex)
            return null;

        var halfway = leftIndex + (rightIndex - leftIndex) / 2;

        Console.WriteLine($"{leftIndex} ri: {rightIndex} half: {halfway} val: {nums[halfway]}");

        return new TreeNode(nums[halfway], ConvertToTreeNode(nums, leftIndex, halfway - 1), ConvertToTreeNode(nums, halfway + 1, rightIndex));
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
