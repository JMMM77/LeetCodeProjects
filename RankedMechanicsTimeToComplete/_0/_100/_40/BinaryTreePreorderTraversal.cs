namespace LeetCodeSolutions._0._100._40;

/***
URL: https://leetcode.com/problems/binary-tree-preorder-traversal
Number: 144
Difficulty: Easy
*/
public class BinaryTreePreorderTraversal
{
    public IList<int> PreorderTraversal(TreeNode root)
    {
        if (root == null)
        {
            return [];
        }

        var returnList = new List<int>
        {
            root.val
        };

        if (root.left != null)
        {
            returnList.AddRange(PreorderTraversal(root.left));
        }

        if (root.right != null)
        {
            returnList.AddRange(PreorderTraversal(root.right));
        }

        return returnList;
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
