namespace LeetCodeSolutions._1000._800._50;

/***
URL: https://leetcode.com/problems/maximum-population-year
Number: 1854
Difficulty: Easy
 */
public class MaximumPopulationYear
{
    public int MaximumPopulation(int[][] logs)
    {
        var years = new int[100];

        foreach (var x in logs)
        {
            var birthYear = x[0] - 1950;
            var deathYear = x[1] - 1950;

            for (var i = birthYear; i < deathYear; i++)
            {
                years[i]++;
            }
        }

        var maxVal = int.MinValue;
        var minIndex = -1;

        for (var i = 0; i < years.Length; i++)
        {
            if (maxVal < years[i])
            {
                maxVal = years[i];
                minIndex = i;
            }
        }

        return 1950 + minIndex;
    }
}
