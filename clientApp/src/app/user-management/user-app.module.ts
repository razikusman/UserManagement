import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { RequestHandler } from "../request-handler";
import { UserManagementComponent } from "./user-management.component";
import { CreateEmployeeComponent } from "./Admin/create-employee/create-employee.component";
import { HomePageComponent } from "./Admin/home-page/home-page.component";
import { LoginComponent } from "./Admin/login/login.component";
import { MyEmployeesComponent } from "./Admin/my-employees/my-employees.component";
import { ChangePasswordComponent } from "./Employee/change-password/change-password.component";
import { EmployeeDetailsComponent } from "./Employee/employee-details/employee-details.component";
import { EmployeeLoginComponent } from "./Employee/login/Employeelogin.component";
import { MyHomePageComponent } from "./Employee/my-home-page/my-home-page.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { MatCheckboxModule } from "@angular/material/checkbox";
import { MatNativeDateModule } from "@angular/material/core";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MatDialogModule } from "@angular/material/dialog";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { AppComponent } from "../app.component";
import { UserManementAppRoutingModule } from "./user-manement-app-routing.module";
import { ActionReducerMap, Store, StoreModule } from "@ngrx/store";


@NgModule({
    declarations :[
        EmployeeDetailsComponent,
        UserManagementComponent,
        EmployeeLoginComponent,
        LoginComponent,
        HomePageComponent,
        CreateEmployeeComponent,
        MyHomePageComponent,
        ChangePasswordComponent,
        MyEmployeesComponent
    ],
    imports: [
        BrowserModule,
        UserManementAppRoutingModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        BrowserAnimationsModule,
        MatDialogModule,
        MatFormFieldModule,
        MatDatepickerModule,
        MatInputModule,
        MatNativeDateModule,
        MatButtonModule,
        MatCheckboxModule
        // StoreModule.forRoot(userReducer),
        
        // MatIconModule
      ],
    providers: [
      {
        provide: HTTP_INTERCEPTORS,
        useClass: RequestHandler,
        multi: true,
      },
    ],
    bootstrap: [AppComponent]

})
export class UserAppModule {
}
