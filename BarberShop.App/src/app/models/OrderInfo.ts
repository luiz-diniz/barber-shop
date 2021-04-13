import { Customer } from "./Customer";
import { Employee } from "./Employee";
import { ShopAddress } from "./ShopAddress";

export class OrderInfo{
    id: number;
    customerInfo: Customer;
    employeeInfo: Employee;
    shopAddressInfo: ShopAddress;
    orderDate: Date;
    hide: boolean;
}