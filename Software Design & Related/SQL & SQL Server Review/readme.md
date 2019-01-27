# SQL & SQL Server Review

## SQL
1. Constraints: primary key, foreign key, not null, unique, check, default, index.
2. Stored Procedure VS Trigger
    1. Stored procedure can be executed whenever we want, but trigger can only be executed when an event happened.
    2.	Stored procedure can take input parameter and return values, but trigger cannot take input parameter or return value
    3.	Stored procedure can have transaction inside, but trigger cannot contain transaction.
    4.	Stored procedures are used to perform tasks; triggers can be used for auditing tasks.
3.	Transaction: a group of database operations that is performed as a whole unit, it helps to maintain the integrity of data. It follows ACID rules:
    1.	Atomicity, as a whole
    2.	Consistency, from one consistent state to another.
    3.	Isolation: each transaction should work independently.
    4.	Durability, any change made by transaction should be permanent.
4. 	Database Normalization: a process of minimizing redundancy and dependency by organizing fields and table of a database. Redundancy means storing data twice, thus make the system faster.
    1.	First Normal Form: no multi-valued attribute or composite attribute. (Single-value attribute)
    2.	Second Normal Form: first normal form without partial dependency, all non-key attributes are fully functional dependent on primary key. (No Partial Dependency)
    3.	Third Normal Form: second normal form without transitive dependency. (No Transitive Dependency)
5. 	Delete, truncate, and drop
    1.	Delete, used to remove rows from the table, commit and rollback can be performed.
    2.	Truncate, remove all rows from a table, cannot be rolled back.
    3.	Drop, cannot be rolled back.
6.	Having vs WHERE: 
    1. Having is used to check conditions after the aggregation functions, i.e: AVG(), COUNT(), MAX(), etc. 
    2. Where can be used to before the aggregation function.
7.	Different types of SQL:
    1.	DDL, data definition language, CREATE, ALTER, DROP, TRANCATE, RENAME
    2.	DML, data manipulation language, SELECT, INSERT, UPDATE, DELETE
    3.	DCL, data control language, GRANT, DENY, REVOKE
    4.	TCL, transaction control language, COMMIT, ROLLBACK  
8.	VARCHAR and NVARCHAR:
    1. VARCHAR stores ASCII data and each char uses one byte
    2. NVARCHAR stores Unicode data and each char uses two bytes.
9.	View VS temp table
    1.	View exists only for a single query; the data in a view is always current.
    2.	Temp table exists for the entire database session; it retains the data until the session ends.
10.	Online Transaction Processing (OLTP) VS Online Analytical Processing (OLAP)
    1.	OLTP: allows for CRUD operations
    2.	OLAP: complex query, allows for read-only operation or other analysis purpose.
11.	Index: is a special lookup table/data structure to speed up database search and the query performance, can be created in tables or views. Three types of Indexes:
    1.	Unique index: no duplicates or null values allowed.
    2.	Clustered Index: reorder the physical order of the table in either ascending or descending order and physically stores rows of data. Queries will run faster, but update operation = delete + insert to maintain sorted order.  One table can only have one clustered index.
    3.	Non-Clustered Index: contains the values of indexed columns and pointers to data rows instead of data rows themselves. One table can have multiple non-clustered rows. 
    4.	Index should be avoided on small tables or columns are frequently manipulated or contain a high number of null.
12.	Query execution plan: tells how a query will be executed, or how a query was executed, it’s a primary mean of troubleshooting a poorly performing query.
    1.	Estimated Execution plan
    2.	Actual execution plan.    
13. View and CTE (Common Table Expression)
    1. CTE are temporary and will be created when they are used, just like a subquery. CTE can be called recursively, while views cannot.
    2. Views can be indexed, while CTE cannot be.
14. ISNULL, NULLIF, COALESCE:
    1. ISNULL(exp1, value): if exp1 is null, return value, otherwise, return exp1
    2. NULLIF(exp1, exp2): if exp1 == exp2, return null, otherwise, return exp1
    3. COALESCE(exp1, exp2, ...): return first not-null exp in the list 





 


