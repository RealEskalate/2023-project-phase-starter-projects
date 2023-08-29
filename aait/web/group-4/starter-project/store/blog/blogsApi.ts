import { Blog} from '@/types/blog';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import type { RootState } from '..';

export const blogApi = createApi({
  reducerPath: 'blogApi',
  baseQuery: fetchBaseQuery({ baseUrl:"https://a2sv-backend.onrender.com/api",
  prepareHeaders: (headers, { getState }) => {
    const token = (getState() as RootState).user.user.token;
    if (token) {
      headers.set("Authorization", `Bearer ${token}`);
    }
    return headers;
  },}),
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