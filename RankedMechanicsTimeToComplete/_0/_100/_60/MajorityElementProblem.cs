namespace LeetCodeSolutions._0._100._60;

/***
URL: https://leetcode.com/problems/majority-element
Number: 169
Difficulty: Easy
*/
public class MajorityElementProblem
{
    public int MajorityElement(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        var recordSet = new Dictionary<int, int>(); // (val, count)

        foreach (var num in nums)
        {
            if (recordSet.ContainsKey(num))
            {
                recordSet[num]++;

                if (recordSet[num] > nums.Length / 2)
                {
                    return num;
                }

                continue;
            }

            recordSet.Add(num, 1);
        }

        return 0;
    }
}
