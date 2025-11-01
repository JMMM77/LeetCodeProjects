using System.Numerics;

namespace LeetCodeSolutions._3000._500._30;

/***
URL: https://leetcode.com/problems/find-sum-of-array-product-of-magical-sequences
Number: 3539
Difficulty: Hard
 */
public class FindSumofArrayProductofMagicalSequences
{
    // To be honest, I still dont really understand this question
    // Ill try to do more DP questions, but I think this is the hardest question I have come across
    private readonly int MOD = 1000000007;

    public int MagicalSum(int m, int k, int[] nums)
    {
        var n = nums.Length;

        // C(n,k) = fac[n] ∗ ifac[k] ∗ ifac[n−k] mod MOD
        #region Prep for efficient computation of binomial coefficients later
        // Precomputing Factorials and Inverse Factorials
        // fac[i] = i!
        var fac = new long[m + 1];
        fac[0] = 1;

        for (var i = 1; i <= m; i++)
        {
            fac[i] = fac[i - 1] * i % MOD;
        }

        // Fermat’s Little Theorem to compute the modular inverse
        // ifac[i] = (i!)^(−1) mod MOD
        var ifac = new long[m + 1];
        ifac[0] = 1;
        ifac[1] = 1;

        for (var i = 2; i <= m; i++)
        {
            ifac[i] = QuickMul(i, MOD - 2, MOD);
        }

        for (var i = 2; i <= m; i++)
        {
            ifac[i] = ifac[i - 1] * ifac[i] % MOD;
        }

        #endregion

        #region Avoid recomputation later inside loops.
        // Precomputing Powers of Each Number
        var numsPower = new long[n][];

        for (var i = 0; i < n; i++)
        {
            numsPower[i] = new long[m + 1];
            numsPower[i][0] = 1;

            for (var j = 1; j <= m; j++)
            {
                numsPower[i][j] = numsPower[i][j - 1] * nums[i] % MOD;
            }
        }

        #endregion

        #region Setting up a 4D DP array
        /**
         * f[i][j][p][q]
         * i = index in nums (number being processing)
         * j = total degree (sum of exponents used so far)
         * p = some encoded binary state (bitmask or parity info)
         * q = number of set bits or toggles used
         */
        var f = new long[n][][][];

        // Initialize 4D DP array with zeros and later fill.
        for (var i = 0; i < n; i++)
        {
            f[i] = new long[m + 1][][];

            for (var j = 0; j <= m; j++)
            {
                f[i][j] = new long[m * 2 + 1][];

                for (var p = 0; p <= m * 2; p++)
                {
                    f[i][j][p] = new long[k + 1];
                }
            }
        }

        // Compute first number
        for (var j = 0; j <= m; j++)
        {
            f[0][j][j][0] = numsPower[0][j] * ifac[j] % MOD;
        }

        // Iterates through all states and extends them using the next number
        for (var i = 0; i + 1 < n; i++)
        {
            for (var j = 0; j <= m; j++)
            {
                for (var p = 0; p <= m * 2; p++)
                {
                    for (var q = 0; q <= k; q++)
                    {
                        var q2 = (p % 2) + q;

                        if (q2 > k)
                        {
                            break;
                        }

                        /**
                         * Adds combinations of:
                         *  The previous state f[i][j][p][q]
                         *  Powers of the next number
                         *  Adjusted indices p2 (some bit manipulation or polynomial folding)
                         *  Weighted by factorial inverses
                         */
                        for (var r = 0; r + j <= m; r++)
                        {
                            var p2 = p / 2 + r;
                            f[i + 1][j + r][p2][q2] += f[i][j][p][q] *
                                                       numsPower[i + 1][r] %
                                                       MOD * ifac[r] % MOD;
                            f[i + 1][j + r][p2][q2] %= MOD;
                        }
                    }
                }
            }
        }

        #endregion

        long res = 0;

        for (var p = 0; p <= m * 2; p++)
        {
            for (var q = 0; q <= k; q++)
            {
                if (BitOperations.PopCount((uint)p) + q == k)
                {
                    res = (res + f[n - 1][m][p][q] * fac[m] % MOD) % MOD;
                }
            }
        }

        return (int)res;
    }

    /// <summary>
    /// Fast modular exponentiation, used to compute: x^(y) mod MOD
    /// </summary>
    private long QuickMul(long x, long y, long MOD)
    {
        long res = 1;
        var cur = x % MOD;

        while (y > 0)
        {
            if ((y & 1) == 1)
            {
                res = res * cur % MOD;
            }

            y >>= 1;
            cur = cur * cur % MOD;
        }

        return res;
    }
}
