use BarberShop

select * from OrderInfo

delete from OrderInfo where id_order_info = 9

select os.id_order_info as 'Order Id', si.id_service as 'Id Service', 
	   si.name_service  as 'Name Service', si.value_service  as 'Value Service'
	from ServiceInfo si 
	inner join OrderServices os on si.id_service = os.id_service
where os.id_order_info = 11 group by os.id_order_info

select os.id_order_info as 'Order Id', sum(si.value_service) as 'Total R$' from OrderServices os
	inner join ServiceInfo si on si.id_service = os.id_service
where os.id_order_info = 11
group by os.id_order_info

