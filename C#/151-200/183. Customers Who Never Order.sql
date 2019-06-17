/* Write your T-SQL query statement below */

SELECT c.Name AS Customers FROM Customers AS c
    LEFT JOIN Orders AS o ON c.Id=o.CustomerId
    WHERE o.Id IS NULL
