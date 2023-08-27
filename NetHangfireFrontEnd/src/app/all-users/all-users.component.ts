import { Component } from '@angular/core';
import { UserService } from '../user.service';
import { User } from '../models/user';
import { SignalrService } from '../services/signalr.service';
import { Store } from '@ngrx/store';
import { userSelector } from '../store/selectors/user.selectors';
import { AppState } from '../store/store';
import * as UserActions from '../store/actions/user.actions';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-all-users',
  templateUrl: './all-users.component.html',
  styleUrls: ['./all-users.component.css']
})
export class AllUsersComponent {
    constructor(private _userService: UserService, private _signalRService: SignalrService, private store: Store<AppState>){
      this.users = this.store.select(userSelector);
      this.getUsers();
    }    

    users : Observable<User[]>; //= [];

    getUsers(): void { 
      //this._userService.getUsers().subscribe(m => this.users = m); 
      this.store.dispatch(UserActions.loadUsers());
    }

    ngOnInit() : void {
      
        this.getUsers();
        //this._signalRService.sendUsersAsync().then((data) => { this.users.push(data) });
        this.sendUsersListener();
        console.log('filling heroes from service with observable objects');
    }

    public sendUsersListener = () => {
      this._signalRService.connection.on('newUser', (data : User) => {

        this.store.dispatch(UserActions.addUser({ user: data }))
        //this.users.push(data);
        console.log(data);
      });
    }
}
