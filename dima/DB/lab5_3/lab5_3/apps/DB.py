import psycopg2
from psycopg2 import sql

tables = ['components', 'brands', 'stock', 'stocks', 'workers', 'positions', 'orders', 'clients', 'basket']

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
            stmt = sql.SQL('SELECT components.id, components.name, purchase_price, selling_price, clock, cores, threads,'
                           ' clock_memory, bus_width, memory, timing, brands.name '
                           'FROM components INNER JOIN brands ON components.id_brand = brands.id;')

            cursor.execute(stmt)
            return [('id', 'name', 'purchase price', 'selling price', 'clock', 'cores', 'threads', 'clock_memory', 'bus width', 'memory', 'timing', 'brand')] + cursor.fetchall()

    def show_brands(self):
        with self.conn.cursor() as cursor:
            stmt = sql.SQL('SELECT * '
                           'FROM brands;')

            cursor.execute(stmt)
            return [('id', 'name')] + cursor.fetchall()

    def show_stocks(self):
        with self.conn.cursor() as cursor:
            stmt = sql.SQL('SELECT stocks.id, stocks.name, inn, ogrn, stocks.address, date_create, workers.name '
                           'FROM stocks INNER JOIN workers ON stocks.id_storekeeper= workers.id;')

            cursor.execute(stmt)
            return [('id', 'name', 'inn', 'ogrn', 'address', 'date create', 'storekeeper')] + cursor.fetchall()

    def show_stock(self):
        with self.conn.cursor() as cursor:
            stmt = sql.SQL('SELECT stock.id, components.name, stocks.name, stocks.address, balance '
                           'FROM (stock INNER JOIN components ON components.id = stock.id_component)'
                           'INNER JOIN stocks ON stock.id_stock = stocks.id;')

            cursor.execute(stmt)
            return [('id', 'component name', 'stock name', 'stock address', 'balance')] + cursor.fetchall()

    def show_clients(self):
        with self.conn.cursor() as cursor:
            stmt = sql.SQL('SELECT id, name, phone_number, discount_card, login, password '
                           'FROM clients;')

            cursor.execute(stmt)
            return [('id', 'name', 'phone number', 'discount_card', 'login', 'password')] + cursor.fetchall()

    def show_workers(self):
        with self.conn.cursor() as cursor:
            stmt = sql.SQL('SELECT workers.id, workers.name, login, password, address, phone_number, positions.name, email, date_employment '
                           'FROM workers INNER JOIN positions ON workers.id_position = positions.id;')

            cursor.execute(stmt)
            return [('id', 'name', 'login', 'password', 'address', 'phone_number', 'positions name', 'email', 'date employment')] + cursor.fetchall()

    def show_positions(self):
        with self.conn.cursor() as cursor:
            stmt = sql.SQL('SELECT * '
                           'FROM positions;')

            cursor.execute(stmt)
            return [('id', 'name')] + cursor.fetchall()

    def show_orders(self):
        with self.conn.cursor() as cursor:
            stmt = sql.SQL('SELECT orders.id, date_order, workers.name, discount '
                           'FROM orders INNER JOIN workers ON orders.id_manager = workers.id;')

            cursor.execute(stmt)
            return [('id', 'date order', 'manager name', 'discount')] + cursor.fetchall()

    def show_basket(self):
        with self.conn.cursor() as cursor:
            stmt = sql.SQL('SELECT basket.id, components.name, quantity, clients.name, id_order '
                           'FROM (basket INNER JOIN components ON components.id = basket.id_component)'
                           'INNER JOIN clients ON basket.id_client = clients.id;')

            cursor.execute(stmt)
            return [('id', 'compoent name', 'quantity', 'client name', 'order id')] + cursor.fetchall()

a = DB('a', 'a')
scripts = None
if __name__ == '__main__':
    a = DB('admin', 'admin')
    print(a.show_basket())