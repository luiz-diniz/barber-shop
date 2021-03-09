import { OrderInfo } from "./OrderInfo";
import { Payment } from "./payment";

export class OrderPayment{
    public Id: number; 
    public Order: OrderInfo
    public PaymentInfo: Payment[];
}