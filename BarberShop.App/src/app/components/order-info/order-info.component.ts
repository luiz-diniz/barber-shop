import { Component, OnInit } from '@angular/core';
import { forkJoin } from 'rxjs';
import { Customer } from 'src/app/models/Customer';
import { Employee } from 'src/app/models/Employee';
import { OrderInfo } from 'src/app/models/OrderInfo';
import { Payment } from 'src/app/models/Payment';
import { ShopAddress } from 'src/app/models/ShopAddress';
import { FormatService } from 'src/app/services/format.service';
import { WebapiService } from 'src/app/services/webapi.service';

@Component({
  selector: 'app-order-info',
  templateUrl: './order-info.component.html',
  styleUrls: ['./order-info.component.scss']
})
export class OrderInfoComponent implements OnInit {

  orderInfo: OrderInfo;
  orders: OrderInfo[];
  addresses: ShopAddress[];
  payments: Payment[];

  showForm: boolean = false;
  isEditing: boolean = false;

  constructor(private service: WebapiService<OrderInfo, any>,
    private format: FormatService) {

      this.orderInfo = new OrderInfo();
      this.orderInfo.customerInfo = new Customer();
      this.orderInfo.employeeInfo = new Employee();
      this.orderInfo.shopAddressInfo = new ShopAddress();

      this.orders = [];
      this.addresses = [];
      this.payments = [];

      this.LoadData();
     }
  
  ngOnInit(): void {
  }

  OnSubmit(){
    console.log(0);
  }

  GetCustomer(){
    const api = `api/customer/ReadCustomer/${this.orderInfo.customerInfo.cpf}`;
    this.service.Get(api).subscribe(
      customer => {
        this.orderInfo.customerInfo = customer;
      },
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    )
  }

  LoadData(){
    const paymentsApi = this.service.GetAll("api/payment/GetAllPayments");
    const addressesApi = this.service.GetAll("api/shopAddress/GetAllShopAddresses");

    const observales = [paymentsApi, addressesApi];

    forkJoin(observales).subscribe(
      result => {
        this.payments = result[0],
        this.addresses = result[1]
      }
    )
  }
}