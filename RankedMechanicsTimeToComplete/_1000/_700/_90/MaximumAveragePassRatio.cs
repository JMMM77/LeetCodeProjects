namespace LeetCodeSolutions._1000._700._90;

/***
URL: https://leetcode.com/problems/maximum-average-pass-ratio
Number: 1792
Difficulty: Medium
 */
public class MaximumAveragePassRatio
{
    public double MaxAverageRatio(int[][] classes, int extraStudents)
    {
        // (passes, totalStudents)
        var maxHeap = new PriorityQueue<(int, int), double>();

        // Add the classes to the priority queue with their corresponding gains
        foreach (var singleClass in classes)
        {
            var passes = singleClass[0];
            var totalStudents = singleClass[1];
            var gain = CalculateGain(passes, totalStudents);

            maxHeap.Enqueue((passes, totalStudents), -gain);
        }

        // Distribute extra students
        while (extraStudents > 0)
        {
            // Get the class with the highest gain
            var (passes, totalStudents) = maxHeap.Dequeue();
            var newGain = CalculateGain(passes + 1, totalStudents + 1);

            maxHeap.Enqueue((passes + 1, totalStudents + 1), -newGain);

            extraStudents--;
        }

        // Calculate the final average pass ratio
        double totalPassRatio = 0;

        while (maxHeap.Count > 0)
        {
            var (passes, totalStudents) = maxHeap.Dequeue();

            totalPassRatio += (double)passes / totalStudents;
        }

        return totalPassRatio / classes.Length;
    }

    // Lambda to calculate the gain of adding an extra student
    private static double CalculateGain(int passes, int totalStudents)
        => (double)(passes + 1) / (totalStudents + 1) - (double)passes / totalStudents;
}
