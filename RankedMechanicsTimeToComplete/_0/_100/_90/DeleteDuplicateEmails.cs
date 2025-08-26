namespace LeetCodeSolutions._0._100._90;

/***
URL: https://leetcode.com/problems/delete-duplicate-emails
Number: 196
Difficulty: Easy
*/
public class DeleteDuplicateEmails
{
    public const string SQLQuery = """
        DELETE FROM Person WHERE id NOT IN (SELECT MIN(id) FROM Person GROUP BY email);
        """;
}
