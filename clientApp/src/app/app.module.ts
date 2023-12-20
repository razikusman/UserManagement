import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; // Import ReactiveFormsModule
import { MatDialogModule } from '@angular/material/dialog';

import { MatFormFieldModule } from "@angular/material/form-field";
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { EmployeeDetailsComponent } from './employee-details/employee-details.component';
import { UserManagementComponent } from './user-management/user-management.component';
import { EmployeeLoginComponent } from './Employee/login/Employeelogin.component';
import { LoginComponent } from './Admin/login/login.component';
import { HomePageComponent } from './Admin/home-page/home-page.component';
import { RequestHandler } from './request-handler';
import { CreateEmployeeComponent } from './Admin/create-employee/create-employee.component';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeDetailsComponent,
    UserManagementComponent,
    EmployeeLoginComponent,
    LoginComponent,
    HomePageComponent,
    CreateEmployeeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatInputModule,
    MatNativeDateModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: RequestHandler,
      multi: true,
    },
  ],
  bootstrap: [UserManagementComponent]
})
export class AppModule { }
