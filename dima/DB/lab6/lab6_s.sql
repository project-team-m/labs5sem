

-- практика

DROP function if EXISTS find_1  CASCADE;
DROP TRIGGER if EXISTS find_1 ON obj_1 cascade  ;
DROP function if EXISTS sam2  CASCADE;
DROP AGGREGATE if EXISTS print (varchar , varchar);
DROP INDEX if EXISTS HELPER ;
drop table if exists my_object CASCADE;
drop table if exists obj_1 CASCADE;

CREATE TABLE if not exists my_object (
    id  integer  NOT NULL ,
    time_create timestamp  NOT NULL,
    time_dead timestamp ,
    PRIMARY KEY (id , time_create )
);

CREATE TABLE if not exists obj_1
(
    names varchar (10) NOT NULL
)
INHERITS(my_object);

CREATE OR REPLACE FUNCTION find_1()
        RETURNS TRIGGER AS $find_1$
BEGIN
    IF (NEW.id IN (SELECT id FROM obj_1))
        THEN NEW.time_create := current_timestamp (0);
            UPDATE obj_1 SET time_dead = NEW.time_create
            WHERE  id = NEW.id AND time_dead IS NULL ;
            RETURN NEW;
    ELSE
        NEW.time_create := current_timestamp (0);
        RETURN  NEW;
    END IF ;
END;
$find_1$  LANGUAGE plpgsql;

CREATE TRIGGER find_1
BEFORE INSERT ON obj_1
FOR EACH ROW
EXECUTE PROCEDURE find_1 ();

create or replace FUNCTION sam2 ( firsts varchar , second varchar , separator varchar  )
     RETURNS varchar as $f$
  DECLARE
    new_str varchar ;
 begin
    new_str:= firsts ||  separator || second;

    --RETURN substring( new_str from 2 for length(new_str) );
    RETURN new_str ;
 end;
$f$   LANGUAGE 'plpgsql';


CREATE AGGREGATE print (  varchar , varchar  )
(
    sfunc = sam2 ,
    stype = varchar,
    initcond = ' '
);


CREATE IF NOT EXISTS INDEX HELPER ON obj_1 (id , time_create);

--теория
--С помощью конструкции CONSTRAINT можно задать первичный ключ таблицы.
-- Пример 3.3:
-- Создание таблицы TABL1:
-- CREATE TABLE TABL1
-- (
--[FIL1] COUNTER,
--[FIL2] TEXT (10),
--[FIL3] CURRENCY,
-- CONSTRAINT PrimaryKey PRIMARY KEY ([FIL1])
--);
-- В примере 3.3 поле FIL1 объявлено ключевым, для данного поля создан
-- индекс с именем PrimaryKey.

-- Создание наследования для таблицы B от таблицы A:
-- CREATE TABLE b (b_text text) INHERITS (a);
-- Связь общих полей базовой и производной таблиц не ограничивается
-- чисто косметическими удобствами. Данные, занесенные в производную таблицу, присутствуют
-- и в родительской таблице.
-- Впрочем, в родительской таблице видны только три унаследованных поля. В запрос к базовой таблице
-- можно включить ключевое слово ONLY, которое указывает, что данные производных таблиц исключаются из
-- результатов запроса.

-- Следует хорошо понимать, что данные в действительности не заносятся в базовую таблицу,
-- а лишь становятся видимыми в ней благодаря отношению наследования.

-- Пример 6.9:
-- Создание триггера. Срабатывает при попытке вставить или обновить данные в таблицу
-- shipments и приводит к выполнению функции check_shipment_addition():
-- CREATE TRIGGER checkshipment BEFORE INSERT OR UPDATE
-- ON shipments FOR EACH ROW
-- EXECUTE PROCEDURE check_shipment_addition();

-- Удаление триггера происходит с помощью команды Drop Trigger:
-- DROP TRIGGER имя ON таблица

-- Пример 7.1:
-- Создание функции на языке PL/pgSQL:
-- CREATE OR REPLACE FUNCTION sam (i int4) RETURNS
-- int4 AS
-- $BODY$ DECLARE
-- answer int4;
-- -- Объявление целочисленной константы.
-- -- инициализированной значением 5. five CONSTANT integer := 5;
-- -- Объявление целочисленной переменной.
-- -- инициализированной значением 10.
-- -- Переменной не может присваиваться NULL, ten integer NOT NULL := 10;
-- BEGIN
-- answer := five * ten * i;
--return answer;
-- END;
-- $BODY$
-- LANGUAGE 'plpgsql';

-- Пример 7.2:
-- Вызов функции PL/pgSQL:
-- SELECT * FROM sam (4);

-- DROP FUNCTION [ IF EXISTS ] имя
-- ( [ [ режим_аргумента ] [ имя_аргумента ] тип_аргумента [, ...] ] )
--     [ CASCADE | RESTRICT ]

-- Пример 7.3:
-- Использование %ROWTYPE PL/pgSQL:
-- CREATE FUNCTION get_author (integer) RETURNS text AS ' DECLARE
-- -- Объявление псевдонима для аргумента функции.
-- -- в котором должен передаваться код автора. author_id ALIAS FOR $1;
-- -- Объявление переменной, структура которой
-- -- совпадает со структурой таблицы authors. found_author authors%ROWTYPE;
-- BEGIN
-- -- Найти в таблице authors фамилию автора.
-- -- код которого совпадает с переданным аргументом.
-- SELECT	INTO	found_author	*	FROM	authors	WHERE	id	= author_id;
-- -- Вернуть имя и фамилию, разделенные пробелом.
-- RETURN found_author.first_name || " " || found_author.last_name: END:
-- ' LANGUAGE 'plpgsql';


--current_timestamp (точность ) возврщает текущее время и дату


-- шаблон

CREATE OR REPLACE FUNCTION FIND ()
    RETURN text AS $BODY$
DECLARE
    ....--ОПИСАНИЕ ПЕРЕМЕННЫХ
BEGIN
    ...--КОД ПРОГРАММЫ
END;
$BODY$
LANGUAGE plpgsql;

CREATE TRIGGER [NAME]
[BEFORE| AFTER] [СОБЫТИЕ [ OR СОБЫТИЕ ]] ON name_table
FOR EACH [ROW | STATEMENT]
EXECUTE PROCEDURE name_function (аргументы)

CREATE TRIGGER update_users	    -- имя триггера
  AFTER INSERT OR UPDATE OR DELETE    ON student			    -- таблица БД
  FOR EACH ROW			    -- метод обработки записей
  EXECUTE PROCEDURE user_change();

CREATE AGGREGATE ИМЯ
(
    BASETYPE = входной_тип ,
    SFUNC-функциЯ ,
    STYPE = переходный_тип ,
    FINALFUNC - заверщаюшая_функция ,
    INITCOND - начальное_состояния
);

 Создаем агрегатную функцию
CREATE AGGREGATE sum(complex)
(
    sfunc = complex_add,	-- имя вызываемой хранимой процедуры
    stype = complex,	-- тип значения
    initcond = '(0,0)'		-- начальное значение
);

CREATE AGGREGATE avg (float8)
(
    sfunc = float8_accum,
    stype = float8[],
    finalfunc = float8_avg,
    initcond = '{0,0,0}'
);

 SELECT print ('param1;param2', ';');

CREATE OR REPLACE FUNCTION print1 (str varchar, separator char) RETURNS varchar [] AS
 $body$
 DECLARE
   ret varchar[] := '{}';
   i int2 := 0;
   c int2 := 1;
   tmp_val varchar(255) := '';
   tmp_char char := '';
   len int2 := 0;
 BEGIN
   len = length(str) + 1;
   WHILE i <= len LOOP
     tmp_char := substr(str, i, 1);
       IF tmp_char = separator OR i = len THEN
         ret[c] := tmp_val;
         tmp_val := '';
         c := c + 1;
       ELSE
         tmp_val := tmp_val || tmp_char;
       END IF;
     i := i + 1;
   END LOOP;
   RETURN ret;
 END;
 $body$
 LANGUAGE 'plpgsql' VOLATILE CALLED ON NULL INPUT SECURITY INVOKER;


select sam('{sam , cook }' , '_');

 create or replace FUNCTION sam (s varchar  , sep varchar )
     RETURNS varchar as $f$
  DECLARE
    len integer := 0;
    i integer := 1;
    j integer := 1;
    str varchar := ' ';
 begin
    len := cardinality(s);
    WHILE i <= len LOOP
        str:= CONCAT( str , CONCAT(s[j], sep) ) ;
        i := i + 1;
        j := j + 1;
    END LOOP;
    RETURN str;
 end;
$f$   LANGUAGE 'plpgsql';


CREATE INDEX имя_индекса ON имя_таблицы (имя столбца);