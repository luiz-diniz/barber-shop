import { Component, OnInit } from '@angular/core';
import { OrderInfo } from 'src/app/models/OrderInfo';
import { WebapiService } from 'src/app/services/webapi.service';

@Component({
  selector: 'app-order-info',
  templateUrl: './order-info.component.html',
  styleUrls: ['./order-info.component.scss']
})
export class OrderInfoComponent implements OnInit {

  constructor(private service: WebapiService<OrderInfo, any>) { }
  
  

  ngOnInit(): void {

  }

  GetAllOrders(){

  }
}