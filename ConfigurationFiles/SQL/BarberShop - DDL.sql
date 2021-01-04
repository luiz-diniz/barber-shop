drop database BarberShop
create database BarberShop
use BarberShop

create table Customer(
	id_customer int identity(1,1) primary key,
	cpf_customer char(11) not null unique,
	name_customer varchar(50) not null,
	birth_customer date not null
)

create table CustomerPhone(
	id_customer_phone int identity(1,1) primary key,
	id_customer int,
	phone_customer varchar(20),

	foreign key(id_customer) references Customer(id_customer)
)

create table Employee(
	id_employee int identity(1,1) primary key,
	cpf_employee char(11) not null unique,
	name_employee varchar(50) not null,
	username_employee varchar(50) not null,
	password_employee varchar(50) not null,
	salt_hash_password_employee varchar(50) not null,
)

create table Payment(
	id_payment int identity(1,1) primary key,
	name_payment varchar(50) not null
)

create table ShopAddress(
	id_shop int identity(1,1) primary key,
	name_shop varchar(20) not null unique,
	street_shop varchar(50) not null,
	number_shop int not null,
	city_shop varchar(50) not null,
	state_shop varchar(50) not null
)

create table ServiceInfo(
	id_service int identity(1,1) primary key,
	name_service varchar(50) not null,
	description_service varchar(100) not null,
	value_service decimal(5,2) not null
)

create table OrderInfo(
	id_order_info int identity(1,1) primary key,
	id_customer int,
	id_employee int,
	id_shop int,
	order_date datetime not null,

	foreign key (id_customer) references Customer(id_customer),
	foreign key (id_employee) references Employee(id_employee),
	foreign key (id_shop) references ShopAddress(id_shop)
)

create table OrderServices(
	id_order_services int identity(1,1) primary key,
	id_order_info int,
	id_service_shop int,

	foreign key(id_order_info) references OrderInfo(id_order_info),
	foreign key(id_service_shop) references ServiceInfo(id_service)
)

create table OrderPayment(
	id_order_payment int identity(1,1) primary key,
	id_payment int,
	id_order_info int,

	foreign key (id_payment) references Payment(id_payment),
	foreign key (id_order_info) references OrderInfo(id_order_info)
)