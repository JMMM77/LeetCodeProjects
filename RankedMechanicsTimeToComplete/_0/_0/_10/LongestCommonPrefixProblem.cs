namespace LeetCodeSolutions._0._0._10;

/***
URL: https://leetcode.com/problems/longest-common-prefix
Number: 14
Difficulty: Easy
 */
public class LongestCommonPrefixProblem
{
    public string LongestCommonPrefix(string[] strs)
    {
        var prefix = strs[0];

        for (var i = 1; i < strs.Length; i++)
        {
            var currentStr = strs[i];

            if (prefix == "" || currentStr == "" || prefix[0] != currentStr[0])
            {
                return "";
            }

            var newPrefix = new List<char>() { currentStr[0] };
            var prefixPointer = 1;

            while (prefixPointer < currentStr.Length && prefixPointer < prefix.Length)
            {
                if (prefix[prefixPointer] != currentStr[prefixPointer])
                {
                    break;
                }

                newPrefix.Add(prefix[prefixPointer]);
                prefixPointer++;
            }

            prefix = string.Concat(newPrefix);
        }

        return prefix;
    }
}