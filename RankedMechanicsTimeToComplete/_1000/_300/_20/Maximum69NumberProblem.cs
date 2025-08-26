namespace LeetCodeSolutions._1000._300._20;

/***
URL: https://leetcode.com/problems/maximum-69-number
Number: 1323
Difficulty: Easy
 */
public class Maximum69NumberProblem
{
    public int Maximum69Number(int num)
    {
        var numString = num.ToString().ToCharArray();

        for (var i = 0; i < numString.Length; i++)
        {
            if (numString[i] == '6')
            {
                numString[i] = '9';
                break;
            }
        }

        return int.Parse(numString);
    }
}
