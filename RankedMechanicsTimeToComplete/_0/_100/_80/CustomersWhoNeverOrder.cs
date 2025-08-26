namespace LeetCodeSolutions._0._100._80;

/***
URL: https://leetcode.com/problems/customers-who-never-order
Number: 183
Difficulty: Easy
*/
public class CustomersWhoNeverOrder
{
    public const string SQLQuery = """
        SELECT Customers.name as Customers FROM Customers
        LEFT JOIN Orders ON Customers.id = Orders.customerId
        WHERE Orders.Id IS NULL;
        """;
}
