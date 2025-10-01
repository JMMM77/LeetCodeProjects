namespace LeetCodeSolutions._1000._500._10;

/***
URL: https://leetcode.com/problems/water-bottles
Number: 1518
Difficulty: Easy
 */
public class WaterBottles
{
    public int NumWaterBottles(int numBottles, int numExchange)
    {
        var numOfDrinks = numBottles;

        while (numBottles >= (float)numExchange)
        {
            var drankThisRound = numBottles / numExchange;

            numOfDrinks += drankThisRound;
            numBottles = drankThisRound + (numBottles % numExchange);

            Console.WriteLine(numBottles);
        }

        return numOfDrinks;
    }
}
