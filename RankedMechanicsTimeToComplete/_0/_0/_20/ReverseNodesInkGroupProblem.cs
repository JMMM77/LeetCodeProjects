namespace LeetCodeSolutions._0._0._20;

/***
URL: https://leetcode.com/problems/reverse-nodes-in-k-group/description/
Number: 25
Difficulty: Hard
 */
public class ReverseNodesInkGroupProblem
{
    public ListNode? ReverseKGroup(ListNode head, int k)
    {
        if (head == null || k == 1) return head;

        // Check if there are at least k nodes to reverse
        var node = head;

        for (var i = 0; i < k; i++)
        {
            if (node == null)
            {
                return head;
            }

            node = node.next;
        }

        // Reverse first k nodes
        var newHead = Reverse(head, k);

        // Recursively reverse the rest and connect, this works since the head has already been reversed
        head.next = ReverseKGroup(node!, k);

        return newHead;
    }

    private ListNode? Reverse(ListNode head, int k)
    {
        ListNode? prev = null;
        var currentItem = head;

        // Reverse the pointers in the linked list
        while (k-- > 0)
        {
            var next = currentItem!.next;
            currentItem.next = prev;
            prev = currentItem;
            currentItem = next;
        }

        return prev;
    }

    // Didnt work
    private int SwapInterval = 0;
    public ListNode ReverseKGroup1(ListNode head, int k)
    {

        if (head == null)
        {
            return null;
        }

        if (head.next == null)
        {
            return head;
        }

        if (k == 1)
        {
            return head;
        }

        SwapInterval = k - 2;

        //// 1 -> 2 -> 3 -> 4 -> rest
        //var firstElement = head;
        //var secondElement = head.next;
        //var thirdElement = secondElement.next;
        //var fourthElement = thirdElement.next;

        //firstElement.next = fourthElement.next; // 2 -> 3 -> 4 -> rest & 1 -> rest
        //fourthElement.next = thirdElement; // 2 -> 3 <-> 4 & 1 -> rest
        //thirdElement.next = secondElement; // 2 <-> 3 <- 4 & 1 -> rest
        //secondElement.next = firstElement; // 4 -> 3 -> 2 -> 1 -> rest

        return SwapHead1(head, head.next, SwapInterval); // Initial value needs to remove one index due to lists starting at 0 instead of 1
    }

    private ListNode? SwapHead1(ListNode parentNode, ListNode currentItem, int index)
    {
        if (index == 0)
        {
            if (currentItem.next != null && currentItem.next.next != null)
            {
                var testResult = SwapHead1(currentItem.next, currentItem.next.next, SwapInterval);

                if (testResult != null)
                {
                    currentItem.next = testResult;
                }
            }

            parentNode.next = currentItem.next;
            currentItem.next = parentNode;
            return currentItem;
        }

        if (currentItem.next == null)
        {
            return null;
        }

        var result = SwapHead1(parentNode, currentItem.next, index - 1);

        if (result == null)
        {
            if (index + 1 != SwapInterval)
            {
                return parentNode;
            }

            return null;
        }

        currentItem.next = result.next;
        result.next = currentItem;

        return result;
    }

    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
        public ListNode(IEnumerable<int> linkedList)
        {
            val = linkedList.FirstOrDefault();

            linkedList = linkedList.Skip(1);

            if (linkedList.Any())
            {
                next = new ListNode(linkedList);
            }
        }
    }
}
