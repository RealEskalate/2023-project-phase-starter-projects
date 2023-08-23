"use client"

import { User } from '@/lib/types'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const usersApi = createApi({
  reducerPath: 'usersApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'https://a2sv-backend.onrender.com/api' }),
  tagTypes: ['Users'],
  endpoints: (builder) => ({
    login: builder.mutation({
      query: (info) => ({
        url: "/auth/login",
        method: "POST",
        body: info
      })
    }),
    addUser: builder.mutation({
      query: (user: any) => ({
        url: "/auth/register",
        method: "POST",
        body: user
      }),
      invalidatesTags: ['Users']
    }),
    editUser: builder.mutation({
      query: (user: User) => ({
        url: "/auth/edit-profile",
        method: "PATCH",
        body: user
      }),
      invalidatesTags: ['Users']
    }),
  }),
})

export const {
  useAddUserMutation,
  useEditUserMutation,
  useLoginMutation
} = usersApi
