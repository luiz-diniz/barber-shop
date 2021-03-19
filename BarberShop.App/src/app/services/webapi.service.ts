import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})

export class WebapiService<T, Y>{

  constructor(private http: HttpClient) { }

  Create(type: T, api: string) : Observable<Y>{
    return this.http.post<Y>(environment.url + api, type, httpOptions);
  }

  Delete(type: T, api: string) : Observable<Y>{
    const httpDelete = {
      headers: httpOptions.headers,
      body: type 
    }

    return this.http.delete<Y>(environment.url + api, httpDelete);
  }

  Edit(type: T, api: string) : Observable<Y>{
    return this.http.put<Y>(environment.url + api, type, httpOptions);
  }

  GetAll(api: string) : Observable<Y[]>{
    return this.http.get<Y[]>(environment.url + api, httpOptions);
  }
}