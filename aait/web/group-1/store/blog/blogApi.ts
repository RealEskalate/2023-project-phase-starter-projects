import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { AddBlogResponse } from '@/types/blog/addBlog/AddBlogResponse'


const BASE_URL = 'https://a2sv-backend.onrender.com/api'

export const blogApi = createApi({
  reducerPath: 'blogApi',
  baseQuery: fetchBaseQuery({ 
    baseUrl: BASE_URL,
    prepareHeaders: (headers, { getState }) => {
      const token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiI2NGU3ZTk2ZDQzMTM4ZTE1NzMxMjVjZTkiLCJuYW1lIjoidGFyaWsiLCJyb2xlIjoidXNlciIsImlhdCI6MTY5MzIwNjQwMiwiZXhwIjoxNjk1Nzk4NDAyfQ.0boFB9HfNPgt9B8vr81nSvoPDElcG7_ozudCxVrzUdo'
      if(token) {
        headers.set('Authorization', `Bearer ${token}`)
      }
      return headers
    }
  }),
  endpoints: (builder) => ({
    addBlog: builder.mutation<AddBlogResponse, FormData>({
      query: (data) => ({
        url: '/blogs',
        method: 'POST',
        body: data,
      })
    }),
  })
})

export const { useAddBlogMutation } = blogApi

