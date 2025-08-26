namespace LeetCodeSolutions._0._100._10;

/***
URL: https://leetcode.com/problems/minimum-depth-of-binary-tree
Number: 111
Difficulty: Easy
 */
public class MinimumDepthofBinaryTree
{
    public int MinDepth(TreeNode root)
    {
        if (root is null)
        {
            return 0;
        }

        if (root.left == null && root.right == null)
        {
            return 1;
        }

        return Depth(root, 1);
    }

    private int Depth(TreeNode? node, int index)
    {
        if (node == null)
        {
            return index;
        }

        if (node.left == null && node.right == null)
        {
            return index;
        }

        var left = Depth(node.left, index + 1);

        if (node.right == null)
        {
            return left;
        }

        var right = Depth(node.right, index + 1);

        if (node.left == null)
        {
            return right;
        }

        return Math.Min(left, right);
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
