import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { BlogPostResponse } from '@/types/blog/blog';
import { authTypes } from '@/types/auth/authTypes';

const baseUrl = 'https://a2sv-backend.onrender.com/api/';

export const createBlogApi = createApi({
  reducerPath: 'createBlog',
  baseQuery: fetchBaseQuery({ baseUrl: baseUrl,
    prepareHeaders: (headers, {getState}) =>{
      let userString = null;
      let user : authTypes | null = null;
      let token = null;

      if (typeof window !== 'undefined'){
      userString = localStorage.getItem("user");
      user = userString ? JSON.parse(userString) : null;
      token = user?.token;}

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
