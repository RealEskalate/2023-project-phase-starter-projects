import { Credentials, LoginResponse, SignupResponse } from "@/types";
import baseApi from "./baseApi";

const userApi = baseApi.injectEndpoints({
  endpoints: (builder) => ({
    login: builder.mutation<LoginResponse, Credentials>({
      query: (credentials: Credentials) => ({
        url: "auth/login",
        method: "POST",
        body: credentials,
      }),
    }),
    signup: builder.mutation<SignupResponse, Credentials>({
      query: (credentials: Credentials) => ({
        url: "auth/register",
        method: "POST",
        body: credentials,
      }),
    }),
    editProfile: builder.mutation<any, FormData>({
      query: (data: FormData) => ({
        url: "auth/edit-profile",
        method: "PATCH",
        body: data,
      }),
    }),
    changePassword: builder.mutation<any, any>({
      query: (passwords) => ({
        url: "auth/change-password",
        method: "PATCH",
        body: passwords,
      }),
    }),
  }),
});

export default userApi;
