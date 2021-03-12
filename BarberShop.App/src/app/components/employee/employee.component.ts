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

  constructor(private service: EmployeeService) { }

  ngOnInit(): void {
  }

  Create(){
    this.service.CreateEmployee(this.employee).subscribe(
      employee => console.log(employee)
    );
  }
}