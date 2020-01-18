use sql2nosql
GO

-- Customer

insert into customer (id, full_name, birth) values
(1, 'tiago', '1991-08-03'),
(2, 'ana', '1971-11-21'),
(3, 'lola', '2009-05-05')
GO

-- Product

insert into product (id, title, register, value) VALUES
(1, 'Expresso', GETDATE(), 23.99),
(2, 'Expresso Intenso', GETDATE(), 23.99),
(3, 'Expresso Barista', GETDATE(), 22.99),
(4, 'Expresso Ristretto', GETDATE(), 23.99)
GO

-- Purchase

insert into purchase (id, purchase_number, purchase_date, user_id)  values 
-- tiago
(1, '0000000001', '20191122 17:53:56', 1),
(2, '0000000002', '20191210 18:01:59', 1),
(3, '0000000003', '20191122 18:15:23', 1),
-- ana
(4, '0000000004', '20181012 10:30:24', 2),
(5, '0000000005', '20181029 13:46:14', 2),
-- lola
(6, '0000000006', '20191218 15:15:01', 3)
GO

-- Purchase

insert into purchase_iten (id_purchase, id_product, iten_value) values
-- tiago -- purchase 1
(1, 2, 23.99),
(1, 2, 23.99),
(1, 2, 23.99),
(1, 2, 23.99),
(1, 2, 23.99),
-- tiago -- purchase 2
(2, 2, 23.99),
(2, 3, 22.99),
-- tiago -- purchase 3
(3, 2, 23.99),
(3, 3, 22.99),
(3, 2, 23.99),
(3, 3, 22.99),
-- ana -- purchase 4
(4, 3, 22.99),
-- ana -- purchase 5
(5, 1, 23.99),
-- lola -- purchase 6
(6, 3, 22.99),
(6, 3, 22.99)