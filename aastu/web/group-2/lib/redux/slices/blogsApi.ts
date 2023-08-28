<<<<<<< HEAD
import { Blog } from '@/lib/types';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { RootState } from '..';
=======
import { Blog } from '@/lib/types'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { RootState } from '..'
>>>>>>> f812908 (feat(AASTU-web-G2): Add RTK and organize some pages (#223))

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
      query: (blog) => {
        const loginData = JSON.parse(localStorage.getItem('login') || '');
        const token = loginData.token;
        return {
          url: '/blogs',
          method: 'POST',
          body: blog,
          headers: {
            Authorization: `Bearer ${token}`,
          },
        };
      },
      invalidatesTags: ['Blogs'],
    }),
    myBlogs: builder.query<Blog[], void>({
      query: () => {
<<<<<<< HEAD
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
=======
        const loginData = JSON.parse(localStorage.getItem('login') || "");
        const token = loginData.token;

        return {
          url: "/blogs/my-blogs",
          headers: {
            Authorization: `Bearer ${token}`
          }
        }
      }
    })
  }),
});

export const {
  useGetBlogByIdQuery,
  useGetBlogsQuery,
  useAddBlogsMutation,
  useMyBlogsQuery
} = blogsApi
>>>>>>> f812908 (feat(AASTU-web-G2): Add RTK and organize some pages (#223))
