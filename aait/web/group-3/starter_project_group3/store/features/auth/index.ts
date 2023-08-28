import { authTypes } from "@/types/auth/authTypes";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const authApi = createApi({
  reducerPath: 'authApi',
  baseQuery: fetchBaseQuery({
    baseUrl: "https://a2sv-backend.onrender.com/api/auth",
  }),
  endpoints: (builder) => ({
    login: builder.mutation<authTypes, { email: string; password: string }>({
      query: ({ email, password }) => ({
        url: "/login",
        method: "POST",
        body: { email, password },
      }),
    }),
    register: builder.mutation<authTypes, { name: string; email: string; password: string }>({
      query: ({ name, email, password }) => ({
        url: "/register",
        method: "POST",
        body: { name, email, password },
      }),
    }),
    passwordReset: builder.mutation<authTypes, { oldPassword: string; newPassword: string }>({
      query: ({ oldPassword, newPassword }) => ({
        url: "/manage-account",
        method: "POST",
        body: {oldPassword, newPassword},
      }),
    }),
  }),
});

export const { useLoginMutation, useRegisterMutation,usePasswordResetMutation } = authApi;