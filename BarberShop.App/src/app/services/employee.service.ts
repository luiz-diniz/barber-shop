import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CATCH_ERROR_VAR } from '@angular/compiler/src/output/output_ast';

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

  Create(employee: Employee) : Observable<Employee>{
    return this.http.post<Employee>(this.url + 'api/employee/CreateEmployee', employee, httpOptions);
  }

  GetAllEmployees() : Observable<Employee[]>{
    return this.http.get<Employee[]>(this.url + 'api/employee/GetAllEmployees', httpOptions);
  }
}