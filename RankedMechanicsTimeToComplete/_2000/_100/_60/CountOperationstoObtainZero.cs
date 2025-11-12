namespace LeetCodeSolutions._2000._100._60;

/***
URL: https://leetcode.com/problems/count-operations-to-obtain-zero
Number: 2169
Difficulty: Easy
 */
public class CountOperationstoObtainZero
{
    public int CountOperations(int num1, int num2)
    {
        var numOfOps = 0;

        while (num1 != 0 && num2 != 0)
        {
            if (num1 >= num2)
            {
                num1 -= num2;
            }
            else
            {
                num2 -= num1;
            }

            numOfOps++;
        }

        return numOfOps;
    }
}
