import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employees } from '../Models/employees';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private baseUrl : string = "https://localhost:7029/api/Login";
  
  constructor(private http: HttpClient) { }

  Login(obj: any, isAdmin:boolean = false): Observable<any> {
    if(isAdmin){
    return this.http.post(this.baseUrl+"/isAdmin", obj);
    }
    else{
      return this.http.post(this.baseUrl, obj);
    }
  }

  LogOut(id: string): Observable<any> {
    return this.http.post(this.baseUrl+"/id="+id, null);
  }

  ChangePasswordAsync(id : string, oldPas : string, newPas : string) : Observable<any> {
    return this.http.put(this.baseUrl+"/id="+id+"/oldPas="+oldPas+"/newPas="+newPas, null);
  }
}
