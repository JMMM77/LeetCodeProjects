namespace LeetCodeSolutions._0._500._0;
/***
URL: https://leetcode.com/problems/next-greater-element-ii
Number: 503
Difficulty: Medium
 */
public class NextGreaterElementIIProblem
{
    public int[] NextGreaterElements(int[] nums)
    {
        var stack = new Stack<int>(nums.Length);
        var nextGreater = new Dictionary<int, int>(nums.Length);
        var looped = false;

        for (var i = 0; i < nums.Length; i++)
        {
            var newNum = nums[i];

            while (stack.Count != 0 && nums[stack.Peek()] < newNum)
            {
                var smallerIndex = stack.Pop();
                nextGreater.Add(smallerIndex, newNum); // Store next greater element
            }

            if (looped)
            {
                continue;
            }

            stack.Push(i);

            if (i + 1 == nums.Length) // Loop through the list twice to find the biggest circular number
            {
                looped = true;
                i = -1;
            }
        }

        // Remaining elements in stack have no next greater element
        while (stack.Count != 0)
        {
            nextGreater.Add(stack.Pop(), -1);
        }

        return nextGreater.OrderBy(x => x.Key).Select(x => x.Value).ToArray();
    }
}
