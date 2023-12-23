import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/user-management/Services/login.service';

@Component({
  selector: 'app-employeelogin',
  templateUrl: './Employeelogin.component.html',
  styleUrls: ['./Employeelogin.component.css']
})
export class EmployeeLoginComponent {
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
      this.loginService.Login(this.LoginForm.value).subscribe(res=>{
        console.log(res);
        document.cookie = 'token='+res+'; SameSite=None; Secure'; // set the cookie

        //redirect to homepage
        this.router.navigate(['/MyHome']);
      })
    }
  }

  changepass(){
    this.router.navigate(["/PasswordChange"])
  }
}