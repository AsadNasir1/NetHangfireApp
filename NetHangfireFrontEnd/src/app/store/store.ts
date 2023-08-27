import { Action, ActionReducer } from "@ngrx/store";
import { UserEffects } from "./effects/user.effects";
import { userReducer } from "./reducers/user.reducers";
import { UsersState } from "./models/state.model";


export interface AppState {
  todo: UsersState
}

export interface AppStore {
  todo: ActionReducer<UsersState, Action>;
}

export const appStore: AppStore = {
  todo: userReducer
}

export const appEffects = [UserEffects];
