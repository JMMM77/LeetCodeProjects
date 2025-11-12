namespace LeetCodeSolutions._2000._600._50;

/***
URL: https://leetcode.com/problems/minimum-number-of-operations-to-make-all-array-elements-equal-to-1
Number: 2654
Difficulty: Medium
 */
public class MinimumNumberofOperationstoMakeAllArrayElementsEqualto1
{
    public int MinOperations(int[] nums)
    {
        var n = nums.Length;
        var shortestSubArrayLength = int.MaxValue;

        var numOfOnes = 0;

        foreach (var num in nums)
        {
            if (num == 1)
            {
                numOfOnes++;
            }
        }

        if (numOfOnes > 0)
        {
            return n - numOfOnes;
        }

        // <gcd, arrayLength>
        var listsToTry = new List<(int, int)>();

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            var newList = new List<(int, int)>();

            foreach (var val in listsToTry)
            {
                var thisGcd = GCD(val.Item1, num);
                var newLength = val.Item2 + 1;

                if (thisGcd == 1)
                {
                    if (newLength < shortestSubArrayLength)
                    {
                        shortestSubArrayLength = newLength;

                        if (shortestSubArrayLength == 2)
                        {
                            return n;
                        }
                    }
                }
                else
                {
                    newList.Add((thisGcd, newLength));
                }
            }

            listsToTry = newList;
            listsToTry.Add((num, 1));
        }

        if (shortestSubArrayLength == int.MaxValue)
        {
            return -1;
        }

        return n + shortestSubArrayLength - 2;
    }


    private static int GCD(int a, int b)
    {
        while (b != 0)
        {
            var t = a % b;
            a = b;
            b = t;
        }

        return a;
    }
}
