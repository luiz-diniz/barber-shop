import { Customer } from "./customer";
import { Employee } from "./employee";
import { ShopAddress } from "./ShopAddress";


export class OrderInfo{
    public Id: number;
    public CustomerInfo: Customer;
    public EmployeeInfo: Employee;
    public ShopAddressInfo: ShopAddress;
    public OrderDate: Date;
}