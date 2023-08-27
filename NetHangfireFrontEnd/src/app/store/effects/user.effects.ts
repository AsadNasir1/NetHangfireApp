import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, mergeMap } from 'rxjs/operators';
import { of } from 'rxjs';
import { UserService } from 'src/app/user.service';
//import { ToDoService } from './service';
//import * as TodoActions from './actions';
import * as UserActions from '../actions/user.actions';

@Injectable()
export class UserEffects {
  
  loadUser$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UserActions.loadUsers),
      mergeMap(() =>
        
      this.userService.getUsers().pipe(
          map((users) => UserActions.loadUsersSuccess({ users })),
          catchError((error) =>
            of(UserActions.loadUsersFailure({ error: error.message }))
          )
        )
      )
    )
  );
  constructor(private actions$: Actions, private userService: UserService) {}
}
