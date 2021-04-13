import { Customer } from "./customer";
import { Employee } from "./employee";
import { ShopAddress } from "./ShopAddress";

export class OrderInfo{
    id: number;
    customerInfo: Customer;
    employeeInfo: Employee;
    shopAddressInfo: ShopAddress;
    orderDate: Date;
    hide: boolean;
}