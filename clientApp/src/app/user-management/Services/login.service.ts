import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employees } from '../Models/employees';
import { Store } from '@ngrx/store';
import { Login } from '../actions';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private isAdmin = false;
  private baseUrl : string = "https://localhost:7029/api/Login";
  
  constructor(private http: HttpClient) { }

  Login(obj: any, isAdmin:boolean = false): Observable<any> {
    if(isAdmin){
      this.isAdmin = true;
      
      return this.http.post(this.baseUrl+"/isAdmin", obj);
    }
    else{ 
      this.isAdmin = false;
      return this.http.post(this.baseUrl, obj);
    }
  }

  LogOut(id: string): Observable<any> {
    return this.http.post(this.baseUrl+"/id="+id, null);
  }

  ChangePasswordAsync(username : string, oldPas : string, newPas : string) : Observable<any> {
    return this.http.put(this.baseUrl+"/username?username="+username+"&oldPas="+oldPas+"&newPas="+newPas, null);
  }

  Authenticate() {
    if(document.cookie){
      return true;
    }
    else{
      return false;
    }
  }

  GetSession() {
    return this.http.get(this.baseUrl, {observe:'response'});

  }

  get IsAdminLogedIn(){
    return this.isAdmin;
  }

}
