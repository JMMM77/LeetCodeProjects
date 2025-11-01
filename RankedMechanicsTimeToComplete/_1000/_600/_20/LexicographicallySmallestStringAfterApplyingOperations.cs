using System.Text;

namespace LeetCodeSolutions._1000._600._20;

/***
URL: https://leetcode.com/problems/lexicographically-smallest-string-after-applying-operations
Number: 1625
Difficulty: Medium
 */
public class LexicographicallySmallestStringAfterApplyingOperations
{
    public string FindLexSmallestString(string s, int a, int b)
    {
        var sequenceToProcess = new Queue<string>();
        var foundSequences = new HashSet<string>()
        {
            s
        };

        sequenceToProcess.Enqueue(s);

        while (sequenceToProcess.Count != 0)
        {
            var thisNum = sequenceToProcess.Dequeue();

            // Add "a" to every odd index
            var aOp = thisNum.ToArray();

            for (var i = 1; i < thisNum.Length; i += 2)
            {
                aOp[i] = (char)('0' + ((aOp[i] - '0' + a) % 10));
            }

            var aOpString = new string(aOp) ?? "";

            if (!foundSequences.Contains(aOpString))
            {
                sequenceToProcess.Enqueue(aOpString);
                foundSequences.Add(aOpString);
            }

            // Rotate operation
            var rotateOp = new StringBuilder();

            for (var i = b; i < thisNum.Length + b; i++)
            {
                rotateOp.Append(thisNum[i % thisNum.Length]);
            }

            var rotateOpString = rotateOp.ToString();

            if (!foundSequences.Contains(rotateOpString))
            {
                sequenceToProcess.Enqueue(rotateOpString);
                foundSequences.Add(rotateOpString);
            }
        }

        var sequenceList = foundSequences.ToList();
        var minSequence = sequenceList[0];

        for (var i = 1; i < sequenceList.Count; i++)
        {
            var thisString = sequenceList[i];

            for (var j = 0; j < minSequence.Length; j++)
            {
                if (minSequence[j] == thisString[j])
                {
                    continue;
                }

                if (minSequence[j] > thisString[j])
                {
                    minSequence = thisString;
                }

                break;
            }
        }

        return minSequence;
    }
}
