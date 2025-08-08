namespace LeetCodeSolutions._0._0._20;

/***
URL: https://leetcode.com/problems/merge-two-sorted-lists/description/
Number: 21
Difficulty: easy
 */
public class MergeTwoSortedListsProblem
{
    private List<int> ListNodeValuesSorted = [];

    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        MergeSortedLists(list1, list2);

        if (ListNodeValuesSorted.Count == 0)
        {
            return null;
        }

        var listNodeToReturn = new ListNode(ListNodeValuesSorted[^1]);

        for (var i = ListNodeValuesSorted.Count - 2; i > -1; i--)
        {
            var tempListNode = new ListNode(ListNodeValuesSorted[i], listNodeToReturn);
            listNodeToReturn = tempListNode;
        }

        return listNodeToReturn;
    }

    private void MergeSortedLists(ListNode? list1, ListNode? list2)
    {
        if (list1 == null && list2 == null)
        {
            return;
        }
        else if (list1 == null)
        {
            ListNodeValuesSorted.Add(list2!.val);
            MergeSortedLists(list1, list2.next);
        }
        else if (list2 == null)
        {
            ListNodeValuesSorted.Add(list1.val);
            MergeSortedLists(list1.next, list2);
        }
        else if (list1.val <= list2.val)
        {
            ListNodeValuesSorted.Add(list1.val);
            MergeSortedLists(list1.next, list2);
        }
        else
        {
            ListNodeValuesSorted.Add(list2!.val);
            MergeSortedLists(list1, list2.next);
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
