/* Write your T-SQL query statement below */
WITH Leadable AS (
    SELECT Num, 
            LEAD(Num, 1) OVER (ORDER BY Id ASC) AS lead1, 
            LEAD(Num, 2) OVER (ORDER BY Id ASC) AS lead2
    FROM Logs
)

SELECT DISTINCT Num AS ConsecutiveNums FROM Leadable WHERE Num = lead1 AND Num = lead2