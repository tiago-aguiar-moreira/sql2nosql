use sql2nosql
GO

-- Estrutura - UP

create table customer (
    id int,
    full_name varchar(200),
    birth date,
    primary key (id)
)
GO

create table product (
    id int,
    title varchar(200),
    register date,
    value decimal(10,2),
    primary key (id)
)
GO

create table purchase (
    id int PRIMARY key,
    purchase_number varchar(10),
    purchase_date datetime,
    user_id int,
    constraint fk_user foreign key (user_id) REFERENCES customer(id)
)
GO

create table purchase_iten (
    id int identity PRIMARY key,
    id_purchase int,
    id_product int,
    iten_value decimal(10,2),
    constraint fk_purchase foreign key (id_purchase) REFERENCES purchase(id),
    constraint fk_product foreign key (id_product) REFERENCES product(id)
)
GO