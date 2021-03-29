import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/models/Customer';
import { FormatService } from 'src/app/services/format.service';
import { WebapiService } from 'src/app/services/webapi.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  customer: Customer;
  customers: Customer[];

  showForm: boolean = false;
  isEditing: boolean = false;

  customerApi: string = "api/customer/";

  constructor(private service: WebapiService<Customer, any>, private format: FormatService) {

    this.customer = new Customer();
    this.customers = [];

    this.GetAllCustomers();
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
    const api = `${this.customerApi}CreateCustomer`;
    console.log(api);
    console.log(this.customer);
    this.service.Create(this.customer, api).subscribe(
      success =>{
        this.ResetForm();
        this.GetAllCustomers();
        this.showForm = false;
      },
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    );
  }

  Edit(){
    const api = `${this.customerApi}UpdateCustomer`;
    this.service.Edit(this.customer, api).subscribe(
      success => {
        this.ResetForm();
        this.GetAllCustomers();
        this.isEditing = false;
        this.showForm = false;
      },
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    )
  }

  EditInput(customer: Customer){
    this.isEditing = true;
    this.showForm = true;
    this.customer = customer;
  }

  Delete(customer: Customer){
    const api = `${this.customerApi}DeleteCustomer`;
    this.service.Delete(customer, api).subscribe(
      success => {
        this.GetAllCustomers();
        this.ResetForm();
      },
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    )
  }

  GetCustomer(){
    const api = `${this.customerApi}ReadCustomer/${this.customer.cpf}`;
    console.log("teste = "+api);
    this.service.Get(api).subscribe(
      customer => {
        this.customer = customer;
      },
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    )
  }

  GetAllCustomers(){
    const api = `${this.customerApi}GetAllCustomers`;
    this.service.GetAll(api).subscribe(
      customers => {this.customers = customers;
      },
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    )
  }

  ResetForm(){
    this.customer = {
      cpf: '',
      name: '',
      birth: new Date(),
      phone: '',
      hide: true
    };
  }
}