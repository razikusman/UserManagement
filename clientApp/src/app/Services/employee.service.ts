import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employees } from '../Models/employees';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private baseUrl : string = "https://localhost:7029/api/Employees";
  
  constructor(private http: HttpClient) { }

  SaveEmployee(emp: Employees): Observable<any> {
    return this.http.post(this.baseUrl, emp);
  }

  GetEmployee(): Observable<any> {
    return this.http.get(this.baseUrl);
  }
}
