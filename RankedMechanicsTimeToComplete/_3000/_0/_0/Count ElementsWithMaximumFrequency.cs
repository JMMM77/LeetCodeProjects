namespace LeetCodeSolutions._3000._0._0;

/***
URL: https://leetcode.com/problems/count-elements-with-maximum-frequency
Number: 3005
Difficulty: Easy
 */
public class Count_ElementsWithMaximumFrequency
{
    public int MaxFrequencyElements(int[] nums)
    {
        var dict = new Dictionary<int, int>();
        var maxFreq = 0;
        var numOfMaxFreq = 0;

        foreach (var item in nums)
        {
            if (dict.TryAdd(item, 1))
            {
                if (maxFreq == 0)
                {
                    maxFreq = 1;
                    numOfMaxFreq = 1;
                }
                else if (maxFreq == 1)
                {
                    numOfMaxFreq++;
                }

                continue;
            }

            var thisFreq = dict[item];

            thisFreq++;

            dict[item] = thisFreq;

            if (thisFreq > maxFreq)
            {
                maxFreq = thisFreq;
                numOfMaxFreq = 1;
            }
            else if (thisFreq == maxFreq)
            {
                numOfMaxFreq++;
            }
        }

        return numOfMaxFreq * maxFreq;
    }
}
