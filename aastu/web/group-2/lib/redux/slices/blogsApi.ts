import { Blog } from '@/lib/types';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { RootState } from '..';

export const blogsApi = createApi({
  reducerPath: 'blogsApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'https://a2sv-backend.onrender.com/api' }),
  tagTypes: ['Blogs'],
  endpoints: (builder) => ({
    getBlogs: builder.query({
      query: () => '/blogs',
    }),
    getBlogById: builder.query({
      query: (id) => ({ url: `blogs/${id}` }),
    }),
    addBlogs: builder.mutation({
      query: (blog) => ({
        url: '/blogs',
        method: 'POST',
        body: blog,
      }),
      invalidatesTags: ['Blogs'],
    }),
    myBlogs: builder.query<Blog[], void>({
      query: () => {
        const loginData = JSON.parse(localStorage.getItem('login') || '');
        const token = loginData.token;

        return {
          url: '/blogs/my-blogs',
          headers: {
            Authorization: `Bearer ${token}`,
          },
        };
      },
    }),
  }),
});

export const { useGetBlogByIdQuery, useGetBlogsQuery, useAddBlogsMutation, useMyBlogsQuery } =
  blogsApi;
