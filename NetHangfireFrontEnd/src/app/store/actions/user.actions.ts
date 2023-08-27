import { createAction, props } from '@ngrx/store';
import { UserModel } from '../models/user.model';
import { User } from 'src/app/models/user';

export const addUser = createAction("add_user", props<{ user: User }>());
export const loadUsers = createAction("load_users");
export const loadUsersSuccess = createAction("load_users_success", props<{ users: User[] }>());
export const loadUsersFailure = createAction("load_users_failure", props<{ error: string }>());