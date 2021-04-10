import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { EmployeeComponent } from '../components/employee/employee.component';
import { CustomerComponent } from '../components/customer/customer.component';
import { PaymentComponent } from '../components/payment/payment.component';
import { ServiceInfoComponent } from '../components/service-info/service-info.component';
import { ShopAddressComponent } from '../components/shop-address/shop-address.component';
import { LoginComponent } from '../components/login/login.component';
import { OrderInfoComponent } from '../components/order-info/order-info.component';

const routes: Routes = [
  {
    path: 'employee',
    component: EmployeeComponent
  },
  {
    path: 'customer',
    component: CustomerComponent
  },
  {
    path: 'payment',
    component: PaymentComponent
  },
  {
    path: 'services',
    component: ServiceInfoComponent
  },
  {
    path: 'shopAddress',
    component: ShopAddressComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'order',
    component: OrderInfoComponent
  }
]

@NgModule({
  declarations: [],
  exports: [RouterModule],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ]
})
export class AppRoutingModule { }