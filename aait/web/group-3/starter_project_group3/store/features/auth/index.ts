import { authTypes } from "@/types/auth/authTypes";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const authApi = createApi({
  reducerPath: "authApi",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://a2sv-backend.onrender.com/api/auth",
    prepareHeaders: (headers, { getState }) => {
      let userString = null;
      let user : authTypes | null = null;
      let token = null;

      if (typeof window !== 'undefined'){
      userString = localStorage.getItem("user");
      user = userString ? JSON.parse(userString) : null;
      token = user?.token;}

      if (token) {
        headers.set("Authorization", ` Bearer ${token}`);
        return headers;
      }
    },
  }),
  endpoints: (builder) => ({
    login: builder.mutation<authTypes, { email: string; password: string }>({
      query: ({ email, password }) => ({
        url: "/login",
        method: "POST",
        body: { email, password },
      }),
    }),
    register: builder.mutation<
      authTypes,
      { name: string; email: string; password: string }
    >({
      query: ({ name, email, password }) => ({
        url: "/register",
        method: "POST",
        body: { name, email, password },
      }),
    }),
    passwordReset: builder.mutation<
      authTypes,
      { oldPassword: string; newPassword: string }
    >({
      query: ({ oldPassword, newPassword }) => ({
        url: "/change-password",
        method: "PATCH",
        body: { oldPassword, newPassword },
      }),
    }),
  }),
});

export const {
  useLoginMutation,
  useRegisterMutation,
  usePasswordResetMutation,
} = authApi;
