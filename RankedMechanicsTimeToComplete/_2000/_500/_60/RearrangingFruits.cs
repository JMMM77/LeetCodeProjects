namespace LeetCodeSolutions._2000._500._60;

/***
URL: https://leetcode.com/problems/rearranging-fruits
Number: 2561
Difficulty: Hard
 */
public class RearrangingFruits
{
    public long MinCost(int[] basket1, int[] basket2)
    {
        var allNumbers = basket1.Concat(basket2);

        var fruitAppearances = new Dictionary<int, int>();

        foreach (var num in allNumbers)
        {
            if (fruitAppearances.TryGetValue(num, out var val))
            {
                fruitAppearances[num] = val + 1;
                continue;
            }

            fruitAppearances.Add(num, 1);
        }

        if (fruitAppearances.Any(x => x.Value % 2 != 0))
        {
            return -1;
        }

        var fruitsInBasket1 = new Dictionary<int, int>();

        foreach (var fruit in basket1)
        {
            if (fruitsInBasket1.ContainsKey(fruit))
            {
                fruitsInBasket1[fruit]++;
                continue;
            }

            fruitsInBasket1.Add(fruit, 1);
        }

        var fruitsToMove = new List<int>();

        foreach (var fruit in fruitAppearances)
        {
            var fruitsNeeded = (fruit.Value / 2);

            if (fruitsInBasket1.TryGetValue(fruit.Key, out var val))
            {
                fruitsNeeded -= val;
            }

            if (fruitsNeeded != 0)
            {
                if (fruitsNeeded < 0)
                {
                    fruitsNeeded = 0 - fruitsNeeded;
                }

                for (var i = 0; i < fruitsNeeded; i++)
                {
                    fruitsToMove.Add(fruit.Key);
                }
            }
        }

        fruitsToMove.Sort();

        // Used to check if double swapping with the smallest number is cheaper 
        var doubleSwap = 2 * allNumbers.Min();
        long cost = 0;

        for (var i = 0; i < fruitsToMove.Count / 2; i++)
        {
            var smallestNum = fruitsToMove[i];

            // Add to cost
            cost += Math.Min(smallestNum, doubleSwap);
        }

        return cost;
    }
}
