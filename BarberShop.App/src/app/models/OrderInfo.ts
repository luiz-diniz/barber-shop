import { Customer } from "./Customer";
import { Employee } from "./Employee";
import { Payment } from "./Payment";
import { ShopAddress } from "./ShopAddress";

export class OrderInfo{
    id: number;
    customerInfo: Customer;
    employeeInfo: Employee;
    shopAddressInfo: ShopAddress;
    paymentsInfo: Payment[];
    orderDate: Date;
    hide: boolean;
}