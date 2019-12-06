CREATE TABLE IF NOT EXISTS brands(
    id SERIAL PRIMARY KEY,
    name VARCHAR (30)
);

CREATE TABLE IF NOT EXISTS components(
    id SERIAL PRIMARY KEY,
    name VARCHAR(30),
    purchase_price INTEGER,
    selling_price INTEGER,
    clock INTEGER,
    cores INTEGER,
    threads INTEGER,
    clock_memory INTEGER,
    bus_width INTEGER,
    memory INTEGER,
    timing INTEGER,
    id_brand INTEGER REFERENCES brands(id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS clients(
    id SERIAL PRIMARY KEY,
    name VARCHAR(30),
    phone_number VARCHAR(11),
    discount_card VARCHAR(9),
    login VARCHAR(32) UNIQUE ,
    password VARCHAR(32)
);

CREATE TABLE IF NOT EXISTS positions(
    id SERIAL PRIMARY KEY,
    name VARCHAR(30)
);

CREATE TABLE IF NOT EXISTS workers(
    id SERIAL PRIMARY KEY,
    login VARCHAR(32) UNIQUE ,
    password VARCHAR(32),
    name VARCHAR(30),
    address VARCHAR(50),
    phone_number VARCHAR(11),
    id_position INTEGER REFERENCES positions(id) ON DELETE CASCADE ON UPDATE CASCADE,
    email VARCHAR(30),
    date_employment DATE
);

CREATE TABLE IF NOT EXISTS stocks(
    id SERIAL PRIMARY KEY,
    name VARCHAR(30),
    inn INTEGER,
    ogrn INTEGER,
    address VARCHAR(50),
    date_create DATE,
    id_storekeeper INTEGER REFERENCES workers(id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS stock(
    id SERIAL PRIMARY KEY,
    id_component INTEGER REFERENCES components(id) ON DELETE CASCADE ON UPDATE CASCADE,
    id_stock INTEGER REFERENCES stocks(id) ON DELETE CASCADE ON UPDATE CASCADE,
    balance INTEGER
);

CREATE TABLE IF NOT EXISTS orders(
    id SERIAL PRIMARY KEY,
    date_order DATE,
    id_manager INTEGER REFERENCES workers(id) ON DELETE CASCADE ON UPDATE CASCADE,
    discount INTEGER
);

CREATE TABLE IF NOT EXISTS basket(
    id SERIAL PRIMARY KEY,
    id_component INTEGER REFERENCES components(id) ON DELETE CASCADE ON UPDATE CASCADE,
    quantity INTEGER,
    id_client INTEGER REFERENCES clients(id) ON DELETE CASCADE ON UPDATE CASCADE,
    id_order INTEGER REFERENCES orders(id) ON DELETE CASCADE ON UPDATE CASCADE
);
