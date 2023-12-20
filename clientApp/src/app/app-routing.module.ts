import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeDetailsComponent } from './employee-details/employee-details.component';
import { CreateEmployeeComponent } from './Admin/create-employee/create-employee.component';
import { LoginComponent } from './Admin/login/login.component';
import { EmployeeLoginComponent } from './Employee/login/Employeelogin.component';
import { HomePageComponent } from './Admin/home-page/home-page.component';

const routes: Routes = [
  {path:"MyProfile", component:EmployeeDetailsComponent},
  {path:"createEmployee", component:CreateEmployeeComponent},
  {path:"AdminLogin", component:LoginComponent},
  {path:"Login", component:EmployeeLoginComponent},
  {path:"Login", component:EmployeeLoginComponent},
  {path:"Home", component:HomePageComponent},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
