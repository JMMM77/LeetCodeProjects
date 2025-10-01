namespace LeetCodeSolutions._2000._200._20;

/***
URL: https://leetcode.com/problems/find-triangular-sum-of-an-array 
Number: 2221
Difficulty: Medium
 */
public class FindTriangularSumofAnArray
{
    public int TriangularSum(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        var newArray = new int[nums.Length - 1];

        for (var i = 0; i < newArray.Length; i++)
        {
            newArray[i] = (nums[i] + nums[i + 1]) % 10;
        }

        return TriangularSum(newArray);
    }
}
