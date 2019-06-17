# Write your MySQL query statement below
DELETE FROM Person WHERE Id NOT IN 
    (SELECT A.Id FROM 
        (SELECT MIN(Id) AS Id FROM Person GROUP BY Email) AS A)