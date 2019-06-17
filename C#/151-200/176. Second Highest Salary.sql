/* Write your T-SQL query statement below */
SELECT ISNULL( (SELECT DISTINCT Salary FROM Employee ORDER BY Salary DESC OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY), NULL) AS SecondHighestSalary