namespace LeetCodeSolutions._3000._300._50;

/***
URL: https://leetcode.com/problems/make-array-elements-equal-to-zero
Number: 3354
Difficulty: Easy
 */
public class MakeArrayElementsEqualtoZero
{
    public int CountValidSelections(int[] nums)
    {
        var numValidSelections = 0;
        var valLeft = 0;
        var valRight = nums.Sum();

        for (var i = 0; i < nums.Length; ++i)
        {
            if (nums[i] != 0)
            {
                valLeft += nums[i];
                valRight -= nums[i];

                continue;
            }

            if (valLeft == valRight)
            {
                numValidSelections += 2;
            }
            else if (valLeft == valRight - 1 || valLeft == valRight + 1)
            {
                numValidSelections += 1;
            }
        }

        return numValidSelections;
    }
}
