CREATE FUNCTION getNthHighestSalary(@N INT) RETURNS INT AS
BEGIN
    RETURN (
        /* Write your T-SQL query statement below. */
        SELECT TOP 1 s.Salary FROM 
            (SELECT Salary, DENSE_RANK() OVER (ORDER BY Salary DESC) AS Rank FROM Employee) AS s
             WHERE s.Rank = @N
    );
END