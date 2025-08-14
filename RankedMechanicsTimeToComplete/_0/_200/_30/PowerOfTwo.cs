namespace LeetCodeSolutions._0._200._30;

/***
URL: https://leetcode.com/problems/power-of-two
Number: 231
Difficulty: Medium
 */
public class PowerOfTwo
{
    public bool IsPowerOfTwo(int n)
    {
        if (n < 1)
        {
            return false;
        }

        for (var i = 0; i < 32; i++)
        {

            if ((n & (1 << i)) == n)
            {
                return true;
            }
        }

        return false;
    }
}
