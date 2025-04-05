namespace LeetCodeSolutions._0._800._60;

/***
URL: https://leetcode.com/problems/smallest-subtree-with-all-the-deepest-nodes/
Number: 865
Difficulty: Medium
Notes: Same as 1123
 */
class SmallestSubtreeWithAllTheDeepestNodesProblem
{
    private int DeepestDepth = -1;
    private TreeNode DeepestAncestor = new();

    public TreeNode SubtreeWithAllDeepest(TreeNode root)
    {
        TraverseTree(root, 0);

        return DeepestAncestor;
    }

    private int TraverseTree(TreeNode currentNode, int depth)
    {
        if (depth > DeepestDepth)
        {
            DeepestAncestor = currentNode;
            DeepestDepth = depth;
        }

        var leftNode = currentNode.left;
        var rightNode = currentNode.right;

        if (leftNode == null && rightNode == null)
        {
            return depth;
        }

        var depthOfLeftNode = -1;
        var depthOfRightNode = -1;

        if (leftNode != null)
        {
            depthOfLeftNode = TraverseTree(leftNode, depth + 1);
        }

        if (rightNode != null)
        {
            depthOfRightNode = TraverseTree(rightNode, depth + 1);
        }

        var valueToReturn = depthOfLeftNode >= depthOfRightNode ? depthOfLeftNode : depthOfRightNode; // Always return the max depth

        // If both sides are equal and this is the deepest depth so far then this is the highest common ancestor
        if (depthOfLeftNode == depthOfRightNode && valueToReturn == DeepestDepth)
        {
            DeepestAncestor = currentNode;
        }

        return valueToReturn;
    }
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