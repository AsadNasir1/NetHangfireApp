import { User } from "src/app/models/user";

export interface UsersState {
  readonly users: Array<User>;
  loading: boolean;
  error: string;
}
