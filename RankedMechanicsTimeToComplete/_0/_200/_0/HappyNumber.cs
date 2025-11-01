namespace LeetCodeSolutions._0._200._0;

/***
URL: https://leetcode.com/problems/happy-number
Number: 202
Difficulty: Easy
 */
public class HappyNumber
{
    public bool IsHappy(int n)
    {
        var foundNums = new HashSet<int>();

        while (n != 1)
        {
            if (foundNums.Contains(n))
            {
                return false;
            }

            foundNums.Add(n);

            var thisSum = 0;

            while (n > 0)
            {
                var digit = n % 10;

                thisSum += digit * digit;
                n /= 10;
            }

            n = thisSum;
        }

        return true;
    }
}
