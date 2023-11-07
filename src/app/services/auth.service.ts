import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  authUser(user:any){
    let userArray=[];
    const usersData = localStorage.getItem('Users');
    if (usersData) {
      userArray = JSON.parse(usersData);
      console.log(userArray);

    }
  
    return userArray.find((p:any) => p.email=== user.email && p.password === user.password );

  }
}
