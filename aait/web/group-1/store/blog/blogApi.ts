import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { AddBlogResponse } from '@/types/blog/addBlog/AddBlogResponse'
import { Blog } from "@/types/Blog";

const BASE_URL = 'https://a2sv-backend.onrender.com/api'

export const blogApi = createApi({
  reducerPath: 'blogApi',
  baseQuery: fetchBaseQuery({
    baseUrl: BASE_URL,
    prepareHeaders: (headers, { getState }) => {
      const userData = localStorage.getItem('user')
      const token = userData ? JSON.parse(userData)?.token : null
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
    getBlogs: builder.query<Blog[], void>({
      query: () => "/blogs",
    }),
    getSingleBlog: builder.query<Blog, any>({
      query: (id) => `/blogs/${id}`,
    }),
    getMyBlogs: builder.query<Blog[], void>({
      query: () => "/blogs/my-blogs",
    })
  }),
});

export const { useAddBlogMutation, useGetBlogsQuery, useGetSingleBlogQuery, useGetMyBlogsQuery } = blogApi;
