namespace LeetCodeSolutions._3000._200._70;

/***
URL: https://leetcode.com/problems/find-the-count-of-good-integers
Number: 3272
Difficulty: Hard
*/
public class FindTheCountOfGoodIntegersProblem
{
    public long CountGoodIntegers(int n, int k)
    {
        var dict = new HashSet<string>();
        var baseVal = (int)Math.Pow(10, (n - 1) / 2);
        var skip = n & 1; // Check if n is odd

        // Loop through possible palindromic numbers with n digits
        for (var i = baseVal; i < baseVal * 10; i++)
        {
            var s = i.ToString();
            s += new string(s.Reverse().Skip(skip).ToArray()); // Create the palindrome number

            var palindromicInteger = long.Parse(s);

            // If it's divisible by k, it's a valid palindrome
            if (palindromicInteger % k == 0)
            {
                var chars = s.ToCharArray();
                Array.Sort(chars); // Sort characters to make sure we count unique permutations
                dict.Add(new string(chars));
            }
        }

        // Precompute factorials for efficient permutations calculation
        var factorial = new long[n + 1];
        factorial[0] = 1;
        for (var i = 1; i <= n; i++)
        {
            factorial[i] = factorial[i - 1] * i; // Factorial calculation
        }

        long ans = 0;

        // For each unique palindrome we've found, calculate permutations
        foreach (var s in dict)
        {
            var cnt = new int[10]; // Count digits from 0-9
            foreach (var c in s)
            {
                cnt[c - '0']++; // Count frequency of each digit
            }

            // Calculate the total number of permutations for the given string
            var tot = (n - cnt[0]) * factorial[n - 1]; // Start with the permutations of the remaining characters
            foreach (var x in cnt)
            {
                tot /= factorial[x]; // Divide by factorial of each digit's count to account for duplicates
            }

            ans += tot; // Add the result to the final answer
        }

        return ans; // Return the final count
    }
}
