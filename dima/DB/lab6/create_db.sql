CREATE TABLE IF NOT EXISTS my_object
(
    id          integer   NOT NULL,
    time_create timestamp NOT NULL,
    time_dead   timestamp,
    PRIMARY KEY (id, time_create)
);

CREATE TABLE IF NOT EXISTS heir_1
(
    text varchar(10) NOT NULL
) INHERITS (my_object);

CREATE TABLE IF NOT EXISTS heir_2
(
    text varchar(10) NOT NULL
) INHERITS (my_object);

CREATE TABLE IF NOT EXISTS heir_3
(
    text varchar(10) NOT NULL
) INHERITS (my_object);

CREATE TABLE IF NOT EXISTS heir_4
(
    text varchar(10) NOT NULL
) INHERITS (my_object);

CREATE TABLE IF NOT EXISTS heir_5
(
    names varchar(10) NOT NULL
) INHERITS (my_object);

CREATE OR REPLACE FUNCTION add_obj() RETURNS TRIGGER AS
$add_obj$
BEGIN
    IF (NEW.id IN (SELECT id FROM heir_1))
    THEN
        NEW.time_create := current_timestamp(0);
        UPDATE heir_1
        SET time_dead = NEW.time_create
        WHERE id = NEW.id
          AND time_dead IS NULL;
        RETURN NEW;
    ELSE
        NEW.time_create := current_timestamp(0);
        RETURN NEW;
    END IF;
END;
$add_obj$ LANGUAGE plpgsql;

CREATE TRIGGER handler_live
    BEFORE INSERT
    ON heir_1
    FOR EACH ROW
EXECUTE PROCEDURE add_obj();

INSERT INTO heir_1(id, text)
VALUES
(1, 'a');
INSERT INTO heir_1(id, text)
VALUES
(2, 'b');
INSERT INTO heir_1(id, text)
VALUES
(3, 'c');
INSERT INTO heir_1(id, text)
VALUES
(2, 'd');
INSERT INTO heir_1(id, text)
VALUES
(4, 'e');
INSERT INTO heir_1(id, text)
VALUES
(3, 'f');

create or replace FUNCTION solid_heir_2 (old varchar , new varchar)
     RETURNS varchar as $$
 begin
    IF OLD = ' ' THEN
        RETURN new;
    ELSE
        RETURN old || '|' || new;
    end if;
 end;
$$   LANGUAGE 'plpgsql';


CREATE AGGREGATE print (varchar)
(
    sfunc = solid_heir_2,
    stype = varchar,
    initcond = ' '
);

CREATE INDEX ind ON heir_2 (id , time_create);