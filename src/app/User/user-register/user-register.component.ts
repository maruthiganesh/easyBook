import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, ValidatorFn, AbstractControl } from '@angular/forms';
import { User } from 'src/app/model/user';
import { AlertifyService } from 'src/app/services/alertify.service';
import { UserService } from 'src/app/services/user.service';


@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css']
})
export class UserRegisterComponent implements OnInit {
  registrationForm!: FormGroup;
  user!: User;
  isSubmitted:boolean=false;

  constructor(private userService:UserService,private alertify:AlertifyService) {

  }

  ngOnInit(): void {
    this.registrationForm = new FormGroup({
      userName: new FormControl(null, Validators.required),
      email: new FormControl(null, [Validators.required, Validators.email]),
      password: new FormControl(null, [Validators.required, Validators.minLength(8)]),
      confirmPassword: new FormControl(null, Validators.required),
      mobile: new FormControl(null, [Validators.required, Validators.maxLength(10)]),
    }, {
      validators: this.passwordMatchingValidator
    });
  }

  passwordMatchingValidator: ValidatorFn = (control: AbstractControl): { [key: string]: any } | null => {
    const password = control.get('password')?.value;
    const confirmPassword = control.get('confirmPassword')?.value;

    return password === confirmPassword ? null : { notmatched: true };
  };

  userData():User{
    return this.user = {
        userName: this.userName.value,
        email: this.email.value,
        password: this.password.value,
        mobile: this.mobile.value
    };

  }
get userName()
{
  return this.registrationForm.get('userName') as FormControl
}

get password()
{
  return this.registrationForm.get('password') as FormControl
}

get confirmPassword()
{
  return this.registrationForm.get('confirmPassword') as FormControl
}

get email()
{
  return this.registrationForm.get('email') as FormControl
}

get mobile()
{
  return this.registrationForm.get('mobile') as FormControl
}


  onSubmit() {
    this.isSubmitted=true;
    console.log(this.registrationForm.value);
    if(this.registrationForm.valid){
    // this.user=Object.assign(this.user,this.registrationForm.value);
    this.userService.addUser(this.userData());
    this.registrationForm.reset();
    this.isSubmitted=false;
    this.alertify.success("User Registered Successfully !!!")
    }
    else{
      this.alertify.error("Kindly provide required fields to Register !!!")
    }
  }

  
}
