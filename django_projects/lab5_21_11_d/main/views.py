from django.shortcuts import render
from django.http import HttpResponse
import psycopg2

def test_1():
    conn = psycopg2.connect(dbname='test_1', user='*',
                            password='*', host='62.109.15.226')
    cursor = conn.cursor()
    cursor.execute('SELECT * FROM a')
    records = cursor.fetchall()
    print(records)
    cursor.close()
    conn.close()


def send_main(request):
    return HttpResponse("Hello, world. You're at the polls index.")

if __name__ == '__main__':
    test_1()