import { Component } from '@angular/core';
import { User } from '../models/user';
import { UserService } from '../user.service';


@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent {
    
  constructor(private _userService: UserService){}

    model = new User();
    submitted = false;
    minDate = { year: 1975, month: 1, day: 1 };
    onSubmit() : void 
    { 
      //this.submitted = true;
      this._userService.addUser(this.model).subscribe();
      alert('Record Saved');      
    }

    newUser(): void{
      this.model = new User();
    }

}
