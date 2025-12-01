namespace LeetCodeSolutions._2000._500._30;

/***
URL: https://leetcode.com/problems/increment-submatrices-by-one
Number: 2536
Difficulty: Medium
 */
public class IncrementSubmatricesbyOne
{
    public int[][] RangeAddQueries(int n, int[][] queries)
    {
        var returnArray = new int[n][];

        for (var i = 0; i < n; i++)
        {
            returnArray[i] = new int[n];
        }

        foreach (var query in queries)
        {
            for (var i = query[0]; i <= query[2]; i++)
            {
                for (var j = query[1]; j <= query[3]; j++)
                {
                    returnArray[i][j]++;
                }
            }
        }

        return returnArray;
    }
}
