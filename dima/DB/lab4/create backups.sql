CREATE TABLE IF NOT EXISTS brands_old(
    id INTEGER,
    name VARCHAR (30),
    operation VARCHAR,
    date_operation timestamp DEFAULT now()
);

CREATE TABLE IF NOT EXISTS components_old(
    id INTEGER,
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
    id_brand INTEGER,
    operation VARCHAR,
    date_operation timestamp DEFAULT now()
);

CREATE TABLE IF NOT EXISTS clients_old(
    id INTEGER,
    name VARCHAR(30),
    phone_number VARCHAR(11),
    discount_card VARCHAR(9),
    login VARCHAR(32),
    password VARCHAR(32),
    operation VARCHAR,
    date_operation timestamp DEFAULT now()
);

CREATE TABLE IF NOT EXISTS positions_old(
    id INTEGER,
    name VARCHAR(30),
    operation VARCHAR,
    date_operation timestamp DEFAULT now()
);

CREATE TABLE IF NOT EXISTS workers_old(
    id INTEGER,
    login VARCHAR(32) UNIQUE ,
    password VARCHAR(32),
    name VARCHAR(30),
    address VARCHAR(50),
    phone_number VARCHAR(11),
    id_position INTEGER,
    email VARCHAR(30),
    date_employment DATE,
    operation VARCHAR,
    date_operation timestamp DEFAULT now()
);

CREATE TABLE IF NOT EXISTS stocks_old(
    id INTEGER,
    name VARCHAR(30),
    inn INTEGER,
    ogrn INTEGER,
    address VARCHAR(50),
    date_create DATE,
    id_storekeeper INTEGER,
    operation VARCHAR,
    date_operation timestamp DEFAULT now()
);

CREATE TABLE IF NOT EXISTS stock_old(
    id INTEGER,
    id_component INTEGER,
    id_stock INTEGER,
    balance INTEGER,
    operation VARCHAR,
    date_operation timestamp DEFAULT now()
);

CREATE TABLE IF NOT EXISTS orders_old(
    id INTEGER,
    date_order DATE,
    id_manager INTEGER,
    discount INTEGER,
    operation VARCHAR,
    date_operation timestamp DEFAULT now()
);

CREATE TABLE IF NOT EXISTS basket_old(
    id INTEGER,
    id_component INTEGER,
    quantity INTEGER,
    id_client INTEGER,
    id_order INTEGER,
    operation VARCHAR,
    date_operation timestamp DEFAULT now()
);

CREATE OR REPLACE FUNCTION basket_backup() RETURNS TRIGGER AS
$Basket$
BEGIN
    IF (TG_OP = 'DELETE') THEN
        INSERT INTO basket_old SELECT OLD.*, TG_OP, now();
        RETURN OLD;
    ELSIF (TG_OP = 'UPDATE') THEN
        IF (OLD != NEW) THEN
            INSERT INTO basket_old SELECT OLD.*, TG_OP, now();
            RETURN NEW;
        END IF;
    ELSIF (TG_OP = 'INSERT') THEN
        INSERT INTO basket_old SELECT NEW.*, TG_OP, now();
        RETURN NEW;
    END IF;
    RETURN NULL;
END ;
$Basket$ LANGUAGE plpgsql;

CREATE TRIGGER basket
    AFTER INSERT OR UPDATE OR DELETE
    ON basket
    FOR EACH ROW
EXECUTE PROCEDURE basket_backup();

CREATE OR REPLACE FUNCTION brands_backup() RETURNS TRIGGER AS
$brands$
BEGIN
    IF (TG_OP = 'DELETE') THEN
        INSERT INTO brands_old SELECT OLD.*, TG_OP, now();
        RETURN OLD;
    ELSIF (TG_OP = 'UPDATE') THEN
        IF (OLD != NEW) THEN
            INSERT INTO brands_old SELECT OLD.*, TG_OP, now();
            RETURN NEW;
        END IF;
    ELSIF (TG_OP = 'INSERT') THEN
        INSERT INTO brands_old SELECT NEW.*, TG_OP, now();
        RETURN NEW;
    END IF;
    RETURN NULL;
END ;
$brands$ LANGUAGE plpgsql;

CREATE TRIGGER brands
    AFTER INSERT OR UPDATE OR DELETE
    ON brands
    FOR EACH ROW
EXECUTE PROCEDURE brands_backup();

CREATE OR REPLACE FUNCTION clients_backup() RETURNS TRIGGER AS
$clients$
BEGIN
    IF (TG_OP = 'DELETE') THEN
        INSERT INTO clients_old SELECT OLD.*, TG_OP, now();
        RETURN OLD;
    ELSIF (TG_OP = 'UPDATE') THEN
        IF (OLD != NEW) THEN
            INSERT INTO clients_old SELECT OLD.*, TG_OP, now();
            RETURN NEW;
        END IF;
    ELSIF (TG_OP = 'INSERT') THEN
        INSERT INTO clients_old SELECT NEW.*, TG_OP, now();
        RETURN NEW;
    END IF;
    RETURN NULL;
END ;
$clients$ LANGUAGE plpgsql;

CREATE TRIGGER clients
    AFTER INSERT OR UPDATE OR DELETE
    ON clients
    FOR EACH ROW
EXECUTE PROCEDURE clients_backup();

CREATE OR REPLACE FUNCTION components_backup() RETURNS TRIGGER AS
$components$
BEGIN
    IF (TG_OP = 'DELETE') THEN
        INSERT INTO components_old SELECT OLD.*, TG_OP, now();
        RETURN OLD;
    ELSIF (TG_OP = 'UPDATE') THEN
        IF (OLD != NEW) THEN
            INSERT INTO components_old SELECT OLD.*, TG_OP, now();
            RETURN NEW;
        END IF;
    ELSIF (TG_OP = 'INSERT') THEN
        INSERT INTO components_old SELECT NEW.*, TG_OP, now();
        RETURN NEW;
    END IF;
    RETURN NULL;
END ;
$components$ LANGUAGE plpgsql;

CREATE TRIGGER components
    AFTER INSERT OR UPDATE OR DELETE
    ON components
    FOR EACH ROW
EXECUTE PROCEDURE components_backup();

CREATE OR REPLACE FUNCTION orders_backup() RETURNS TRIGGER AS
$orders$
BEGIN
    IF (TG_OP = 'DELETE') THEN
        INSERT INTO orders_old SELECT OLD.*, TG_OP, now();
        RETURN OLD;
    ELSIF (TG_OP = 'UPDATE') THEN
        IF (OLD != NEW) THEN
            INSERT INTO orders_old SELECT OLD.*, TG_OP, now();
            RETURN NEW;
        END IF;
    ELSIF (TG_OP = 'INSERT') THEN
        INSERT INTO orders_old SELECT NEW.*, TG_OP, now();
        RETURN NEW;
    END IF;
    RETURN NULL;
END ;
$orders$ LANGUAGE plpgsql;

CREATE TRIGGER orders
    AFTER INSERT OR UPDATE OR DELETE
    ON orders
    FOR EACH ROW
EXECUTE PROCEDURE orders_backup();

CREATE OR REPLACE FUNCTION positions_backup() RETURNS TRIGGER AS
$positions$
BEGIN
    IF (TG_OP = 'DELETE') THEN
        INSERT INTO positions_old SELECT OLD.*, TG_OP, now();
        RETURN OLD;
    ELSIF (TG_OP = 'UPDATE') THEN
        IF (OLD != NEW) THEN
            INSERT INTO positions_old SELECT OLD.*, TG_OP, now();
            RETURN NEW;
        END IF;
    ELSIF (TG_OP = 'INSERT') THEN
        INSERT INTO positions_old SELECT NEW.*, TG_OP, now();
        RETURN NEW;
    END IF;
    RETURN NULL;
END ;
$positions$ LANGUAGE plpgsql;

CREATE TRIGGER positions
    AFTER INSERT OR UPDATE OR DELETE
    ON positions
    FOR EACH ROW
EXECUTE PROCEDURE positions_backup();

CREATE OR REPLACE FUNCTION stock_backup() RETURNS TRIGGER AS
$stock$
BEGIN
    IF (TG_OP = 'DELETE') THEN
        INSERT INTO stock_old SELECT OLD.*, TG_OP, now();
        RETURN OLD;
    ELSIF (TG_OP = 'UPDATE') THEN
        IF (OLD != NEW) THEN
            INSERT INTO stock_old SELECT OLD.*, TG_OP, now();
            RETURN NEW;
        END IF;
    ELSIF (TG_OP = 'INSERT') THEN
        INSERT INTO stock_old SELECT NEW.*, TG_OP, now();
        RETURN NEW;
    END IF;
    RETURN NULL;
END ;
$stock$ LANGUAGE plpgsql;

CREATE TRIGGER stock
    AFTER INSERT OR UPDATE OR DELETE
    ON stock
    FOR EACH ROW
EXECUTE PROCEDURE stock_backup();

CREATE OR REPLACE FUNCTION stocks_backup() RETURNS TRIGGER AS
$stocks$
BEGIN
    IF (TG_OP = 'DELETE') THEN
        INSERT INTO stocks_old SELECT OLD.*, TG_OP, now();
        RETURN OLD;
    ELSIF (TG_OP = 'UPDATE') THEN
        IF (OLD != NEW) THEN
            INSERT INTO stocks_old SELECT OLD.*, TG_OP, now();
            RETURN NEW;
        END IF;
    ELSIF (TG_OP = 'INSERT') THEN
        INSERT INTO stocks_old SELECT NEW.*, TG_OP, now();
        RETURN NEW;
    END IF;
    RETURN NULL;
END ;
$stocks$ LANGUAGE plpgsql;

CREATE TRIGGER stocks
    AFTER INSERT OR UPDATE OR DELETE
    ON stocks
    FOR EACH ROW
EXECUTE PROCEDURE stocks_backup();

CREATE OR REPLACE FUNCTION workers_backup() RETURNS TRIGGER AS
$workers$
BEGIN
    IF (TG_OP = 'DELETE') THEN
        INSERT INTO workers_old SELECT OLD.*, TG_OP, now();
        RETURN OLD;
    ELSIF (TG_OP = 'UPDATE') THEN
        IF (OLD != NEW) THEN
            INSERT INTO workers_old SELECT OLD.*, TG_OP, now();
            RETURN NEW;
        END IF;
    ELSIF (TG_OP = 'INSERT') THEN
        INSERT INTO workers_old SELECT NEW.*, TG_OP, now();
        RETURN NEW;
    END IF;
    RETURN NULL;
END ;
$workers$ LANGUAGE plpgsql;

CREATE TRIGGER workers
    AFTER INSERT OR UPDATE OR DELETE
    ON workers
    FOR EACH ROW
EXECUTE PROCEDURE workers_backup();
