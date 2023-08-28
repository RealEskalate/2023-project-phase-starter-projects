import { Blog} from '@/types/blog';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';


export const blogApi = createApi({
  reducerPath: 'blogApi',
  baseQuery: fetchBaseQuery({ baseUrl:"https://a2sv-backend.onrender.com/api"}),
  tagTypes:['Blog'],
  endpoints: (builder) => ({
    addBlog: builder.mutation<Blog, Partial<Blog>>({
      query: (blog) => ({
        url: '/blogs',
        method: 'POST',
        body: blog,
      }),
      invalidatesTags:['Blog']
    }),
  }),
})

export const { useAddBlogMutation} = blogApi