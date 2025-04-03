namespace LeetCodeSolutions._0._0._0;

/***
URL: https://leetcode.com/problems/add-two-numbers/description/
Topics: Linked List, Math, Recursion
Number: 2
Difficulty: Medium
*/
public static class AddTwoNumbersViaLinkedListsProblem
{
    private static int carry = 0;

    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var valueToReturn = AddNewListNodeRecursive(l1, l2);
        carry = 0;
        return valueToReturn;
    }

    private static ListNode AddNewListNodeRecursive(ListNode? restOfL1, ListNode? restOfL2)
    {
        var newListNode = new ListNode();

        if (restOfL1 != null && restOfL2 != null)
        {
            newListNode.val = ValueToSet(restOfL1.val + restOfL2.val + carry);
            restOfL1 = restOfL1.next;
            restOfL2 = restOfL2.next;
        }
        else if (restOfL1 != null)
        {
            newListNode.val = ValueToSet(restOfL1.val + carry);
            restOfL1 = restOfL1.next;
        }
        else if (restOfL2 != null)
        {
            newListNode.val = ValueToSet(restOfL2.val + carry);
            restOfL2 = restOfL2.next;
        }

        if (restOfL1 == null && restOfL2 == null)
        {
            if (carry > 0)
            {
                newListNode.next = new ListNode(carry);
            }

            return newListNode;
        }

        newListNode.next = AddNewListNodeRecursive(restOfL1, restOfL2);

        return newListNode;
    }

    private static int ValueToSet(int valueToSet)
    {
        var returnValue = valueToSet;

        if (returnValue >= 10)
        {
            returnValue = returnValue % 10;
            carry = 1;
        }
        else
        {
            carry = 0;
        }

        return returnValue;
    }

    public static ListNode AddTwoNumbers2(ListNode l1, ListNode l2)
    {
        var l1Number = GetNumber2(l1);
        var l2Number = GetNumber2(l2);
        var sum = l1Number + l2Number;
        var linkedListSum = GetLinkedList2(sum);

        return linkedListSum;
    }

    private static long GetNumber2(ListNode linkedList)
    {
        var reversedNumber = "";

        while (linkedList.next != null)
        {
            reversedNumber = linkedList.val + reversedNumber;
            linkedList = linkedList.next;
        }

        // Include the last node;
        reversedNumber = linkedList.val + reversedNumber;

        return long.Parse(reversedNumber);
    }

    private static ListNode GetLinkedList2(long number)
    {
        var reversedNumber = number.ToString();
        var linkedList = new ListNode(int.Parse(reversedNumber.Last().ToString()));
        var currentNode = linkedList;

        for (var i = reversedNumber.Length - 2; i > -1; i--)
        {
            currentNode.next = new ListNode(int.Parse(reversedNumber[i].ToString()));
            currentNode = currentNode.next;
        }

        return linkedList;
    }
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