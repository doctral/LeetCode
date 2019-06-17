/* Write your T-SQL query statement below */

WITH PartitionRank AS
(
    SELECT d.Name AS Department, e.Name AS Employee, e.Salary AS Salary,
            DENSE_RANK() OVER (Partition by e.DepartmentId ORDER BY e.Salary DESC) AS Rank
    FROM Employee AS e 
        JOIN Department AS d ON e.DepartmentId = d.Id 
)

SELECT Department, Employee, Salary FROM PartitionRank WHERE Rank = 1
