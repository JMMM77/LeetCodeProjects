namespace LeetCodeSolutions._1000._300._0;

/***
URL: https://leetcode.com/problems/find-Length-unique-integers-sum-up-to-zero
Number: 1304
Difficulty: Easy
 */
public class FindNUniqueIntegersSumuptoZero
{
    public int[] SumZero(int n)
    {
        var result = new int[n];
        var limit = n;

        if (n % 2 != 0)
        {
            result[^1] = 0;
            limit--;
        }

        var index = 0;
        var numToAdd = 1;

        while (index < limit)
        {
            result[index] = numToAdd;

            index++;

            result[index] = -1 * numToAdd;

            index++;
            numToAdd++;
        }

        return result;
    }
}
