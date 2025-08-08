namespace LeetCodeSolutions._3000._400._70;

/***
URL: https://leetcode.com/problems/fruits-into-baskets-iii
Number: 3479
Difficulty: Medium
 */
public class FruitsIntoBasketsIII
{
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
    {
        var leftOverFruit = 0;
        var segmentTree = GetLinkedList(baskets) ?? new ListNode(0, null, null);

        foreach (var fruit in fruits)
        {
            if (segmentTree.MaxVal < fruit)
            {
                leftOverFruit++;
                continue;
            }

            segmentTree.MaxVal = IsPresent(fruit, segmentTree);
        }

        return leftOverFruit;
    }

    private int IsPresent(int fruit, ListNode segmentTree)
    {
        if (segmentTree.Left == null && segmentTree.Right == null)
        {
            segmentTree.MaxVal = 0;
            return 0;
        }

        if (segmentTree.Left != null && segmentTree.Left.MaxVal >= fruit)
        {
            segmentTree.MaxVal = Math.Max(IsPresent(fruit, segmentTree.Left), segmentTree.Right?.MaxVal ?? 0);
        }
        else if (segmentTree.Right!.MaxVal >= fruit)
        {
            segmentTree.MaxVal = Math.Max(IsPresent(fruit, segmentTree.Right), segmentTree.Left?.MaxVal ?? 0);
        }

        return segmentTree.MaxVal;
    }

    private ListNode? GetLinkedList(int[] arrayToSplit)
    {
        if (arrayToSplit.Length == 0)
        {
            return null;
        }

        if (arrayToSplit.Length == 1)
        {
            return new ListNode(arrayToSplit[0], null, null);
        }

        var halfWay = arrayToSplit.Length / 2;
        var leftHalf = arrayToSplit[0..halfWay];
        var rightHalf = arrayToSplit[halfWay..];
        var leftNode = GetLinkedList(leftHalf);
        var rightNode = GetLinkedList(rightHalf);
        var maxVal = Math.Max(leftNode?.MaxVal ?? 0, rightNode?.MaxVal ?? 0);

        return new ListNode(maxVal, leftNode, rightNode);
    }

    private class ListNode
    {
        public int MaxVal;
        public ListNode? Left;
        public ListNode? Right;

        public ListNode(int maxVal, ListNode? left, ListNode? right)
        {
            MaxVal = maxVal;
            Left = left;
            Right = right;
        }
    }
}
