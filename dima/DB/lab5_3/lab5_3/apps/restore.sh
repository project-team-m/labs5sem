#!/bin/bash
PGPASSWORD=password
export PGPASSWORD
pg_restore -h 62.109.15.226 -U user_1 -F c -d dima_lab5 $1
