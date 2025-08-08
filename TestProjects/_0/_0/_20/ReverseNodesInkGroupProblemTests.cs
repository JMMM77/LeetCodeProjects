using LeetCodeSolutions._0._0._20;
using static LeetCodeSolutions._0._0._20.ReverseNodesInkGroupProblem;

namespace LeetCodeSolutions.Tests._0._0._20;

public class ReverseNodesInkGroupProblemTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(ListNode s, int p, ListNode expectedResult)
    {
        var problem = new ReverseNodesInkGroupProblem();

        var answer = problem.ReverseKGroup(s, p);

        Assert.True(CompareListNodes(expectedResult, answer));
    }

    public static TheoryData<ListNode, int, ListNode> TestData => new()
    {
        {
            new ListNode([1,2,3,4,5]),
            2,
            new ListNode([2,1,4,3,5])
        },
        {
            new ListNode([1,2,3,4,5]),
            3,
            new ListNode([3,2,1,4,5])
        },
        {
            new ListNode([1,2,3,4]),
            4,
            new ListNode([4,3,2,1])
        }
    };

    private bool CompareListNodes(ListNode expectedListNode, ListNode calculatedListNode)
    {
        while (expectedListNode.next != null && calculatedListNode.next != null)
        {
            if (expectedListNode.val != calculatedListNode.val)
            {
                return false;
            }
            expectedListNode = expectedListNode.next;
            calculatedListNode = calculatedListNode.next;
        }
        return expectedListNode.val == calculatedListNode.val;
    }
}
