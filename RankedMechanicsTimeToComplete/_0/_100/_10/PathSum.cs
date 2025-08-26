namespace LeetCodeSolutions._0._100._10;

/***
URL: https://leetcode.com/problems/path-sum
Number: 112
Difficulty: Easy
 */
public class PathSum
{
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        return HasPathSum(root, targetSum, 0);
    }

    public bool HasPathSum(TreeNode? node, int targetSum, int currentSum)
    {
        if (node == null)
        {
            return false;
        }

        if (node.left == null && node.right == null)
        {
            if (currentSum + node.val == targetSum)
            {
                return true;
            }

            return false;
        }

        var left = HasPathSum(node.left, targetSum, currentSum + node.val);
        var right = HasPathSum(node.right, targetSum, currentSum + node.val);

        return left || right;
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
