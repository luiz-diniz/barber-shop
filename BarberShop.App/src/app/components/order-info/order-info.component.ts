import { Component, ElementRef, OnInit, QueryList, ViewChildren } from '@angular/core';
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

  @ViewChildren("servicesCheckbox") servicesCheckbox: QueryList<ElementRef>;

  orderInfo: OrderInfo;
  currentCpf: string;

  orders: OrderInfo[];
  address: ShopAddress;
  addresses: ShopAddress[];
  payments: Payment[];
  services: ServiceInfo[];
  servicesSelected: ServiceInfo[];
  addressSelected: ShopAddress;
  employee: Employee;
  test: Map<Payment, number>;

  showForm: boolean = false;
  isEditing: boolean = false;
  total: number;
  orderInfoApi: string = "api/orderInfo/";

  constructor(private service: WebapiService<OrderInfo, any>,
    private format: FormatService) {

      this.orderInfo = new OrderInfo();
      this.orderInfo.customerInfo = new Customer();
      this.orderInfo.shopAddressInfo = new ShopAddress();

      this.employee = {
        id: 1,
        cpf: '11111111111',
        name: 'Raimundo',
        username: 'rdiniz',
        password: 'sF4f8dLoeeRTfQefWxUWnM/QPw9+zqb8N+Jx3vyFIOc='
      }
      
      this.orders = [];
      this.addresses = [];
      this.payments = [];
      this.services = [];
      this.servicesSelected = [];
      
      this.LoadData();
     }
  
  ngOnInit(): void {
  }

  OnSubmit(){
    this.Create();
  }

  Create(){
    const api = `${this.orderInfoApi}CreateOrderInfo`;

    this.orderInfo.servicesInfo = this.servicesSelected;
    this.orderInfo.employeeInfo = this.employee;

    this.service.Create(this.orderInfo, api).subscribe(
      success => {
        console.log("test");
      },
      err => {
        console.log(err);
      }
    );
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

  ShowForm(){
    this.showForm = !this.showForm;

    if(this.showForm){
      this.ResetOrderInfo();
    }
  }

  SumTotal(){
    this.total = 0;

    for (let i = 0; i < this.servicesSelected.length; i++) {
      this.total += this.servicesSelected[i].value;
    }
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

  ResetOrderInfo(){
    this.servicesSelected.forEach((item) =>{
      item.isChecked = false;
    });

    this.servicesCheckbox.forEach((item) => {
      item.nativeElement.checked = false;
    })

    this.servicesSelected = [];

    this.orderInfo = new OrderInfo();
    this.orderInfo.customerInfo = new Customer();

    this.orderInfo.servicesInfo = null;
    this.orderInfo.shopAddressInfo = null;
    this.orderInfo.paymentInfo = null;
    
    this.total = 0;
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
      || this.servicesSelected.length === 0
      || Object.keys(this.orderInfo.shopAddressInfo).length === 0){
      return true;
    }

    return false;
  }
}