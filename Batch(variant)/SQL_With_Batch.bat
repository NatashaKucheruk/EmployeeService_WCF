#!/bin/bash

# For connection to database /add currant
USER="***"
PASSWORD="***"
HOST="***"
DATABASE="Test"

# Create database
echo "CREATE database..."
sqlcmd -S $SERVER -U $USER -P $PASSWORD -Q "IF DB_ID('$DATABASE') IS NULL CREATE DATABASE [$DATABASE];"

# 2. Створення таблиці Employee
echo "CREATE Employee..."
sqlcmd -S $SERVER -U $USER -P $PASSWORD -d $DATABASE -Q "
IF OBJECT_ID('Employee', 'U') IS NOT NULL DROP TABLE Employee;
CREATE TABLE Employee (
    ID INT PRIMARY KEY,
    Name VARCHAR(100),
    ManagerID INT NULL,
    Enable BIT
);"

#  3.Fill Employee
echo "Filling..."
sqlcmd -S $SERVER -U $USER -P $PASSWORD -d $DATABASE -Q "
INSERT INTO Employee (ID, Name, ManagerID, Enable) VALUES
(1, 'Andrey', NULL, 1),
(2, 'Alexey', 1, 1),
(3, 'Nir', 2, 1),
(4, 'Smadar', 3, 1),
(5, 'Barak', 3, 1);
"

echo "Done!"