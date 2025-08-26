namespace LeetCodeSolutions._0._100._80;

/***
URL: https://leetcode.com/problems/employees-earning-more-than-their-managers
Number: 181
Difficulty: Easy
*/
public class EmployeesEarningMoreThanTheirManagers
{
    public const string SQLQuery = """
        SELECT e1.name as 'Employee' FROM Employee as e1
        INNER JOIN Employee as e2 ON e1.managerId = e2.id
        WHERE e1.salary > e2.salary;
        """;
}
