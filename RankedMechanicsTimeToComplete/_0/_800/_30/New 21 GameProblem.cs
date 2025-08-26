namespace LeetCodeSolutions._0._800._30;

/***
URL: https://leetcode.com/problems/new-21-game
Number: 837
Difficulty: Medium
 */
public class New21GameProblem
{
    public double New21Game(int n, int k, int maxPts)
    {
        if (k == 0 || n >= k + maxPts)
        {
            return 1.0;
        }

        var prod = new double[n + 1];
        prod[0] = 1.0;

        var currentProb = 1.0;
        var finalProds = 0.0;

        for (var i = 1; i <= n; i++)
        {
            prod[i] = currentProb / maxPts;

            if (i < k)
            {
                currentProb += prod[i];
            }
            else
            {
                finalProds += prod[i];
            }

            if (i - maxPts >= 0)
            {
                currentProb -= prod[i - maxPts];
            }
        }

        return finalProds;
    }
}
