namespace LeetCodeSolutions._1000._500._10;

/***
URL: https://leetcode.com/problems/number-of-substrings-with-only-1s
Number: 1513
Difficulty: Medium
 */
public class NumberofSubstringsWithOnly1s
{
    private const int MOD = 1000000007;

    public int NumSub(string s)
    {
        long result = 0;
        long count = 0;

        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '1')
            {
                count++;
                continue;
            }

            if (count > 0)
            {
                result = (result + (count * (count + 1) / 2)) % MOD;
                count = 0;
            }
        }

        if (count > 0)
        {
            result = (result + (count * (count + 1) / 2)) % MOD;
        }

        return (int)result;
    }
}
