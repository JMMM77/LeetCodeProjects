namespace LeetCodeSolutions._0._800._60;

/***
URL: https://leetcode.com/problems/reordered-power-of-2
Number: 869
Difficulty: Medium
 */
public class ReorderedPowerOf2Problem
{
    public bool ReorderedPowerOf2(int n)
    {
        var sortedNumber = GetSortedNumber(n);

        for (var i = 0; i < 31; i++)
        {
            if (GetSortedNumber(1 << i) == sortedNumber)
            {
                return true;
            }
        }

        return false;
    }

    private string GetSortedNumber(int n)
    {
        var digits = n.ToString().ToCharArray();
        Array.Sort(digits);
        return new string(digits);
    }
}
