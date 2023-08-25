import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { Blog, BlogPostResponse } from '@/types/blog/blog';

const baseUrl = 'https://a2sv-backend.onrender.com/api';

export const createBlogApi = createApi({
    reducerPath: 'createBlog',
    baseQuery: fetchBaseQuery({ baseUrl: baseUrl }),
    tagTypes: ['blog'],
    endpoints: (builder) => ({
        addBlog: builder.mutation<BlogPostResponse, FormData>({
            query: (newBlog) => ({
              url: '/blogs',
              method: 'POST',
              body: newBlog,
            }),
            invalidatesTags: ['blog'],
          }),
        
    })
});

export const {useAddBlogMutation} = createBlogApi
