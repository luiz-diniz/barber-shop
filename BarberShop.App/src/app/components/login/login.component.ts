import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/Employee';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  employee: Employee;

  constructor() { }

  ngOnInit(): void {
  }

}