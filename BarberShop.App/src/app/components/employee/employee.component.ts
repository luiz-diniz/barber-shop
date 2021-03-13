import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {

  hideForm: boolean = false;

  employee: Employee = {
    Cpf: '',
    Name: '',
    Username: '',
    Password: ''
  };
  employees: Employee[] = [];

  constructor(private service: EmployeeService) {
    this.GetAllEmployees();
  }
  ngOnInit(): void {
  }

  Create(){ 
    this.service.Create(this.employee).subscribe(
      success => {
        this.ResetForm(),
        this.GetAllEmployees()
      },
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    );
  }

  GetAllEmployees(){
    this.service.GetAllEmployees().subscribe(
      employees => this.employees = employees,
      err => {
        console.log(err);
        alert('Error trying to load the employees.\nContact the administrator.')
      }
    )
  }

  ResetForm(){
    this.employee = {
      Cpf: '',
      Name: '',
      Username: '',
      Password: ''
    };
  }
}