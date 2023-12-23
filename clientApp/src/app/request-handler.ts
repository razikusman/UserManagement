import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpResponse,
} from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { LoginService } from './user-management/Services/login.service';
import { Router } from '@angular/router';

@Injectable()
export class RequestHandler implements HttpInterceptor {

  /**
   *
   */
  constructor(private loginService: LoginService, private route: Router) {
  }
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {

    const modifiedRequest = request.clone({
        setHeaders: {
            },
          withCredentials: true,
    });

    return next.handle(modifiedRequest).pipe(
      tap((event : HttpEvent<any>) => {
        if(event instanceof HttpResponse){
          console.log(event);
          if(event.body.isError && event.body.responseCode == 401){
            
            document.cookie = "token=" // clear the token

            // if admin loged in move to adminloginpage else to client loginpage
            if(this.loginService.IsAdminLogedIn){
              this.route.navigate(["/AdminLogin"])
            }
            else{
              this.route.navigate(["/Login"])
            }

            return;
          }
        }
      })
    );
  }
}

