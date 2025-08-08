namespace LeetCodeSolutions._3000._400._70;

/***
URL: https://leetcode.com/problems/fruits-into-baskets-ii
Number: 3477
Difficulty: Easy
 */
public class FruitsIntoBasketsII
{
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
    {
        var leftOverFruits = 0;

        foreach (var fruit in fruits)
        {
            var foundMatch = false;

            for (var i = 0; i < baskets.Length; i++)
            {
                if (fruit <= baskets[i])
                {
                    baskets[i] = 0;
                    foundMatch = true;
                    break;
                }
            }

            if (!foundMatch)
            {
                leftOverFruits++;
            }
        }

        return leftOverFruits;
    }
}
