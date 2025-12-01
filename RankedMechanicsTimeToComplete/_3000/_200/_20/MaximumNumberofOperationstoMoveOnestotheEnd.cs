namespace LeetCodeSolutions._3000._200._20;

/***
URL: https://leetcode.com/problems/maximum-number-of-operations-to-move-ones-to-the-end
Number: 3228
Difficulty: Medium
 */
public class MaximumNumberofOperationstoMoveOnestotheEnd
{
    public int MaxOperations(string s)
    {
        var count = 0;
        var oneStack = s[0] == '1' ? 1 : 0;

        for (var i = 1; i < s.Length; i++)
        {
            if (s[i] == '1')
            {
                oneStack++;
                continue;
            }

            if (s[i - 1] == '0')
            {
                continue;
            }

            count += oneStack;
        }

        return count;
    }
}
