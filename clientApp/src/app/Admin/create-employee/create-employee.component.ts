import { Component, OnInit } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Employees } from 'src/app/Models/employees';
import { EmployeeService } from 'src/app/Services/employee.service';

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
      // Email :  ['', Validators.required],
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
      const employee = this.employeeForm.value as Employees;
console.log(employee)
      this.empService.SaveEmployee(employee).subscribe(res =>{
        if (res != null) {
          console.log("save success" + res);
        }
      })
    }
  }

}

