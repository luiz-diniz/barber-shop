import { Component, OnInit } from '@angular/core';
import { Payment } from 'src/app/models/Payment';
import { WebapiService } from 'src/app/services/webapi.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent implements OnInit {

  payment: Payment;
  payments: Payment[];

  showForm: boolean = false;
  isEditing: boolean = false;

  paymentApi: string = "api/payment/";

  constructor(private service: WebapiService<Payment, any>) {
    this.payment = new Payment();
    this.payments = [];

    this.GetAllPayments()
   }

  ngOnInit(): void {
  }

  OnSubmit(){
    if(this.isEditing === true){
      this.Edit();
    }else{
      this.Create();
    }
  }

  Create(){
    const api = `${this.paymentApi}CreatePayment`;
    this.service.Create(this.payment, api).subscribe(
      success => {
        this.ResetForm();
        this.GetAllPayments();
        this.showForm = false;
      }, 
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    )
  }

  Delete(payment: Payment){
    const api = `${this.paymentApi}DeletePayment`;
    this.service.Delete(payment, api).subscribe(
      success => {
        this.GetAllPayments();
        this.ResetForm();
      },
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    )
  }

  GetAllPayments(){
    const api = `${this.paymentApi}GetAllPayments`;
    this.service.GetAll(api).subscribe(
      payments => {
        this.payments = payments
      }, 
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    )
  }

  Edit(){
    const api = `${this.paymentApi}UpdatePayment`;
    this.service.Edit(this.payment, api).subscribe(
      success => {        
        this.GetAllPayments();
        this.isEditing = false;
        this.showForm = false;
      }, 
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    ) 
  }  

  EditInput(payment: Payment){
    this.showForm = true;
    this.isEditing = true;
    this.payment = payment;
  }

  ResetForm(){
    this.payment = {
      name: '',
      hide: true
    }
  }
}
