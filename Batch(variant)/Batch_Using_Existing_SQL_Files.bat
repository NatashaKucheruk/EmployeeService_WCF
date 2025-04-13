#!/bin/bash

# Fill currant
SERVER="***"
USER="**"
PASSWORD="***"

# Path
SQL_DIR="./SQL"

# Excecute !
echo "Run..."

sqlcmd -S $SERVER -U $USER -P $PASSWORD -i "$SQL/Create_Database_Test.sql"
sqlcmd -S $SERVER -U $USER -P $PASSWORD -d Test -i "$SQL/Employee.sql"
sqlcmd -S $SERVER -U $USER -P $PASSWORD -d Test -i "$SQL/Fill_Employee.sql"

echo "Done!"
