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

    def rollback(self):
        with self.conn.cursor() as cursor:
            cursor.execute('rollback;')

    def trans(self, args, show):
        mass = [args]
        for i in range(len(show)):
            mass.append([])
            for j in range(len(args)):
                mass[i + 1].append([args[j], show[i][j]])

        return mass

    def change_to_norm_none(self, arg):
        if arg.lower() == 'none' or arg.lower() == 'null' or arg == '':
            return None
        else:
            return arg

    def end_res_add(self, args, mass):
        args_new = []
        mass_new = []
        for i in range(len(args)):
            if mass[i]:
                args_new.append(args[i])
                mass_new.append(mass[i])

        return args_new, mass_new

    def crt_update(self, args, mass, table):
        string = 'UPDATE {} SET {} = {}'.format(table, args[0], mass[0])
        for i in range(1, len(args)):
            if mass[i]:
                try:
                    string += ', {} = {}'.format(args[i], int(mass[i]))
                except:
                    string += ", {} = '{}'".format(args[i], mass[i])
            else:
                string += ', {} = null'.format(args[i])
        string += ' WHERE id={};'.format(mass[-1])

        return string

    def show_components(self):
        with self.conn.cursor() as cursor:
            stmt = sql.SQL('SELECT id, name, purchase_price, selling_price, clock, cores, threads,'
                           ' clock_memory, bus_width, memory, timing, id_brand '
                           'FROM components;')

            cursor.execute(stmt)
            return self.trans(('id', 'name', 'purchase price', 'selling price', 'clock', 'cores', 'threads', 'clock memory', 'bus width', 'memory', 'timing', 'id brand'),
                               cursor.fetchall())

    def enter_component(self, mass):
        with self.conn.cursor() as cursor:
            args = ['id', 'name', 'purchase_price',
                    'selling_price', 'clock', 'cores', 'threads',
                    'clock_memory', 'bus_width', 'memory', 'timing', 'id_brand']
            if mass[-1] == 'id':
                stmt = sql.SQL('INSERT INTO components({}) VALUES ({}) ;').format(
                    sql.SQL(',').join(map(sql.Identifier, args)),
                    sql.SQL(',').join(map(sql.Literal, mass[:12])))
            else:
                stmt = self.crt_update(args, mass, 'components')
            cursor.execute(stmt)
            #self.conn.commit()

    def del_string(self, old, table):
        with self.conn.cursor() as cursor:
            stmt = "DELETE FROM {} WHERE id = {} ;".format(table, old)

            cursor.execute(stmt)
            # self.conn.commit()

    def show_brands(self):
        with self.conn.cursor() as cursor:
            stmt = sql.SQL('SELECT * '
                           'FROM brands;')

            cursor.execute(stmt)
            return self.trans(('id', 'name'), cursor.fetchall())

    def show_stocks(self):
        with self.conn.cursor() as cursor:
            stmt = sql.SQL('SELECT id, name, inn, ogrn, address, date_create, id_storekeeper '
                           'FROM stocks ;')

            cursor.execute(stmt)
            return self.trans(('id', 'name', 'inn', 'ogrn', 'address', 'date create', 'id storekeeper'), cursor.fetchall())

    def show_stock(self):
        with self.conn.cursor() as cursor:
            stmt = sql.SQL('SELECT id, id_component, id_stock, balance '
                           'FROM stock ;')

            cursor.execute(stmt)
            return self.trans(('id', 'id component', 'id stock', 'balance'), cursor.fetchall())

    def show_clients(self):
        with self.conn.cursor() as cursor:
            stmt = sql.SQL('SELECT id, name, phone_number, discount_card, login, password '
                           'FROM clients;')

            cursor.execute(stmt)
            return self.trans(('id', 'name', 'phone number', 'discount card', 'login', 'password'), cursor.fetchall())

    def show_workers(self):
        with self.conn.cursor() as cursor:
            stmt = sql.SQL('SELECT id, name, login, password, address, phone_number, id_position, email, date_employment '
                           'FROM workers ;')

            cursor.execute(stmt)
            return self.trans(('id', 'name', 'login', 'password', 'address', 'phone number', 'id position', 'email', 'date employment'), cursor.fetchall())

    def show_positions(self):
        with self.conn.cursor() as cursor:
            stmt = sql.SQL('SELECT * '
                           'FROM positions;')

            cursor.execute(stmt)
            return self.trans(('id', 'name'), cursor.fetchall())

    def show_orders(self):
        with self.conn.cursor() as cursor:
            stmt = sql.SQL('SELECT id, date_order, id_manager, discount '
                           'FROM orders;')

            cursor.execute(stmt)
            return self.trans(('id', 'date order', 'id manager', 'discount'), cursor.fetchall())

    def show_basket(self):
        with self.conn.cursor() as cursor:
            stmt = sql.SQL('SELECT id, id_component, quantity, id_client, id_order '
                           'FROM basket ;')

            cursor.execute(stmt)
            return self.trans(('id', 'id component', 'quantity', 'id client', 'id order'), cursor.fetchall())

    def enter_brands(self, mass):
        with self.conn.cursor() as cursor:
            args = ['id', 'name']
            if mass[-1] == 'id':
                stmt = sql.SQL('INSERT INTO brands({}) VALUES ({}) ;').format(
                    sql.SQL(',').join(map(sql.Identifier, args)),
                    sql.SQL(',').join(map(sql.Literal, mass[:2])))
            else:
                stmt = self.crt_update(args, mass, 'brands')
            cursor.execute(stmt)
            #self.conn.commit()

    def enter_stock(self, mass):
        with self.conn.cursor() as cursor:
            args = ['id', 'id_component', 'id_stock',
                    'balance']
            if mass[-1] == 'id':
                stmt = sql.SQL('INSERT INTO stock({}) VALUES ({}) ;').format(
                    sql.SQL(',').join(map(sql.Identifier, args)),
                    sql.SQL(',').join(map(sql.Literal, mass[:4])))
            else:
                stmt = self.crt_update(args, mass, 'stock')
            cursor.execute(stmt)
            #self.conn.commit()

    def enter_stocks(self, mass):
        with self.conn.cursor() as cursor:
            args = ['id', 'name', 'inn',
                    'ogrn', 'address', 'date_create', 'id_storekeeper']
            if mass[-1] == 'id':
                stmt = sql.SQL('INSERT INTO stocks({}) VALUES ({}) ;').format(
                    sql.SQL(',').join(map(sql.Identifier, args)),
                    sql.SQL(',').join(map(sql.Literal, mass[:7])))
            else:
                stmt = self.crt_update(args, mass, 'stocks')
            cursor.execute(stmt)
            #self.conn.commit()

    def enter_orders(self, mass):
        with self.conn.cursor() as cursor:
            args = ['id', 'date_order', 'id_manager',
                    'discount']
            if mass[-1] == 'id':
                stmt = sql.SQL('INSERT INTO orders({}) VALUES ({}) ;').format(
                    sql.SQL(',').join(map(sql.Identifier, args)),
                    sql.SQL(',').join(map(sql.Literal, mass[:4])))
            else:
                stmt = self.crt_update(args, mass, 'orders')
            cursor.execute(stmt)
            #self.conn.commit()

    def enter_positions(self, mass):
        with self.conn.cursor() as cursor:
            args = ['id', 'name']
            if mass[-1] == 'id':
                stmt = sql.SQL('INSERT INTO positions({}) VALUES ({}) ;').format(
                    sql.SQL(',').join(map(sql.Identifier, args)),
                    sql.SQL(',').join(map(sql.Literal, mass[:2])))
            else:
                stmt = self.crt_update(args, mass, 'positions')
            cursor.execute(stmt)
            #self.conn.commit()

    def enter_workers(self, mass):
        with self.conn.cursor() as cursor:
            args = ['id', 'name', 'login',
                    'password', 'address', 'phone_number', 'id_position',
                    'email', 'date_employment']
            if mass[-1] == 'id':
                stmt = sql.SQL('INSERT INTO workers({}) VALUES ({}) ;').format(
                    sql.SQL(',').join(map(sql.Identifier, args)),
                    sql.SQL(',').join(map(sql.Literal, mass[:9])))
            else:
                stmt = self.crt_update(args, mass, 'workers')
            cursor.execute(stmt)
            #self.conn.commit()

    def enter_clients(self, mass):
        with self.conn.cursor() as cursor:
            args = ['id', 'name', 'phone_number',
                    'discount_card', 'login', 'password']
            if mass[-1] == 'id':
                stmt = sql.SQL('INSERT INTO clients({}) VALUES ({}) ;').format(
                    sql.SQL(',').join(map(sql.Identifier, args)),
                    sql.SQL(',').join(map(sql.Literal, mass[:6])))
            else:
                stmt = self.crt_update(args, mass, 'clients')
            cursor.execute(stmt)
            #self.conn.commit()

    def enter_basket(self, mass):
        with self.conn.cursor() as cursor:
            args = ['id', 'id_component', 'quantity',
                    'id_client', 'id_order']
            if mass[-1] == 'id':
                stmt = sql.SQL('INSERT INTO basket({}) VALUES ({}) ;').format(
                    sql.SQL(',').join(map(sql.Identifier, args)),
                    sql.SQL(',').join(map(sql.Literal, mass[:5])))
            else:
                stmt = self.crt_update(args, mass, 'basket')
            cursor.execute(stmt)
            #self.conn.commit()

a = DB('a', 'a')
scripts = None
if __name__ == '__main__':
    a = DB('admin', 'admin')
    print(a.show_components())