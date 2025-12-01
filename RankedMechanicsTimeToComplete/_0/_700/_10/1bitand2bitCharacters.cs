namespace LeetCodeSolutions._0._700._10;

/***
URL: https://leetcode.com/problems/1-bit-and-2-bit-characters
Number: 717
Difficulty: Easy
 */
public class _1bitand2bitCharacters
{
    public bool IsOneBitCharacter(int[] bits)
    {
        var i = 0;

        while (i < bits.Length - 1)
        {
            if (bits[i] == 1)
            {
                i += 2;
            }
            else
            {
                i += 1;
            }
        }

        return i == bits.Length - 1;
    }
}
