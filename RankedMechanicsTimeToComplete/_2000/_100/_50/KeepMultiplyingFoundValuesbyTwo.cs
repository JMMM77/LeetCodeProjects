namespace LeetCodeSolutions._2000._100._50;

/***
URL: https://leetcode.com/problems/keep-multiplying-found-values-by-two
Number: 2154
Difficulty: Easy
 */
public class KeepMultiplyingFoundValuesbyTwo
{
    public int FindFinalValue(int[] nums, int original)
    {
        Array.Sort(nums);

        var foundIndex = Array.BinarySearch(nums, original);

        while (foundIndex >= 0)
        {
            original *= 2;
            foundIndex = Array.BinarySearch(nums, original);
        }

        return original;
    }
}
