namespace LeetCodeSolutions._2000._200._30;

/***
URL: https://leetcode.com/problems/root-equals-sum-of-children/
Number: 2236
Difficulty: Easy
 */
public class RootEqualsSumOfChildrenProblem
{
    public bool CheckTree(TreeNode root)
    {
        return root.val == root.left.val + root.right.val;
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
