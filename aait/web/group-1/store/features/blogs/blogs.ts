import { Blog } from "@/types/Blog";
import { Profile } from "@/types/Profile";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const blogsApi = createApi({
  reducerPath: "blogs",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://a2sv-backend.onrender.com/api",
  }),
  endpoints: (build) => ({
    getBlogs: build.query<Blog[], void>({
      query: () => "/blogs",
    }),
    getSingleBlog: build.query<Blog, any>({
      query: (id) => `/blogs/${id}`,
    }),
  }),
});

export const { useGetBlogsQuery, useGetSingleBlogQuery } = blogsApi;