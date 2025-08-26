namespace LeetCodeSolutions._0._600._70;

/***
URL: https://leetcode.com/problems/24-game
Number: 679
Difficulty: Hard
 */
internal class _24Game
{
    public bool JudgePoint24(int[] cards)
    {
        var combinations = new List<(int[], int[])>()
        {
            ([cards[0], cards[1]], [cards[2], cards[3]]),
            ([cards[0], cards[2]], [cards[1], cards[3]]),
            ([cards[0], cards[3]], [cards[1], cards[2]]),
            ([cards[1], cards[2]], [cards[0], cards[3]]),
            ([cards[1], cards[3]], [cards[0], cards[2]]),
            ([cards[2], cards[3]], [cards[0], cards[1]]),
        };

        var cache = new Dictionary<int[], HashSet<double>>();

        foreach (var comb in combinations)
        {
            if (!cache.ContainsKey(comb.Item1))
            {
                cache.Add(comb.Item1, GenerateSet(comb.Item1[0], comb.Item1[1]));
            }

            if (!cache.ContainsKey(comb.Item2))
            {
                cache.Add(comb.Item2, GenerateSet(comb.Item2[0], comb.Item2[1]));
            }

            foreach (var calc in cache[comb.Item1])
            {
                foreach (var calc2 in cache[comb.Item2])
                {
                    if (HashContains24(GenerateSet(calc, calc2)))
                    {
                        return true;
                    }
                }
            }

            if (TryCombo(cache[comb.Item1], comb.Item2))
            {
                return true;
            }
        }

        return false;
    }

    private static bool TryCombo(HashSet<double> currentCalcs, IList<int> cardsLeft)
    {
        if (cardsLeft.Count == 0 && HashContains24(currentCalcs))
        {
            return true;
        }

        foreach (var card in cardsLeft)
        {
            var newList = new List<int>(cardsLeft);
            newList.Remove(card);

            foreach (var calc in currentCalcs)
            {
                var theseCalcs = GenerateSet(card, calc);

                if (TryCombo(theseCalcs, newList))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static bool HashContains24(HashSet<double> set)
        => set.Any(x => Math.Abs(x - 24.0) < 1e-6);

    private static HashSet<double> GenerateSet(double num1, double num2)
    {
        var returnSet = new HashSet<double>()
        {
            num1 + num2,
            num1 - num2,
            num2 - num1,
            num1 * num2
        };

        // Make sure we dont divide by 0
        if (Math.Abs(num1) > 1e-6)
        {
            returnSet.Add(num2 / num1);
        }

        if (Math.Abs(num2) > 1e-6)
        {
            returnSet.Add(num1 / num2);
        }

        return returnSet;
    }
}
