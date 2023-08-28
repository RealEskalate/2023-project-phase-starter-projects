import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { Blog, BlogPostResponse } from '@/types/blog/blog';

const baseUrl = 'https://a2sv-backend.onrender.com/api/';

export const createBlogApi = createApi({
    reducerPath: 'createBlog',
    baseQuery: fetchBaseQuery({ baseUrl: baseUrl,
      prepareHeaders: (headers, {getState}) =>{
        const token = localStorage.getItem('user')
        
            if(token){
          headers.set('Authorization', `Bearer ${token}`);
          return headers
        }
      }
     }),
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
