namespace LeetCodeSolutions._0._600._10;

/***
URL: https://leetcode.com/problems/valid-triangle-number
Number: 611
Difficulty: Medium
 */
public class ValidTriangleNumber
{
    public int TriangleNumber(int[] nums)
    {
        Array.Sort(nums);

        var numOfValidTriangles = 0;

        for (var rightSide = nums.Length - 1; rightSide >= 2; rightSide--)
        {
            var left = 0;
            var checkMax = rightSide - 1;

            while (left < checkMax)
            {
                if (nums[left] + nums[checkMax] > nums[rightSide])
                {
                    // If nums[left] + nums[checkMax] > nums[rightSide], then all nums[left..checkMax-1] with nums[checkMax] also work
                    numOfValidTriangles += (checkMax - left);
                    checkMax--;
                }
                else
                {
                    left++;
                }
            }
        }

        return numOfValidTriangles;
    }
}
