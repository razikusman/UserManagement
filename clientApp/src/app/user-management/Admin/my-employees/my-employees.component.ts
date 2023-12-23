import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, } from 'rxjs';
import { Employees } from 'src/app/user-management/Models/employees';
import { EmployeeService } from 'src/app/user-management/Services/employee.service';
import { LoginService } from 'src/app/user-management/Services/login.service';

@Component({
  selector: 'app-my-employees',
  templateUrl: './my-employees.component.html',
  styleUrls: ['./my-employees.component.css']
})
export class MyEmployeesComponent implements OnInit {

  employees : any[] = [];
  /**
   *
   */
  constructor(private empService: EmployeeService, private loginService: LoginService,
    private router: Router) {
    loginService.GetSession().subscribe(res => {

      // if session Availble go on
      // else check for error and do the action
      if (res.body && !(res.body as any).isError) {
        this.getEmployees();
      }
      else if (res.body && !(res.body as any).isError && (res.body as any).responseCode == 401){
        router.navigate(["/AdminLogin"])
      }
      else{
        console.log(res);
      }
    })
  }

  ngOnInit(): void {
    
  }

  getEmployees(){
    this.empService.GetEmployee().subscribe(res => {
      this.employees = [...res.body as []]
      console.log(this.employees)
    })
  }

  onCheckboxChange(event: any, employee: Employees) {
    employee.Status = event.checked;
  }
}
