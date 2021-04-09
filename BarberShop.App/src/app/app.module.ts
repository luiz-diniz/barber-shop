import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule }   from '@angular/forms';
import { NgxMaskModule, IConfig } from 'ngx-mask'
import { NgxCurrencyModule } from 'ngx-currency';

import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { CustomerComponent } from './components/customer/customer.component';
import { EmployeeComponent } from './components/employee/employee.component';
import { PaymentComponent } from './components/payment/payment.component';
import { ShopAddressComponent } from './components/shop-address/shop-address.component';
import { ServiceInfoComponent } from './components/service-info/service-info.component';
import { OrderInfoComponent } from './components/order-info/order-info.component';
import { HomeComponent } from './components/home/home.component';
import { NotFoundComponentComponent } from './components/not-found-component/not-found-component.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing/app-routing.module';

export const options: Partial<IConfig> | (() => Partial<IConfig>) = null;

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CustomerComponent,
    EmployeeComponent,
    PaymentComponent,
    ShopAddressComponent,
    ServiceInfoComponent,
    OrderInfoComponent,
    HomeComponent,
    NotFoundComponentComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    NgxMaskModule.forRoot(),
    NgxCurrencyModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }