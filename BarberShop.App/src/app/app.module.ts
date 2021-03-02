import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { CustomerComponent } from './components/customer/customer.component';
import { CustomerComponentComponent } from './components/customer-component/customer-component.component';
import { EmployeeComponent } from './components/employee/employee.component';
import { CustomerPhoneComponent } from './components/customer-phone/customer-phone.component';
import { PaymentComponent } from './components/payment/payment.component';
import { ShopAddressComponent } from './components/shop-address/shop-address.component';
import { ServiceInfoComponent } from './components/service-info/service-info.component';
import { OrderInfoComponent } from './components/order-info/order-info.component';
import { HomeComponent } from './components/home/home.component';
import { NotFoundComponentComponent } from './components/not-found-component/not-found-component.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CustomerComponent,
    CustomerComponentComponent,
    EmployeeComponent,
    CustomerPhoneComponent,
    PaymentComponent,
    ShopAddressComponent,
    ServiceInfoComponent,
    OrderInfoComponent,
    HomeComponent,
    NotFoundComponentComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [LoginComponent]
})
export class AppModule { }
