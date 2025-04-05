using LeetCodeSolutions._1000._100._20;

namespace LeetCodeSolutions.Tests._1000._100._20;

public class LowestCommonAncestorOfDeepestLeavesProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode param1, int?[] expectedResult)
    {
        var problem = new LowestCommonAncestorOfDeepestLeavesProblem();

        var answer = problem.LcaDeepestLeaves(param1);

        Assert.Equal(expectedResult, TreeToArray(answer));
    }

    public static TheoryData<TreeNode, int?[]> TestData => new()
    {
        {
            ArrayToTree([3,5,1,6,2,0,8,null,null,7,4]),
            [2,7,4]
        },
        {
            ArrayToTree([1]),
            [1]
        },
        {
            ArrayToTree([0,1,3,null,2]),
            [2]
        },
        {
            ArrayToTree([1,2,null,3,4,null,6,null,5]),
            [2,3,4,null,6,null,5]
        },
        {
            ArrayToTree([1,4,2,5,null,6,3,null,8,null,null,7]),
            [1,4,2,5,null,6,3,null,8,null,null,7]
        }
    };

    private static TreeNode ArrayToTree(int?[] arr)
    {
        var root = new TreeNode(arr[0]!.Value);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var i = 1;
        while (i < arr.Length)
        {
            var current = queue.Dequeue();

            // Left child
            if (i < arr.Length && arr[i] != null)
            {
                current.left = new TreeNode(arr[i]!.Value);
                queue.Enqueue(current.left);
            }
            i++;

            // Right child
            if (i < arr.Length && arr[i] != null)
            {
                current.right = new TreeNode(arr[i]!.Value);
                queue.Enqueue(current.right);
            }
            i++;
        }

        return root;
    }

    public static int?[] TreeToArray(TreeNode root)
    {
        if (root == null) return [];

        List<int?> result = [];
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current != null)
            {
                result.Add(current.val);
                queue.Enqueue(current.left);
                queue.Enqueue(current.right);
            }
            else
            {
                result.Add(null);
            }
        }

        // Optional: trim trailing nulls
        var i = result.Count - 1;
        while (i >= 0 && result[i] == null)
        {
            result.RemoveAt(i);
            i--;
        }

        return result.ToArray();
    }
}
