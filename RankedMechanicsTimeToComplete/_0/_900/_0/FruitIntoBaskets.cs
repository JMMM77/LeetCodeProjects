namespace LeetCodeSolutions._0._900._0;

/***
URL: https://leetcode.com/problems/fruit-into-baskets
Number: 904
Difficulty: Medium
 */
public class FruitIntoBaskets
{
    public int TotalFruit(int[] fruits)
    {
        var baskets = new Dictionary<int, int>();
        var lastOccuredFruit = -1;
        var countForRecursiveFruit = 0;
        var maxFound = 1;
        int tempCalc;
        var tempLastFruit = -1;
        var tempLastCount = -1;

        for (var i = 0; i < fruits.Length; i++)
        {
            var fruit = fruits[i];

            if (fruit == lastOccuredFruit)
            {
                countForRecursiveFruit++;
            }
            else
            {
                tempLastFruit = lastOccuredFruit;
                tempLastCount = countForRecursiveFruit;

                lastOccuredFruit = fruit;
                countForRecursiveFruit = 1;
            }

            if (baskets.ContainsKey(fruit))
            {
                baskets[fruit]++;
                continue;
            }

            if (baskets.Count < 2)
            {
                baskets.Add(fruit, 1);
                continue;
            }

            tempCalc = baskets.Values.Sum();

            if (maxFound < tempCalc)
            {
                maxFound = tempCalc;
            }

            baskets = new Dictionary<int, int>()
            {
                { tempLastFruit, tempLastCount },
                { fruit, 1}
            };
        }

        tempCalc = baskets.Values.Sum();

        if (maxFound < tempCalc)
        {
            maxFound = tempCalc;
        }

        return maxFound;
    }
}
