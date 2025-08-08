namespace LeetCodeSolutions._0._100._40;

/***
URL: https://leetcode.com/problems/solving-questions-with-brainpower
Topics: Array, Dynamic Programming
Number: 2140
Difficulty: Medium
 */

public class SolvingQuestionsWithBrainpowerProblem
{
    public long MostPoints(int[][] questions)
    {
        // Store the max points for each question
        var questionPoints = new Dictionary<int, long>();
        var lastQuestionIndex = questions.Length - 1;
        questionPoints.Add(lastQuestionIndex, questions[lastQuestionIndex][0]);

        for (var i = lastQuestionIndex - 1; i > -1; i--)
        {
            var currentQuestion = questions[i]; // [points, brainPower]
            long points = currentQuestion[0];
            var brainPower = currentQuestion[1];
            var nextAvailableQuestion = i + brainPower + 1;

            if (nextAvailableQuestion < questions.Length)
            {
                var earliestNextQuestion = questionPoints[nextAvailableQuestion];

                points += earliestNextQuestion; // Keep adding the points from the next potential question, saves having to keep reprocessing the same steps
            }

            var nextQuestion = questionPoints[i + 1];

            if (points < nextQuestion)
            {
                points = nextQuestion; // No point going doing this question if the question after it has a bigger value
            }

            questionPoints.Add(i, points);
        }

        return questionPoints.Max(x => x.Value);
    }
}
