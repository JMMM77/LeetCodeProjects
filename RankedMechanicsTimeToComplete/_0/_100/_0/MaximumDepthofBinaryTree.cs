namespace LeetCodeSolutions._0._100._0;

/***
URL: https://leetcode.com/problems/maximum-depth-of-binary-tree
Number: 104
Difficulty: Easy
 */
public class MaximumDepthofBinaryTree
{
    public int MaxDepth(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        return MaxDepth(root, 0);
    }

    private int MaxDepth(TreeNode node, int index)
    {
        if (node == null)
        {
            return index;
        }

        index++;

        var leftMaxDepth = MaxDepth(node.left, index);
        var rightMaxDepth = MaxDepth(node.right, index);

        return leftMaxDepth < rightMaxDepth ? rightMaxDepth : leftMaxDepth;
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
