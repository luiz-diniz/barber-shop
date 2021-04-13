import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/Employee';
import { FormatService } from 'src/app/services/format.service';
import { WebapiService } from 'src/app/services/webapi.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {

  employee: Employee = new Employee();
  employees: Employee[] = [];

  showForm: boolean = false;
  isEditing: boolean = false;

  employeeApi: string = "api/employee/";

  constructor(
    private service: WebapiService<Employee, any>,
    private format: FormatService
    ) {
    this.GetAllEmployees();
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
    const api = `${this.employeeApi}CreateEmployee`;
    this.service.Create(this.employee, api).subscribe(
      success => {
        this.ResetForm(),
        this.GetAllEmployees(),
        this.showForm = false;
      },
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    );
  }

  Edit(){
    const api = `${this.employeeApi}UpdateEmployee`;
    this.service.Edit(this.employee, api).subscribe(
      success => {
        this.ResetForm();
        this.GetAllEmployees();
        this.isEditing = false;
        this.showForm = false;
      },
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    )
  }

  EditInput(employee: Employee){
    this.isEditing = true;
    this.showForm = true;
    this.employee = employee;
  }

  Delete(employee: Employee){
    const api = `${this.employeeApi}DeleteEmployee`;
    this.service.Delete(employee, api).subscribe(
      success => {
        this.GetAllEmployees();
        this.ResetForm();
      },
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    )
  }

  GetAllEmployees(){
    const api = `${this.employeeApi}GetAllEmployees`;
    this.service.GetAll(api).subscribe(
      employees => {this.employees = employees
      },
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    )
  }

  ResetForm(){
    this.employee = {
      cpf: '',
      name: '',
      username: '',
      password: '',
      hide: true
    };
  }
}