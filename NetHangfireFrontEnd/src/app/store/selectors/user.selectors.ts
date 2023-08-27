import {  createSelector } from "@ngrx/store"
import { UsersState } from "../models/state.model";
import { AppState } from "../store";
 

const feature = (state: AppState) => state.todo;

export const userSelector = createSelector(
  feature,
  (state: UsersState) => state.users
);