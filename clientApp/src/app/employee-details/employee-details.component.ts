import { Component, OnInit } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Employees } from '../Models/employees';
import { EmployeeService } from '../Services/employee.service';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css']
})
export class EmployeeDetailsComponent implements OnInit {
  employeeForm!: FormGroup;
  Status : boolean =false;

  /**
   *
   */
  constructor(private formbuilder : FormBuilder, private empService: EmployeeService) {
    
    console.log("hjbdgh")
  }
  ngOnInit(): void {
    this.createBookingForm();
  }

  createBookingForm(){
    this.employeeForm = this.formbuilder.group({
      Fullname : ['', Validators.required],
      Email :  ['', Validators.required],
      // Salary :  ['', Validators.required],
      // Joindate :  ['', Validators.required],
      // Password :  ['', Validators.required],
      // Username :  ['', Validators.required],
      Phonenumber :  ['', Validators.required],
      Address :  ['', Validators.required],
      Status :  ['', Validators.required],//-active/inactive
      // TempPassword :  ['', Validators.required],
      // Salaries : ['', Validators.required],
    })
  }

  onSubmit() {
    if (this.employeeForm.valid) {
      const employee = this.employeeForm.value as Employees;

      this.empService.SaveEmployee(employee).subscribe(res =>{
        if (res != null) {
          console.log("save success");
        }
      })
    }
  }

}
