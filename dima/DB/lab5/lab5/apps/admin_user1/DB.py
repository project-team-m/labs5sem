import psycopg2
from psycopg2 import sql

class DB():
    def __init__(self, login, password):
        self.conn = psycopg2.connect(dbname='dima_lab5', user='user_1',
                                password='password', host='62.109.15.226')

        self.login = None
        self.lvl = None

        with self.conn.cursor() as cursor:
            columns = ['id', 'login', 'password']
            stmt = sql.SQL('SELECT {} FROM {}').format(
                sql.SQL(',').join(map(sql.Identifier, columns)),
                sql.Identifier('clients')
            )

            cursor.execute(stmt)
            for row in cursor:
                if login.lower() == row[1] and password == row[2]:
                    self.login = login.lower()
                    self.lvl = 0
                    break

            if not self.login:
                columns = ['id', 'login', 'password', 'id_position']
                stmt = sql.SQL('SELECT {} FROM {}').format(
                    sql.SQL(',').join(map(sql.Identifier, columns)),
                    sql.Identifier('workers')
                )

                cursor.execute(stmt)

                for row in cursor:
                    if login.lower() == row[1] and password == row[2]:
                        self.login = login
                        self.lvl = row[3]
        if not self.login:
            self.conn = None

    def show_components(self):
        with self.conn.cursor() as cursor:
            tables = ['components', 'brands']
            columns = [tables[0] + '.' + 'id', 'name', 'purchase_price', 'selling_price', 'clock', 'cores',
                       'threads', 'clock_memory', 'bus_width', 'memory', 'timing']
            stmt = sql.SQL('SELECT components.id, components.name, purchase_price, selling_price, clock, cores, threads,'
                           ' clock_memory, bus_width, memory, timing, brands.name '
                           'FROM components INNER JOIN brands ON components.id_brand = brands.id')

            cursor.execute(stmt)
            return [['id', 'name', 'purchase_price', 'selling_price', 'clock', 'cores', 'threads', 'clock_memory', 'bus_width', 'memory', 'timing', 'brand'] + cursor.fetchall()]

if __name__ == '__main__':
    a = DB('admin', 'admin')
    print(a.show_components())