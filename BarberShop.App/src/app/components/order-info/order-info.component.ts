import { i18nMetaToJSDoc } from '@angular/compiler/src/render3/view/i18n/meta';
import { Component, OnInit } from '@angular/core';
import { forkJoin } from 'rxjs';
import { Customer } from 'src/app/models/Customer';
import { Employee } from 'src/app/models/Employee';
import { OrderInfo } from 'src/app/models/OrderInfo';
import { Payment } from 'src/app/models/Payment';
import { ServiceInfo } from 'src/app/models/ServiceInfo';
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
  currentCpf: string;

  orders: OrderInfo[];
  addresses: ShopAddress[];
  payments: Payment[];
  services: ServiceInfo[];
  paymentsSelected: Payment[];
  servicesSelected: ServiceInfo[];

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
      this.services = [];
      this.paymentsSelected = [];
      this.servicesSelected = [];

      this.LoadData();
     }
  
  ngOnInit(): void {
  }

  OnSubmit(){
    console.log(0);
  }

  GetCustomer(){
    this.currentCpf = this.orderInfo.customerInfo.cpf;
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

  SumTotal(){
    let total = 0;

    for (let i = 0; i < this.servicesSelected.length; i++) {
      total += this.servicesSelected[i].value;
    }

    return total;
  }

  EditServiceList(service: ServiceInfo){
    service.isChecked = !service.isChecked;

    if(service.isChecked === true){
      this.servicesSelected.push(service);
    }else{
      const index = this.servicesSelected.indexOf(service);
      this.servicesSelected.splice(index, 1);
    }

    this.SumTotal();
  }


  EditPaymentList(payment: Payment){
    payment.isChecked = !payment.isChecked;

    if(payment.isChecked === true){
      this.paymentsSelected.push(payment);
    }else{
      const index = this.paymentsSelected.indexOf(payment);
      this.paymentsSelected.splice(index, 1);
    }
  }

  LoadData(){
    const paymentsApi = this.service.GetAll("api/payment/GetAllPayments");
    const addressesApi = this.service.GetAll("api/shopAddress/GetAllShopAddresses");
    const servicesApi = this.service.GetAll("api/serviceInfo/GetAllServices");

    const observales = [paymentsApi, addressesApi, servicesApi];

    forkJoin(observales).subscribe(
      result => {
        this.payments = result[0],
        this.addresses = result[1],
        this.services = result[2]
      }, 
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    )
  }

  ValidateForm(){
    if(
      this.currentCpf != this.orderInfo.customerInfo.cpf 
      || this.paymentsSelected.length === 0
      || this.servicesSelected.length === 0){
      return true;
    }

    return false;
  }
}