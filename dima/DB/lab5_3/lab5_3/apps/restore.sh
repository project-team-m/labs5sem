#!/bin/bash
PGPASSWORD=password
export PGPASSWORD
pg_restore -h 188.225.76.56 -U user_1 -c -F c -d dima_lab5 $1
