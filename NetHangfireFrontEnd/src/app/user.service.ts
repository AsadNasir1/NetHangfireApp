import { Injectable } from '@angular/core';
import { User } from './models/user';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  listUsersUrl = 'https://localhost:7267/api/User';

  getUsers() : Observable<User[]> { 
      return this.http.get<User[]>(this.listUsersUrl);      
      //const users = of([{ id:1,name:'asad' },{ id:2,name:'nasir' },{ id:3,name:'umar' }]);
      //return users;
   }

   addUser(usr: User) : Observable<User> {
      return this.http.post<User>(this.listUsersUrl, usr);
   }

}
