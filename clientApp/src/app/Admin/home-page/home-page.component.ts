import { Component,OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  /**
   *
   */
  constructor(private empService: EmployeeService, private router: Router) {
  }
  ngOnInit(): void {
    // this.empService.GetEmployee().subscribe(res=>{
    //   console.log(res)
    // })
  }

  goToEmployeesPage(){
    this.router.navigate(["/createEmployee"])
  }

}
