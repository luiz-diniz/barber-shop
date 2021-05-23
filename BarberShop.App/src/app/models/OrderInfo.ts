import { Customer } from "./Customer";
import { Employee } from "./Employee";
import { Payment } from "./Payment";
import { ServiceInfo } from "./ServiceInfo";
import { ShopAddress } from "./ShopAddress";

export class OrderInfo{
    id: number;
    customerInfo: Customer;
    employeeInfo: Employee;
    shopAddressInfo: ShopAddress;
    paymentInfo: Payment;
    servicesInfo: ServiceInfo[];
    orderDate: Date;
    hide: boolean;
}