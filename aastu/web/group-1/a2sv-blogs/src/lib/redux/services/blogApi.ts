import baseApi from "./baseApi";
import { Blog } from "@/types";

const blogApi = baseApi.injectEndpoints({
  endpoints: (builder) => ({
    getBlogs: builder.query<Blog[], void>({
      query: () => "/blogs",
    }),
    getBlogById: builder.query({
      query: (id: string) => `/blogs/${id}`,
    }),
    createBlog: builder.mutation<Blog, FormData>({
      query: (body) => ({
        url: "/blogs",
        method: "POST",
        body,
      }),
    }),
    updateBlog: builder.mutation({
      query: ({ id, body }) => ({
        url: `/blogs/${id}`,
        method: "PUT",
        body,
      }),
    }),
    deleteBlog: builder.mutation({
      query: (id) => ({
        url: `/blogs/${id}`,
        method: "DELETE",
      }),
    }),
    getMyBlogs: builder.query<Blog[], void>({
      query: () => "/blogs/my-blogs",
    }),
  }),
  overrideExisting: false,
});

export default blogApi;
