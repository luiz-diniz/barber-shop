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

  constructor(
    private service: WebapiService<Customer, any>,
    private format: FormatService
  ) {
    this.GetAllCustomers();
   }

  customer: Customer = new Customer();
  customers: Customer[] = [];

  showForm: boolean = false;
  isEditing: boolean = false;

  employeeApi: string = "api/customer/";

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
    const api = 'api/customer/CreateCustomer';
    this.service.Create(this.customer, api).subscribe(
      success => {
        this.ResetForm(),
        this.GetAllCustomers(),
        this.showForm = false;
      },
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    );
  }

  Edit(){
    const api = 'api/customer/UpdateCustomer';
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
    const api = 'api/customer/DeleteCustomer';
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

  GetAllCustomers(){
    const api = 'api/customer/GetAllCustomers';
    this.service.GetAllEmployees(api).subscribe(
      customers => {this.customers = customers;
      console.log(customers)
      },
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    )
  }

  ResetForm(){
    this.customer = {
      Cpf: '',
      Name: '',
      Birth: null,
      Phone: null,
      Hide: true
    };
  }
}
