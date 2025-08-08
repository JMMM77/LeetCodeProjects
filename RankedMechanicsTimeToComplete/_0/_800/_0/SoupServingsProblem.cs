namespace LeetCodeSolutions._0._800._0;

/***
URL: https://leetcode.com/problems/soup-servings
Number: 808
Difficulty: Medium
 */
public class SoupServingsProblem
{
    private double soupAProb = 0;
    private double sameTimeProb = 0;

    public double SoupServings(int n)
    {
        if (n > 4800) return 1.0; // Converges to one

        var soupServingsLeft = new Dictionary<(int, int), double>() { { (n, n), 1.0 } };

        while (soupServingsLeft.Count != 0)
        {
            var newSoupServingsLeft = new Dictionary<(int, int), double>();

            foreach (var serving in soupServingsLeft)
            {
                // Method 1
                var soupAMethod1 = serving.Key.Item1 - 100;
                newSoupServingsLeft = CheckValues(newSoupServingsLeft, soupAMethod1, serving.Key.Item2, serving.Value);

                // Method 2
                var soupAMethod2 = serving.Key.Item1 - 75;
                var soupBMethod2 = serving.Key.Item2 - 25;
                newSoupServingsLeft = CheckValues(newSoupServingsLeft, soupAMethod2, soupBMethod2, serving.Value);

                // Method 3
                var soupAMethod3 = serving.Key.Item1 - 50;
                var soupBMethod3 = serving.Key.Item2 - 50;
                newSoupServingsLeft = CheckValues(newSoupServingsLeft, soupAMethod3, soupBMethod3, serving.Value);

                // Method 4
                var soupAMethod4 = serving.Key.Item1 - 25;
                var soupBMethod4 = serving.Key.Item2 - 75;
                newSoupServingsLeft = CheckValues(newSoupServingsLeft, soupAMethod4, soupBMethod4, serving.Value);
            }

            soupServingsLeft = newSoupServingsLeft;
        }

        return soupAProb + (sameTimeProb / 2);
    }

    private Dictionary<(int, int), double> CheckValues(Dictionary<(int, int), double> currentList, int num1, int num2, double probability)
    {
        if (num1 <= 0 && num2 <= 0)
        {
            sameTimeProb += probability * 0.25;
        }
        else if (num1 <= 0)
        {
            soupAProb += probability * 0.25;
        }
        else if (num2 > 0)
        {
            if (currentList.ContainsKey((num1, num2)))
            {
                currentList[(num1, num2)] += probability * 0.25;
            }
            else
            {
                currentList.Add((num1, num2), probability * 0.25);
            }
        }

        return currentList;
    }
}
