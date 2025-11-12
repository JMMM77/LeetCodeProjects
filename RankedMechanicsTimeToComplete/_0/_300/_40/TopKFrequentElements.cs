namespace LeetCodeSolutions._0._300._40;

/***
URL: https://leetcode.com/problems/top-k-frequent-elements
Number: 347
Difficulty: Medium
*/
public class TopKFrequentElements
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        var n = nums.Length;
        var numFreqs = new Dictionary<int, int>(); // <Number, Occurences>

        for (var i = 0; i < n; i++)
        {
            if (!numFreqs.TryGetValue(nums[i], out var foundFreq))
            {
                foundFreq = 0;
            }

            numFreqs[nums[i]] = ++foundFreq;
        }

        var sortedDict = new Dictionary<int, List<int>>();

        foreach (var (num, freq) in numFreqs)
        {
            if (!sortedDict.TryGetValue(freq, out var foundList))
            {
                foundList = [];
            }

            foundList.Add(num);
            sortedDict[freq] = foundList;
        }

        var keyList = new List<int>();

        foreach (var key in sortedDict.Keys)
        {
            keyList.Add(key);
        }

        keyList.Sort();

        var numX = 0;
        var answer = new List<int>();

        for (var j = keyList.Count - 1; j >= 0 && numX < k; j--)
        {
            var thisFreq = keyList[j];
            var theseNums = sortedDict[thisFreq];

            theseNums.Sort();

            for (var y = theseNums.Count - 1; y >= 0; y--)
            {
                var thisNum = theseNums[y];

                if (numX == k)
                {
                    break;
                }

                answer.Add(thisNum);
                numX++;
            }
        }

        return [.. answer];
    }
}
