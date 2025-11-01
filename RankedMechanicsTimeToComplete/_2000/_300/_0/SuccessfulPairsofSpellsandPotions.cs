namespace LeetCodeSolutions._2000._300._0;

/***
URL: https://leetcode.com/problems/successful-pairs-of-spells-and-potions
Number: 2300
Difficulty: Medium
 */
public class SuccessfulPairsofSpellsandPotions
{
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        Array.Sort(potions);
        var result = new int[spells.Length];

        for (var i = 0; i < spells.Length; i++)
        {
            var spell = spells[i];
            var minPotionPower = (success + spell - 1) / spell;  // Ceiling division
            var index = BinarySearch(potions, minPotionPower);

            result[i] = potions.Length - index;
        }

        return result;
    }

    private int BinarySearch(int[] potions, long target)
    {
        var left = 0;
        var right = potions.Length;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (potions[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
    }
}
