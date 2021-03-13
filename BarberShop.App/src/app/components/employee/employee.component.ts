import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {

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
      employee => console.log('Success'),
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    );
  }

  GetAllEmployees(){
    this.service.GetAllEmployees().subscribe(
      employees => console.log(employees),
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    )
  }
}