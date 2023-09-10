import { Blog } from "@/types/blog/blog";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const blogsApi = createApi({
  reducerPath: "blogs-api",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://a2sv-backend.onrender.com/api/",
  }),
  endpoints: (build) => ({
    getBlogs: build.query<Blog[], void>({
      query: () => ({
        url: "blogs",
        method: "GET",
      }),
    }),
    getBlogById: build.query<Blog, string>({
      query: (id) => ({
        url: `blogs/${id}`,
        method: "GET",
      }),
    }),
    createBlog: build.mutation<Blog, Blog>({
      query: (blog) => ({
        url: "blogs",
        method: "POST",
        body: blog,
      }),
    }),
    updateBlog: build.mutation<Blog, Blog>({
      query: (blog) => ({
        url: `blogs/${blog._id}`,
        method: "PUT",
        body: blog,
      }),
    }),
    deleteBlog: build.mutation<Blog, string>({
      query: (id) => ({
        url: `blogs/${id}`,
        method: "DELETE",
      }),
    }),
  }),
});

export const {
  useGetBlogsQuery,
  useGetBlogByIdQuery,
  useCreateBlogMutation,
  useUpdateBlogMutation,
  useDeleteBlogMutation,
} = blogsApi;
