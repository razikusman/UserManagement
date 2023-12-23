import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/user-management/Services/login.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent {
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
      password: ['', Validators.required],
      newpassword: ['', Validators.required]
    })
  }

  onSubmit(){
    if(this.LoginForm.valid){
      var loginformVal = this.LoginForm.value;
      this.loginService.ChangePasswordAsync(loginformVal.username, loginformVal.password, loginformVal.newpassword).subscribe(res=>{
        console.log(res);
        document.cookie = 'token='+res+'; SameSite=None; Secure'; // set the cookie

        //redirect to homepage
        this.router.navigate(['/MyHome']);
      })
    }
  }
}