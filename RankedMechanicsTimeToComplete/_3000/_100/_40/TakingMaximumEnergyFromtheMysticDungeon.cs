namespace LeetCodeSolutions._3000._100._40;

/***
URL: https://leetcode.com/problems/taking-maximum-energy-from-the-mystic-dungeon
Number: 3147
Difficulty: Medium
 */
public class TakingMaximumEnergyFromtheMysticDungeon
{
    public int MaximumEnergy(int[] energy, int k)
    {
        var n = energy.Length;
        var maxEnergy = int.MinValue;

        for (var i = n - 1; i >= n - k; i--)
        {
            var currentEnergy = 0;
            var jump = i;

            while (jump >= 0)
            {
                Console.WriteLine(jump);

                currentEnergy += energy[jump];

                if (currentEnergy > maxEnergy)
                {
                    maxEnergy = currentEnergy;
                }

                jump -= k;
            }
        }

        return maxEnergy;
    }
}
