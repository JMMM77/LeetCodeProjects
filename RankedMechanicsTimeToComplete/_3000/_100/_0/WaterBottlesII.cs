namespace LeetCodeSolutions._3000._100._0;

/***
URL: https://leetcode.com/problems/water-bottles-ii
Number: 3100
Difficulty: Medium
 */
public class WaterBottlesII
{
    public int MaxBottlesDrunk(int numBottles, int numExchange)
    {
        // Arithmetic series formula
        // empty = (timesExchanged x numExchange) + (2 x timesExchanged x (timesExchanged − 1)​)
        // total = numBottles + timesExchanged

        // empty <= total
        // (timesExchanged x numExchange) + (2 x timesExchanged x (timesExchanged − 1)​) <= numBottles + timesExchanged 
        // t^2 + ((2 x numExchange) − 3)t − (2 x numBottles) <= 0
        // Quadratic Equation: at² + bt + c = 0
        var a = 1;
        var b = 2 * numExchange - 3;
        var c = -2 * numBottles;

        // Quadratic formula to find peak
        var delta = (double)b * b - 4.0 * a * c;
        var timesExchanged = (int)Math.Ceiling((-b + Math.Sqrt(delta)) / (2.0 * a));

        return numBottles + timesExchanged - 1;
    }

    public int MaxBottlesDrunk1(int numBottles, int numExchange)
    {
        var numOfDrinks = numBottles;

        while (numBottles >= numExchange)
        {
            numOfDrinks++;
            numBottles -= numExchange - 1;
            numExchange++;
        }

        return numOfDrinks;
    }
}
