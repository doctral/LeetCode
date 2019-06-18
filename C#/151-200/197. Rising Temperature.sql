/* Write your T-SQL query statement below */
SELECT w2.Id AS Id FROM Weather w1 
    LEFT JOIN Weather w2 ON w1.RecordDate = DateAdd(day, -1, w2.RecordDate)
    WHERE w1.Temperature < w2.Temperature