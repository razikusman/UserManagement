import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateEmployeeComponent } from './Admin/create-employee/create-employee.component';
import { LoginComponent } from './Admin/login/login.component';
import { EmployeeLoginComponent } from './Employee/login/Employeelogin.component';
import { HomePageComponent } from './Admin/home-page/home-page.component';
import { MyHomePageComponent } from './Employee/my-home-page/my-home-page.component';
import { AuthGurd } from './auth-gurd';
import { AdminAuthGurd } from './admin-auth-gurd';
import { ChangePasswordComponent } from './Employee/change-password/change-password.component';
import { MyEmployeesComponent } from './Admin/my-employees/my-employees.component';
import { EmployeeDetailsComponent } from './Employee/employee-details/employee-details.component';

const routes: Routes = [
  // employees routes
  {path:"MyProfile", component:EmployeeDetailsComponent, canActivate: [AuthGurd]},
  {path:"Login", component:EmployeeLoginComponent},
  {path:"MyHome", component:MyHomePageComponent, canActivate: [AuthGurd]},
  {path:"PasswordChange", component:ChangePasswordComponent},
  
  //admin routes
  {path:"createEmployee", component:CreateEmployeeComponent, canActivate: [AdminAuthGurd]},
  {path:"AdminLogin", component:LoginComponent},
  {path:"Home", component:HomePageComponent, canActivate: [AdminAuthGurd]},
  {path:"myEmployees", component:MyEmployeesComponent, canActivate: [AdminAuthGurd]},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class UserManementAppRoutingModule {
}
