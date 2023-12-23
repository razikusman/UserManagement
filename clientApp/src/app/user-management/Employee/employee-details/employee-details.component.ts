import { Component, OnInit, AfterViewInit } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Employees } from '../../Models/employees';
import { EmployeeService } from '../../Services/employee.service';
import { LoginService } from '../../Services/login.service';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css']
})
export class EmployeeDetailsComponent implements OnInit,AfterViewInit {
  employeeForm: any;
  Status : boolean =false;
  email: string = "";
  EmpId: string | undefined;
  myDetails: any;

  constructor(private formbuilder : FormBuilder, private empService: EmployeeService, 
    private loginService : LoginService) {
    
    // console.log("hjbdgh")
  }
  ngAfterViewInit(): void {
    //throw new Error('Method not implemented.');
  }
  ngOnInit(): void {
    this.createBookingForm(null);
    this.loginService.GetSession().subscribe( res =>{
      console.log(res);
      var data = res.body as Employees;
      this.createBookingForm(data);
      this.myDetails = data;
    });
  }

  createBookingForm(emp : any){
    this.employeeForm = this.formbuilder.group({
      Phonenumber :  [emp ? emp.phonenumber : '', Validators.required],
      Address :  [emp ? emp.address : '', Validators.required],
      Fullname :  [emp ? emp.fullname : '', Validators.required],
    })

    this.email = emp ? emp.email : '';
  }

  onSubmit() {
    if (this.employeeForm.valid) {
      var employee = new Employees()
      employee.Email = this.myDetails.email;
      employee.Joindate = this.myDetails.joindate;
      employee.Password = this.myDetails.password;
      employee.Status= this.myDetails.status;
      employee.Salaries = this.myDetails.salaries;
      employee.Salary = this.myDetails.salary;
      employee.Username = this.myDetails.username;
      employee.Fullname = this.employeeForm.value.Fullname;
      employee.Phonenumber = this.employeeForm.value.Phonenumber;
      employee.Address = this.employeeForm.value.Address;
      employee.EmpId = this.myDetails.empId;

      this.empService.SaveEmployee(employee).subscribe(res =>{
        if (res != null) {
          this.createBookingForm((res.body as any).data );
        }
      })
    }
  }

}
