import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee';
import { EmployeeService } from 'src/app/services/employee.service';
import { FormatService } from 'src/app/services/format.service';

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

  constructor(private service: EmployeeService,
    private Format: FormatService
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
    this.service.Create(this.employee).subscribe(
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
    this.service.Edit(this.employee).subscribe(
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
    this.service.Delete(employee).subscribe(
      success => {
        this.GetAllEmployees();
      },
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    )
  }

  GetAllEmployees(){
    this.service.GetAllEmployees().subscribe(
      employees => {this.employees = employees
      console.log(employees)
      },
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    )
  }

  ResetForm(){
    this.employee = {
      Cpf: '',
      Name: '',
      Username: '',
      Password: '',
      Hide: true
    };
  }
}