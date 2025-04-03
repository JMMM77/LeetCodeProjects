namespace LeetCodeSolutions._0._400._90;

/***
URL: https://leetcode.com/problems/next-greater-element-i/description/
Number: 496
Difficulty: Easy
 */
class NextGreaterElementIProblem
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        var monotonicStack = new Stack<int>(nums2.Length);
        var nextGreater = new Dictionary<int, int>(nums2.Length);

        // Traverse nums2 and use a monotonic stack
        foreach (var num in nums2)
        {
            while (monotonicStack.Count != 0 && monotonicStack.Peek() < num)
            {
                var smallerNum = monotonicStack.Pop();
                nextGreater.Add(smallerNum, num); // Store next greater element
            }

            monotonicStack.Push(num);
        }

        // Remaining elements in stack have no next greater element
        while (monotonicStack.Count != 0)
        {
            nextGreater.Add(monotonicStack.Pop(), -1);
        }

        return nums1.Select(x => nextGreater[x]).ToArray();
    }
}
