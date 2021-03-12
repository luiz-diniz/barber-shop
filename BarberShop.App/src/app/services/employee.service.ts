import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})

export class EmployeeService {

  url: string = "https://localhost:44346/";

  constructor(private http: HttpClient) { 

  }

  CreateEmployee(employee: Employee) : Observable<Employee>{
    return this.http.post<Employee>(this.url + 'api/employee/CreateEmployee', employee, httpOptions);
  }
}
