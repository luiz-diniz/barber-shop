drop database BarberShop
create database BarberShop
use BarberShop

create table Customer(
	cpf_customer char(11) primary key,
	name_customer varchar(50) not null,
	birth_customer date,
	phone_customer varchar(20)
)

create table CustomerPhone(
	id_customer_phone int identity(1,1) primary key,
	cpf_customer char(11),
	phone_customer varchar(20),

	foreign key(cpf_customer) references Customer(cpf_customer)
)

create table Employee(
	cpf_employee char(11) primary key,
	name_employee varchar(50) not null,
	username_employee varchar(50) not null,
	password_employee varchar(50) not null,
	hash_password_employee varchar(50) not null,
)

create table Payment(
	id_payment int identity(1,1) primary key,
	name_payment varchar(50)
)

create table ServiceInfo(
	id_service int identity(1,1) primary key,
	name_service varchar(50) not null,
	description_service varchar(100) not null,
	value_service decimal(5,2) not null
)

create table OrderInfo(
	id_order_info int identity(1,1) primary key,
	cpf_customer char(11),
	cpf_employee char(11),
	order_date datetime,

	foreign key (cpf_customer) references Customer(cpf_customer),
	foreign key (cpf_employee) references Employee(cpf_employee)
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

	foreign key (id_payment) references payment(id_payment),
	foreign key (id_order_info) references OrderInfo(id_order_info)
)