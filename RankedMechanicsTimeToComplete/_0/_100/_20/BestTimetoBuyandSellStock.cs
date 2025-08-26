namespace LeetCodeSolutions._0._100._20;

/***
URL: https://leetcode.com/problems/best-time-to-buy-and-sell-stock
Number: 121
Difficulty: Easy
 */
public class BestTimetoBuyandSellStock
{
    public int MaxProfit(int[] prices)
    {
        var bestVal = 0;
        var minVal = int.MaxValue;
        var maxVal = 0;

        for (var i = 0; i < prices.Length; i++)
        {
            if (prices[i] < minVal)
            {
                var currentVal = maxVal - minVal;

                if (bestVal < currentVal)
                {
                    bestVal = currentVal;
                }

                minVal = prices[i];
                maxVal = 0;
            }

            if (prices[i] > maxVal)
            {
                maxVal = prices[i];
            }
        }

        var newVal = maxVal - minVal;

        if (bestVal < newVal)
        {
            bestVal = newVal;
        }

        return bestVal;
    }
}
