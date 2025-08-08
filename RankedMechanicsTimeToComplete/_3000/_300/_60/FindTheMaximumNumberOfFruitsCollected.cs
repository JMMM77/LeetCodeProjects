namespace LeetCodeSolutions._3000._300._60;

/***
URL: https://leetcode.com/problems/find-the-maximum-number-of-fruits-collected
Number: 3363
Difficulty: Hard
 */
public class FindTheMaximumNumberOfFruitsCollected
{
    public int MaxCollectedFruits(int[][] fruits)
    {
        if (fruits.Length == 1)
        {
            return fruits[0][0];
        }

        var maxFruit = fruits[0][0];
        var maxNumOfMoves = fruits.Length - 1;
        var possibleSolutions1 = new Dictionary<int, int>() {
            { maxNumOfMoves, fruits[0][maxNumOfMoves] }
        }; // [i][fruits.Length-1]

        var possibleSolutions2 = new Dictionary<int, int>() {
            { maxNumOfMoves, fruits[maxNumOfMoves][0] }
        }; // [fruits.Length-1][i]

        for (var i = 1; i < maxNumOfMoves; i++)
        {
            maxFruit += fruits[i][i];

            var newPossibleSolutions1 = new Dictionary<int, int>();

            foreach (var path in possibleSolutions1)
            {
                var currentIndex = path.Key;
                var currentValue = path.Value;
                var indexUp = currentIndex + 1;

                if (indexUp <= maxNumOfMoves)
                {
                    ReplaceIfBigger(newPossibleSolutions1, indexUp, currentValue + fruits[i][indexUp]);
                }

                if (currentIndex > i && currentIndex <= maxNumOfMoves)
                {
                    ReplaceIfBigger(newPossibleSolutions1, currentIndex, currentValue + fruits[i][currentIndex]);
                }

                var indexDown = currentIndex - 1;

                if (indexDown > i)
                {
                    ReplaceIfBigger(newPossibleSolutions1, indexDown, currentValue + fruits[i][indexDown]);
                }
            }

            possibleSolutions1 = newPossibleSolutions1;

            var newPossibleSolutions2 = new Dictionary<int, int>();

            foreach (var path in possibleSolutions2)
            {
                var currentIndex = path.Key;
                var currentValue = path.Value;
                var indexUp = currentIndex + 1;

                if (indexUp <= maxNumOfMoves)
                {
                    ReplaceIfBigger(newPossibleSolutions2, indexUp, currentValue + fruits[indexUp][i]);
                }

                if (currentIndex > i && currentIndex <= maxNumOfMoves)
                {
                    ReplaceIfBigger(newPossibleSolutions2, currentIndex, currentValue + fruits[currentIndex][i]);
                }

                var indexDown = currentIndex - 1;

                if (indexDown > i)
                {
                    ReplaceIfBigger(newPossibleSolutions2, indexDown, currentValue + fruits[indexDown][i]);
                }
            }

            possibleSolutions2 = newPossibleSolutions2;
        }

        // Get final score
        maxFruit += fruits[^1][^1];

        var maxSolutionForPlayer1 = possibleSolutions1.Max(x => x.Value);
        var maxSolutionForPlayer2 = possibleSolutions2.Max(x => x.Value);

        return maxFruit + maxSolutionForPlayer1 + maxSolutionForPlayer2;
    }

    private static void ReplaceIfBigger(Dictionary<int, int> pathValues, int key, int newVal)
    {
        if (pathValues.TryGetValue(key, out var val))
        {
            if (val < newVal)
            {
                pathValues[key] = newVal;
            }
        }
        else
        {
            pathValues.Add(key, newVal);
        }
    }
}
