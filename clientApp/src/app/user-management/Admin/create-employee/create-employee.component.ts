import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Employees, Salaries } from 'src/app/user-management/Models/employees';
import { EmployeeService } from 'src/app/user-management/Services/employee.service';

@Component({
  selector: 'app-create-employee',
  templateUrl: './create-employee.component.html',
  styleUrls: ['./create-employee.component.css']
})
export class CreateEmployeeComponent implements OnInit {
  employeeForm!: FormGroup;
  Status : boolean =false;

  /**
   *
   */
  constructor(private formbuilder : FormBuilder, private empService: EmployeeService) {
    
    // console.log("hjbdgh")
  }
  ngOnInit(): void {
    this.createBookingForm();
  }

  createBookingForm(){
    this.employeeForm = this.formbuilder.group({
      // Fullname : ['', Validators.required],
      Email :  ['', Validators.required],
      Salary :  ['', Validators.required],
      Joindate :  ['', Validators.required],
      // Password :  ['', Validators.required],
      Username :  ['', Validators.required],
      // Phonenumber :  ['', Validators.required],
      // Address :  ['', Validators.required],
      Status :  ['', Validators.required],//-active/inactive
      // TempPassword :  ['', Validators.required],
      // Salaries : ['', Validators.required],
    })
  }

  onSubmit() {
    if (this.employeeForm.valid) {
      const emp = this.employeeForm.value as Employees;
      var employee = new Employees();
      employee.Salary = emp.Salary;
      employee.Joindate = emp.Joindate;
      employee.Username = emp.Username;
      employee.Email = emp.Email;
      employee.Status = 'true';
      employee.EmpId = "-1";
      //create salry of current month start
      let sal = new Salaries();
      let date = new Date();

      let datePipe = new DatePipe('en-US');
      sal.Month = datePipe.transform(date, 'MMM')?.toString();
      sal.Salary = employee.Salary;
      //create salry of current month End

      let salArray = [];
      salArray.push(sal);
      employee.Salaries = salArray; // add the salry to salries array
      console.log(employee)
      this.empService.SaveEmployee(employee).subscribe(res =>{
        if (res != null) {
          console.log("save success" + res);
        }
      })
    }
  }

}

