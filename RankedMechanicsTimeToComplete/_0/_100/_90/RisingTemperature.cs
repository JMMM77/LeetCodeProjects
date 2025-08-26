namespace LeetCodeSolutions._0._100._90;

/***
URL: https://leetcode.com/problems/rising-temperature
Number: 197
Difficulty: Easy
*/
public class RisingTemperature
{
    public const string SQLQuery = """
        SELECT w1.id FROM Weather as w1
        INNER JOIN Weather as w2 on DATEADD(day, -1, w1.recordDate) = w2.recordDate
        WHERE w1.temperature > w2.temperature;
        """;
}
