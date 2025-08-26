namespace LeetCodeSolutions._0._100._40;

/***
URL: https://leetcode.com/problems/binary-tree-postorder-traversal
Number: 145
Difficulty: Easy
*/
public class BinaryTreePostorderTraversal
{
    public IList<int> PostorderTraversal(TreeNode root)
    {
        if (root == null)
        {
            return [];
        }

        var returnList = new List<int>();

        if (root.left != null)
        {
            returnList.AddRange(PostorderTraversal(root.left));
        }

        if (root.right != null)
        {
            returnList.AddRange(PostorderTraversal(root.right));
        }

        returnList.Add(root.val);

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
