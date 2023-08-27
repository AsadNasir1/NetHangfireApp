import { UsersState } from "../models/state.model";
import { UserModel } from "../models/user.model";
import { User } from "src/app/models/user";
import { createReducer, on } from "@ngrx/store";
import * as UserActions from "../actions/user.actions";

export const initialState: UsersState = {
    users: new Array<User>,
    loading: false,
    error: ''
    };
    export const userReducer = createReducer(
    initialState,
    
    on(UserActions.loadUsers, state => ({ ...state, loading: true })),
    
    on(UserActions.addUser, (state, { user }) => ({ ...state, users: [...state.users, user] })),

    on(UserActions.loadUsersSuccess, (state, { users }) =>({ ...state, users, loading: false })),

    on(UserActions.loadUsersFailure, (state, { error }) => ({ ...state, error, loading: false })),
    );