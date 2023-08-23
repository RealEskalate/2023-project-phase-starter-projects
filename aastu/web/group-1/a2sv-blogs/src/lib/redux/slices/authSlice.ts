import { createSlice } from "@reduxjs/toolkit";
import userApi from "../services/userApi";

export interface AuthState {
  token: string;
  isAuthenticated: boolean;
  isLoading: boolean;
  userId?: string;
  userName?: string;
  userRole?: string;
}

const initialState: AuthState = {
  token: "",
  isAuthenticated: false,
  isLoading: false,
  userId: "",
  userName: "",
  userRole: "",
};

const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {},
  extraReducers(builder) {
    builder.addMatcher(
      userApi.endpoints.login.matchPending,
      (state, { payload }) => {
        state.isLoading = true;
      }
    );
    builder.addMatcher(
      userApi.endpoints.signup.matchPending,
      (state, { payload }) => {
        state.isLoading = true;
      }
    );
    builder.addMatcher(
      userApi.endpoints.login.matchFulfilled,
      (state, { payload }) => {
        state.token = payload.token;
        state.userId = payload.userId;
        state.userName = payload.userName;
        state.userRole = payload.userRole;
        state.isAuthenticated = true;
        state.isLoading = false;
        document.cookie = `token=${payload.token}`;
      }
    );
    builder.addMatcher(
      userApi.endpoints.signup.matchFulfilled,
      (state, { payload }) => {
        state.token = payload.token;
        state.userId = payload.userId;
        state.isAuthenticated = true;
        state.isLoading = false;
        document.cookie = `token=${payload.token}`;
      }
    );
  },
});

export default authSlice.reducer;

export const selectAuth = (state: { auth: AuthState }) => state.auth;
