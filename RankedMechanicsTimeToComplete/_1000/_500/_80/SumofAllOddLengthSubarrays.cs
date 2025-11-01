namespace LeetCodeSolutions._1000._500._80;

/***
URL: https://leetcode.com/problems/sum-of-all-odd-length-subarrays
Number: 1588
Difficulty: Easy
 */
public class SumofAllOddLengthSubarrays
{
    public int SumOddLengthSubarrays(int[] arr)
    {
        for (var i = 1; i < arr.Length; i++)
        {
            arr[i] += arr[i - 1];
        }

        var total = 0;

        for (var i = 0; i < arr.Length; i++)
        {
            for (var arraySize = 1; i - arraySize >= -1; arraySize += 2)
            {
                if (i - arraySize == -1)
                {
                    total += arr[i];
                    break;
                }

                total += arr[i] - arr[i - arraySize];
            }
        }

        return total;
    }
}
