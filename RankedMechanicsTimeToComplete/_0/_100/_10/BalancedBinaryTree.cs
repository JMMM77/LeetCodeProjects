namespace LeetCodeSolutions._0._100._10;

/***
URL: https://leetcode.com/problems/balanced-binary-tree
Number: 110
Difficulty: Easy
 */
public class BalancedBinaryTree
{
    public bool IsBalanced(TreeNode root)
    {
        return IsSubTreeBalanced(root) != -1;
    }

    private int IsSubTreeBalanced(TreeNode? node)
    {
        if (node is null)
        {
            return 0;
        }

        var left = IsSubTreeBalanced(node.left);
        if (left == -1)
        {
            return -1;
        }

        var right = IsSubTreeBalanced(node.right);

        if (right == -1)
        {
            return -1;
        }

        if (Math.Abs(left - right) > 1)
        {
            return -1;
        }

        return Math.Max(left, right) + 1;
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
