namespace LeetCodeSolutions._0._100._80;

/***
URL: https://leetcode.com/problems/duplicate-emails
Number: 182
Difficulty: Easy
*/
public class DuplicateEmails
{
    public const string SQLQuery = """
        SELECT email as Email FROM Person
        GROUP BY email
        HAVING COUNT(*) > 1;
        """;
}
