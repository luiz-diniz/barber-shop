import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/models/Customer';
import { Employee } from 'src/app/models/Employee';
import { OrderInfo } from 'src/app/models/OrderInfo';
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

      this.GetAllAddresses();
     }
  
  ngOnInit(): void {
  }

  OnSubmit(){
    console.log(0);
  }

  GetAllAddresses(){
    const api = "api/shopAddress/GetAllShopAddresses";
    this.service.GetAll(api).subscribe(
      shops => {
        this.addresses = shops;
        console.log(this.addresses);
      }, 
      err =>{
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    )
  }
}