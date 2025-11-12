namespace LeetCodeSolutions._3000._200._10;

/***
URL: https://leetcode.com/problems/delete-nodes-from-linked-list-present-in-array
Number: 3217
Difficulty: Medium
*/
public class DeleteNodesFromLinkedListPresentinArray
{
    public ListNode? ModifiedList(int[] nums, ListNode head)
    {
        var setNums = new HashSet<int>();

        foreach (var num in nums)
        {
            setNums.Add(num);
        }

        return ModifiedList(setNums, head);
    }

    private ListNode? ModifiedList(HashSet<int> nums, ListNode head)
    {
        if (head is null)
        {
            return null;
        }

        if (head.next is null)
        {
            if (nums.Contains(head.val))
            {
                return null;
            }

            return head;
        }

        var nextNode = ModifiedList(nums, head.next);

        if (nums.Contains(head.val))
        {
            return nextNode;
        }

        head.next = nextNode;

        return head;
    }

    public class ListNode(int val = 0, ListNode? next = null)
    {
        public int val = val;
        public ListNode? next = next;
    }
}
