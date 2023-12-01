import { Injectable } from '@angular/core';
import { User } from '../model/user';
import { HttpClient, HttpHeaders } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class UserService {
public user_Data:any;
public mail_id:any;
  constructor(private http: HttpClient) { }
  getuserDetails(mailid:string){
    const url = `http://localhost:5224/api/account/${mailid}`;
    this.user_Data=this.http.get<any>(url);

  }
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
