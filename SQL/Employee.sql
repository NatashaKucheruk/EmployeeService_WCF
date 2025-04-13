IF	OBJECT_ID('Employee', 'U') IS NOT NULL
    DROP TABLE Employee;
GO
CREATE TABLE Employee (
    ID INT PRIMARY KEY,
    Name VARCHAR(100),
    ManagerID INT,
    Enable BIT
);