/* Write your T-SQL query statement below */
SELECT T.Request_at AS Day, 
        cast(
            SUM(CASE WHEN T.Status!='completed' THEN 1.0 ELSE 0.0 END)/COUNT(T.Id) AS DECIMAL(3,2) ) AS [Cancellation Rate]
FROM Trips AS T 
    JOIN Users AS C ON T.Client_Id = C.Users_Id AND C.Banned='No'
    JOIN Users AS D ON T.Driver_Id = D.Users_Id AND D.Banned='No'
    WHERE T.Request_at BETWEEN '2013-10-01' AND '2013-10-03'
    GROUP BY T.Request_at