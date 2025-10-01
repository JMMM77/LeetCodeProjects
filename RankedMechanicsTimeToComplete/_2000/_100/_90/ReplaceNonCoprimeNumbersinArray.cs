namespace LeetCodeSolutions._2000._100._90;

/***
URL: https://leetcode.com/problems/replace-non-coprime-numbers-in-array
Number: 2197
Difficulty: Hard
 */
public class ReplaceNonCoprimeNumbersinArray
{
    public IList<int> ReplaceNonCoprimes(int[] nums)
    {
        var stack = new Stack<int>();

        foreach (var num in nums)
        {
            var currentNum = num;

            while (stack.Count > 0)
            {
                var top = stack.Peek();
                var gcd = GetGreatestCommonDivisor(currentNum, top);

                if (gcd == 1)
                {
                    break;
                }

                currentNum = GetLeastCommonMultiple(currentNum, stack.Pop(), gcd);
            }

            stack.Push(currentNum);
        }

        var result = new List<int>(stack);

        result.Reverse();

        return result;
    }

    // GCD via Euclidean algorithm
    private int GetGreatestCommonDivisor(int a, int b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    // Are we supposed to memorise all these formulas? Or can we google?
    // LCM(a, b) = a / GCD(a, b) * b
    private int GetLeastCommonMultiple(int a, int b, int gcd)
    {
        return a / gcd * b;
    }
}
