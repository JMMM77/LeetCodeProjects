namespace LeetCodeSolutions._3000._300._10;

/***
URL: https://leetcode.com/problems/find-x-sum-of-all-k-long-subarrays-y
Number: 3318
Difficulty: Easy
*/
public class FindXSumofAllKLongSubarraysI
{
    public int[] FindXSum(int[] nums, int k, int x)
    {
        var n = nums.Length;
        var answer = new int[n - k + 1];
        var numFreqs = new Dictionary<int, int>(); // <Number, Occurences>

        for (var i = 0; i < k; i++)
        {
            if (!numFreqs.TryGetValue(nums[i], out var foundFreq))
            {
                foundFreq = 0;
            }

            numFreqs[nums[i]] = ++foundFreq;
        }

        answer[0] = GetXSum(numFreqs, x);

        for (var i = 1; i < n - k + 1; i++)
        {
            numFreqs[nums[i - 1]]--;

            if (!numFreqs.TryGetValue(nums[i + k - 1], out var foundFreq))
            {
                foundFreq = 0;
            }

            numFreqs[nums[i + k - 1]] = ++foundFreq;

            answer[i] = GetXSum(numFreqs, x);
        }

        return answer;
    }

    private int GetXSum(Dictionary<int, int> numFreqs, int x)
    {
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

        var thisSum = 0;
        var numX = 0;

        for (var j = keyList.Count - 1; j >= 0 && numX < x; j--)
        {
            var thisFreq = keyList[j];
            var theseNums = sortedDict[thisFreq];
            theseNums.Sort();

            for (var y = theseNums.Count - 1; y >= 0; y--)
            {
                var thisNum = theseNums[y];

                if (numX == x)
                {
                    break;
                }

                thisSum += thisFreq * thisNum;
                numX++;
            }
        }

        return thisSum;
    }
}
