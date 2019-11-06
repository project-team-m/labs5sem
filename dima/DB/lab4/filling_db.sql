INSERT INTO brands
VALUES
('ASUS'),
('CORSAIR'),
('GIGABYTE'),
('AMD'),
('intel'),
('Palit');

INSERT INTO clients(name, phone_number, discount_card, login, password)
VALUES
('Petya', '89999999999', '197543854', 'petya', 'pass'),
('Nastya', '88888888888', '564897132', 'nastya', 'pass'),
('Yana', '87777777777', '897157354', 'yana', 'pass'),
('Gosha', '86666666666', '897615449', 'gosha', 'pass');

INSERT INTO components(name, purchase_price, selling_price, clock, cores, threads, clock_memory, bus_width, memory, timing, id_brand)
VALUES
('Radeon RX Vega 56', 24226, 18390, 1297, null, null, 1600, 2048, 8192, null, 1),
('Corsair CMK8GX4M2B3200C16', 5947, 4870, null, null, null, null, null, 8192, 16, 2),
('GeForce GTX 1060', 17170, 14381, 1582, null, null, 8008, 192, 6144, null, 3),
('Ryzen 5 3600X', 14920, 11456, 3800, 6, 12, null, null, null, null, 4),
('Core i9-9900K Coffee Lake', 34500, 27438, 3600, 8, 16, null, null, null, null, 5),
('GeForce RTX 2080 Ti', 77675, 54786, 2130, null, null, 1350, 352, 11264, null, 6),
('GeForce GTX 1070', 25390, 23468, 1582, null, null, 8008, 256, 8192, null, 3),
('Ryzen 5 2600 Pinnacle Ridge', 8080, 7500, 3400, 6, 12, null, null, null, null, 4),
('Corsair CMW16GX4M2C3000C15', 6983, 5947, null, null, null, null, null, 16384, 15, 2),
('GeForce GTX 1050 Ti', 9230, 8900, 1341, null, null, 7008, 192, 4096, null, 1),
('Core i7-6700K Skylake', 18770, 16230, 4000, 4, 8, null, null, null, null, 5),
('GeForce RTX 2080 SUPER', 53935, 49578, 1830, null, null, 15500, 256, 8192, null, 3);

INSERT INTO positions(name)
VALUES
('manager'),
('storekeeper');

INSERT INTO workers(name, address, phone_number, id_position, email, date_employment)
VALUES
('Evgeniya', 'kash 2', '89854785442', 1, 'aaa@aaa.a', '2005-Jan-12'),
('Anatoly', 'hgw 7', '89547831456', 2, 'ccc@ccc.c', '2004-Dec-27'),
('Segrey', 'adrg 56', '89547831868', 2, 'bbb@bbb.b', '2004-Dec-26');

INSERT INTO stocks(name, inn, ogrn, address, date_create, id_storekeeper)
VALUES
('first stock', 123, 456, 'gtr 6', '2005/12/1', 1),
('second stock', 214, 852, 'gtr 5', '2005/12/3', 2);

INSERT INTO stock(id_component, id_stock, balance)
VALUES
(1, 1, 12),
(2, 1, 6),
(5, 1, 2),
(1, 2, 8),
(3, 1, 15),
(7, 1, 5),
(9, 1, 23),
(6, 1, 56),
(3, 2, 1),
(6, 2, 2),
(12, 1, 8),
(11, 1, 7),
(9, 2, 1),
(5, 2, 9),
(7, 2, 123),
(10, 1, 65),
(12, 2, 85),
(4, 2, 3);

INSERT INTO orders(date_order, id_manager, discount)
VALUES
('2006/5/14', 1, 5),
('2007/2/1', 1, 15),
('2005/6/8', 1, 0);

INSERT INTO basket(id_component, quantity, id_client, id_order)
VALUES
(1, 3, 1, 1),
(12, 1, 4, 2),
(9, 2, 3, 3),
(6, 6, 1, 1),
(5, 1, 3, 2),
(4, 2, 3, 1),
(11, 1, 3, 3),
(5, 4, 4, 3),
(1, 6, 3, 3);
