namespace LeetCodeSolutions._0._900._70;

/***
URL: https://leetcode.com/problems/largest-perimeter-triangle
Number: 976
Difficulty: Easy
 */
public class LargestPerimeterTriangle
{
    public int LargestPerimeter(int[] nums)
    {
        Array.Sort(nums);

        for (var i = nums.Length - 3; i >= 0; i--)
        {
            var leftSide = nums[i] + nums[i + 1];
            var rightSide = nums[i + 2];

            if (leftSide > rightSide)
            {
                return leftSide + rightSide;
            }
        }

        return 0;
    }
}
