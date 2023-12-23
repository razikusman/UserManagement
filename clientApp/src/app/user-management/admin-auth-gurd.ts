import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, CanActivateFn, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { LoginService } from "./Services/login.service";

@Injectable({
    providedIn: 'root'
  })
  
export class AdminAuthGurd implements CanActivate {
    
    /**
     *
     */
    constructor(private loginService: LoginService, private router: Router) {
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {

        next : ActivatedRouteSnapshot
        state: RouterStateSnapshot

        if (this.loginService.Authenticate() && this.loginService.IsAdminLogedIn) {
            return true;
        } else {
            this.router.navigate(["/AdminLogin"]);
            return false;
        }
    }
}

