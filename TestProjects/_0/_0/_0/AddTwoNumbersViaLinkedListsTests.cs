using LeetCodeSolutions._0._0._0;

namespace LeetCodeSolutions.Tests._0._0._0;

public class AddTwoNumbersViaLinkedListsTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(ListNode list1, ListNode list2, ListNode expectedList)
    {
        var combinedList = AddTwoNumbersViaLinkedListsProblem.AddTwoNumbers(list1, list2);

        Assert.True(this.CompareListNodes(expectedList, combinedList));
    }

    public static TheoryData<ListNode, ListNode, ListNode> TestData => new()
    {
        {
            new ListNode([2,4,3]),
            new ListNode([5,6,4]),
            new ListNode([7,0,8])
        },
        {
            new ListNode([0]),
            new ListNode([0]),
            new ListNode([0])
        },
        {
            new ListNode([9,9,9,9,9,9,9]),
            new ListNode([9,9,9,9]),
            new ListNode([8,9,9,9,0,0,0,1])
        },
        {
            new ListNode([0]),
            new ListNode([1]),
            new ListNode([1])
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
