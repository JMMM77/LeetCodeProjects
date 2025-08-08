namespace LeetCodeSolutions._0._100._40;
/***
URL: https://leetcode.com/problems/count-the-hidden-sequences
Number: 2145
Difficulty: Medium
 */
public class CountTheHiddenSequencesProblem
{
    // upper/lower bound
    public int NumberOfArrays(int[] differences, int lower, int upper)
    {
        var lowest = 0; // temp
        var highest = 0; // temp
        var current = 0;

        foreach (var diff in differences)
        {
            current += diff;
            lowest = Math.Min(lowest, current);
            highest = Math.Max(highest, current);

            if (highest - lowest > upper - lower)
            {
                return 0;
            }
        }

        return (upper - lower) - (highest - lowest) + 1;
    }

    // Timeout
    public int NumberOfArrays1(int[] differences, int lower, int upper)
    {
        // hidden = [4, 5, 2, 6]
        // differences = [1, -3, 4]
        // lower = 1
        // upper = 6

        // difference.Length + 1 = hidden.length
        // difference[0] = hidden[1] - hidden[0] == differences[i] = hidden[i + 1] - hidden[i]
        // difference[1] = hidden[2] - hidden[1] == differences[i] = hidden[i + 1] - hidden[i]
        // difference[2] = hidden[3] - hidden[2] == differences[i] = hidden[i + 1] - hidden[i]
        // hidden = [4, 5, 2, 6], [3, 4, 1, 5] / [5, 6, 3, 7], [1, 2, 3, 4]

        var foundPreviousValues = new List<int>();

        for (var i = lower; i <= upper; i++)
        {
            var nextNum = differences[0] + i;

            if (lower <= nextNum && nextNum <= upper)
            {
                foundPreviousValues.Add(nextNum);
            }
        }

        for (var i = 1; foundPreviousValues.Count != 0 && i < differences.Length; i++)
        {
            var newFoundNumbers = new List<int>();

            for (var j = 0; j < foundPreviousValues.Count; j++)
            {
                var nextNum = differences[i] + foundPreviousValues[j];

                if (lower <= nextNum && nextNum <= upper)
                {
                    newFoundNumbers.Add(nextNum);
                }
            }

            foundPreviousValues = newFoundNumbers;
        }

        return foundPreviousValues.Count;
    }
}
