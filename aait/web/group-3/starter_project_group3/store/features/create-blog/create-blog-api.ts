import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { Blog, BlogPostResponse } from '@/types/blog/blog';

const baseUrl = 'https://a2sv-backend.onrender.com/api/';

export const createBlogApi = createApi({
    reducerPath: 'createBlog',
    baseQuery: fetchBaseQuery({ baseUrl: baseUrl,
      prepareHeaders: (headers, {getState}) =>{
        const token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiI2NGVhMDYwNGFlN2FjNzc4YjdhMjM2MGMiLCJuYW1lIjoiWW9oYW5uZXMgQWh1bm0iLCJyb2xlIjoidXNlciIsImlhdCI6MTY5MzIwNDg4NCwiZXhwIjoxNjk1Nzk2ODg0fQ.83P8-E_Zqlx6HcrweoRE7uJzdw8nqsHnYoSygKylsQ8"
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
