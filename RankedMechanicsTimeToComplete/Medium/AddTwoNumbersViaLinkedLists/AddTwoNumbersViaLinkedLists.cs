namespace LeetCodeSolutions.Medium.AddTwoNumbersViaLinkedLists;

/***
URL: https://leetcode.com/problems/add-two-numbers/description/
Topics: Linked List, Math, Recursion

You are given two non-empty linked lists representing two non-negative integers.The digits are stored in reverse order, and each of their nodes contains a single digit.
Add the two numbers and return the sum as a linked list.
You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Example 1:
Input: l1 = [2, 4, 3], l2 = [5, 6, 4]
Output: [7, 0, 8]
Explanation: 342 + 465 = 807.

Example 2:
Input: l1 = [0], l2 = [0]
Output: [0]

Example 3:
Input: l1 = [9, 9, 9, 9, 9, 9, 9], l2 = [9, 9, 9, 9]
Output: [8, 9, 9, 9, 0, 0, 0, 1]
*/
public static class AddTwoNumbersViaLinkedLists2
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
}

// Causes overflow error for large numbers
public static class AddTwoNumbersViaLinkedLists1
{
    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var l1Number = GetNumber(l1);
        var l2Number = GetNumber(l2);
        var sum = l1Number + l2Number;
        var linkedListSum = GetLinkedList(sum);

        return linkedListSum;
    }

    private static long GetNumber(ListNode linkedList)
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

    private static ListNode GetLinkedList(long number)
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
