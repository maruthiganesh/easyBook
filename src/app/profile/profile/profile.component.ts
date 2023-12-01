import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
// import { User } from 'webAPI.Models';

interface User {
  userName: string;
  email: string;
  password: string;
  mobile: string;
}
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit{

  public mail_id:any;
  public user: User | undefined;
  constructor(private userService:UserService){

    this.mail_id=userService.mail_id;

  }

  ngOnInit() {
    this.getUserDetails();

  }
  getUserDetails() {
    const token = localStorage.getItem('token');
    const usersData = localStorage.getItem('Users');
    if (usersData && token) {
      const users: User[] = JSON.parse(usersData);
      this.user = users.find(user => user.email === token);
      console.log('User Details:', this.user);
    }
  }

}
