import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { AddBlogResponse } from '@/types/blog/addBlog/AddBlogResponse'


const BASE_URL = 'https://a2sv-backend.onrender.com/api'

export const blogApi = createApi({
  reducerPath: 'blogApi',
  baseQuery: fetchBaseQuery({ 
    baseUrl: BASE_URL,
    prepareHeaders: (headers, { getState }) => {
      const savedUser = localStorage.getItem('user')
      const token = savedUser ? JSON.parse(savedUser)?.token : null
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

