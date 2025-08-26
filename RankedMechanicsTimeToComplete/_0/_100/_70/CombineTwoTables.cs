namespace LeetCodeSolutions._0._100._70;

/***
URL: https://leetcode.com/problems/combine-two-tables
Number: 175
Difficulty: Easy
*/
public class CombineTwoTables
{
    public const string SQLQuery = """
        SELECT firstName, lastName, city, state FROM Person as p
        LEFT JOIN Address as a ON p.personId = a.personId;
        """;
}
