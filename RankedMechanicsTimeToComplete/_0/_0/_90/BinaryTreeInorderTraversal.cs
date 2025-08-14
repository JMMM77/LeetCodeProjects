namespace LeetCodeSolutions._0._0._90;

/***
URL: https://leetcode.com/problems/binary-tree-inorder-traversal
Number: 94
Difficulty: Easy
 */
public class BinaryTreeInorderTraversal
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        if (root == null)
        {
            return [];
        }

        IList<int> returnArray = [];

        if (root.left != null)
        {
            returnArray = InorderTraversal(root.left);
        }

        returnArray.Add(root.val);

        if (root.right != null)
        {
            var tempList = InorderTraversal(root.right);

            foreach (var item in tempList)
            {
                returnArray.Add(item);
            }
        }

        return returnArray;
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
