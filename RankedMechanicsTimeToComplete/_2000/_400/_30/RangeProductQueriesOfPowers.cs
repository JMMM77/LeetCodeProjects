namespace LeetCodeSolutions._2000._400._30;

/***
URL: https://leetcode.com/problems/reordered-power-of-2
Number: 869
Difficulty: Medium
 */
public class RangeProductQueriesOfPowers
{
    private static double MODULO = Math.Pow(10, 9) + 7;

    public int[] ProductQueries(int n, int[][] queries)
    {
        var containsPowersOfTwo = new List<int>();

        for (var i = 0; i < 31; i++)
        {
            var powerOfTwo = (1 << i);

            if ((n & powerOfTwo) == powerOfTwo)
            {
                containsPowersOfTwo.Add(powerOfTwo);
                continue;
            }

            if (powerOfTwo > n)
            {
                break;
            }
        }

        var answer = new List<int>();

        foreach (var query in queries)
        {
            double currentProduct = 1;

            for (var i = query[0]; i <= query[1]; i++)
            {
                currentProduct = (currentProduct * containsPowersOfTwo[i]) % MODULO;
            }

            answer.Add((int)currentProduct);
        }

        return [.. answer];
    }
}
