import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl,Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify.service';
import { AuthService } from 'src/app/services/auth.service';



@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit{
  loginForm!: FormGroup;
  isSubmitted:boolean=false;
  constructor(private alertify:AlertifyService, private authenticate:AuthService, private router:Router){}

  
  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl(null, [Validators.required, Validators.email]),
      password: new FormControl(null, [Validators.required, Validators.minLength(8)]),
      
    });
  }

  get email()
{
  return this.loginForm.get('email') as FormControl
}

get password()
{
  return this.loginForm.get('password') as FormControl
}

onSubmit() {
  this.isSubmitted=true;
  console.log(this.loginForm.value);
  if(this.loginForm.valid){
  
        let token=this.authenticate.authUser(this.loginForm.value);
        this.loginForm.reset();
        this.isSubmitted=false;
        if(token){
            localStorage.setItem('token',token.email);
            this.router.navigate(['/']);
            this.alertify.success("User logged in Successfully !!!");
        }
        else{
            this.alertify.error("Invalid Credentials");
        }

        }
  else{
    this.alertify.error("Kindly provide all the details !!!")
  }
}



}
