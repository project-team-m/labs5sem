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

    def rollback(self):
        with self.conn.cursor() as cursor:
            cursor.execute('rollback;')

    def beautiful_change(self, mass):
        new_mass = []
        for i in mass:
            new_mass.append(i[0])
        return new_mass

    def con(self, new_mass, mass_table):
        beautiful_mass = []
        for i in range(mass_table.__len__()):
            beautiful_mass.append([])
            for j in range(len(mass_table[i])):
                beautiful_mass[i].append([new_mass[j], mass_table[i][j]])
        return beautiful_mass

    def create_nice_search(self, titles, args):
        string = "cast({} AS VARCHAR) LIKE '%{}%'".format(titles[0], args[0])
        for i in range(1, len(titles)):
            if args[i]:
                string = "{} AND  cast({} AS VARCHAR) LIKE '%{}%'".format(string, titles[i], args[i])

        return string

    def get_tables(self):
        with self.conn.cursor() as cursor:
            stmt = sql.SQL("SELECT table_name FROM information_schema.tables"
                           " WHERE table_schema NOT IN ('information_schema','pg_catalog') AND "
                           "table_name NOT LIKE '%_old';")

            cursor.execute(stmt)
            return self.beautiful_change(cursor.fetchall())

    def output_titles(self, table):
        with self.conn.cursor() as cursor:
            stmt = sql.SQL("SELECT column_name FROM information_schema.columns WHERE table_name = '{}';".format(table))
            cursor.execute(stmt)

            return self.beautiful_change(cursor.fetchall())

    def output_tables(self, table):
        with self.conn.cursor() as cursor:
            stmt = sql.SQL('SELECT * FROM {};'.format(table))
            cursor.execute(stmt)

            return self.con(self.output_titles(table), cursor.fetchall())


    def update(self, mass, table):
        with self.conn.cursor() as cursor:
            stmt = self.crt_update(mass, table)

            cursor.execute(stmt)

    def del_string(self, old, table):
        with self.conn.cursor() as cursor:
            stmt = "DELETE FROM {} WHERE id = {} ;".format(table, old)

            cursor.execute(stmt)

    def insert(self, mass, table):
        with self.conn.cursor() as cursor:
            stmt = sql.SQL('INSERT INTO {} VALUES ({}) ;').format(
                sql.Identifier(table),
                sql.SQL(',').join(map(sql.Literal, mass)))

            cursor.execute(stmt)

    def search_component(self, table, args):
        prov = False
        for i in args:
            if a != '':
                prov = True

        with self.conn.cursor() as cursor:
            stmt = sql.SQL('SELECT * FROM {} WHERE {};'.format(table,
                                                               self.create_nice_search(args=args,
                                                                                       titles=self.output_titles(table)
                                                                                       )
                                                               ))
            if prov:
                cursor.execute(stmt)
                return self.con(self.output_titles(table), cursor.fetchall())
            else:
                return self.output_tables(table)

    def change_to_norm_none(self, arg):
        if arg.lower() == 'none' or arg.lower() == 'null' or arg == '':
            return 'null'
        else:
            try:
                return int(arg)
            except:
                return "'{}'".format(arg)

    def crt_update(self, mass, table):
        args = self.output_titles(table)
        string = 'UPDATE {} SET {} = {}'.format(table, args[0], mass[0])
        for i in range(1, len(args)):
            string += ', {} = {}'.format(args[i], self.change_to_norm_none(mass[i]))
        string += ' WHERE id={};'.format(mass[-1])

        print(string)

        return string


a = DB('a', 'a')
scripts = None
link = None
if __name__ == '__main__':
    a = DB('admin', 'admin')
    print(a.output_titles('brands'))