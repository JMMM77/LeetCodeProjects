namespace LeetCodeSolutions._0._100._0;

/***
URL: https://leetcode.com/problems/symmetric-tree
Number: 101
Difficulty: Easy
 */
public class SymmetricTree
{
    public bool IsSymmetric(TreeNode root)
    {
        if (root.left is null && root.right is null)
        {
            return true;
        }
        else if (root.left is null || root.right is null)
        {
            return false;
        }

        return IsSameTree(root.left, root.right);
    }

    private bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p is null && q is null)
        {
            return true;
        }
        else if (p is null || q is null)
        {
            return false;
        }

        if (p.val != q.val)
        {
            return false;
        }

        return IsSameTree(p.left, q.right) && IsSameTree(p.right, q.left);
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
