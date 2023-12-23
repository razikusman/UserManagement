import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { EmployeeService } from 'src/app/user-management/Services/employee.service';
import { LoginService } from 'src/app/user-management/Services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  LoginForm!: FormGroup;
  Status : boolean =false;

  /**
   *
   */
  constructor(private formbuilder : FormBuilder, private loginService: LoginService, private router : Router) {
    
    // console.log("hjbdgh")
  }
  ngOnInit(): void {
    this.LoginForm = this.formbuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  onSubmit(){
    if(this.LoginForm.valid){
      this.loginService.Login(this.LoginForm.value,true).subscribe(res=>{
        console.log(res);
        document.cookie = 'token='+res+'; SameSite=None; Secure'; // set the cookie

        //redirect to homepage
        this.router.navigate(['/Home']);
      })
    }
  }
}
