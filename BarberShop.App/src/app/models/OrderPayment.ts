import { OrderInfo } from "./OrderInfo";
import { Payment } from "./Payment";

export class OrderPayment{
    public Id: number; 
    public Order: OrderInfo
    public PaymentInfo: Payment[];
}