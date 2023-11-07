import { Injectable } from '@angular/core';
import { User } from '../model/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { }

  addUser(user:User){
    let users: any[] =[]
    const usersData = localStorage.getItem('Users');
    if (usersData) {
      users = JSON.parse(usersData);
      users = [...users, user];
    } else {
      users = [user];
    }
    localStorage.setItem('Users', JSON.stringify(users))
  }
}
