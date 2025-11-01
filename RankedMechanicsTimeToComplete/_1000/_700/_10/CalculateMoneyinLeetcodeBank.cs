namespace LeetCodeSolutions._1000._700._10;

/***
URL: https://leetcode.com/problems/calculate-money-in-leetcode-bank
Number: 1716
Difficulty: Easy
 */
public class CalculateMoneyinLeetcodeBank
{
    public int TotalMoney(int n)
    {
        var prevMonday = 1;
        var prevDay = 1;
        var bankTotal = 1;
        var currentDay = 2;

        for (var i = 1; i < n; i++)
        {
            if (currentDay == 8)
            {
                currentDay = 2;
                bankTotal += ++prevMonday;
                prevDay = prevMonday;

                continue;
            }

            currentDay++;
            bankTotal += ++prevDay;
        }

        return bankTotal;
    }
}
