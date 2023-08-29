import { authTypes } from "@/types/auth/authTypes";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const authApi = createApi({
  reducerPath: "authApi",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://a2sv-backend.onrender.com/api/auth",
    prepareHeaders: (headers, { getState }) => {
      const userString = localStorage.getItem("user");
      const user: authTypes | null = userString ? JSON.parse(userString) : null;
      const token = user?.token;

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
        url: "/manage-account",
        method: "POST",
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

// // Function to get the token from localStorage
// function getTokenFromLocalStorage(): string | null {
//   const userString = localStorage.getItem("user");
//   const user: authTypes | null = userString ? JSON.parse(userString) : null;
//   const token = user?.token;
//   console.log("less ----------------- lessssssssssssssss");
//   console.log(token);
//   return token || " ";
// }

// // import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
// // import { BlogPostResponse } from '@/types/blog/blog';
// // import { authTypes } from '@/types/auth/authTypes';

// // const baseUrl = 'https://a2sv-backend.onrender.com/api/';

// // export const createBlogApi = createApi({
// //   reducerPath: 'createBlog',
// //   baseQuery: fetchBaseQuery({ baseUrl: baseUrl,

// //     tagTypes: ['blog'],
// //     endpoints: (builder) => ({
// //         addBlog: builder.mutation<BlogPostResponse, FormData>({
// //             query: (newBlog) => ({
// //               url: '/blogs',
// //               method: 'POST',
// //               body: newBlog,
// //             }),
// //             invalidatesTags: ['blog'],
// //           }),

// //     })
// // });

// // export const {useAddBlogMutation} = createBlogApi

// // import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
// // import { BlogPostResponse } from '@/types/blog/blog';
// // import { authTypes } from '@/types/auth/authTypes';

// // const baseUrl = 'https://a2sv-backend.onrender.com/api/';

// // export const createBlogApi = createApi({
// //   reducerPath: 'createBlog',
// //   baseQuery: fetchBaseQuery({ baseUrl: baseUrl,

// //     tagTypes: ['blog'],
// //     endpoints: (builder) => ({
// //         addBlog: builder.mutation<BlogPostResponse, FormData>({
// //             query: (newBlog) => ({
// //               url: '/blogs',
// //               method: 'POST',
// //               body: newBlog,
// //             }),
// //             invalidatesTags: ['blog'],
// //           }),

// //     })
// // });

// // export const {useAddBlogMutation} = createBlogApi
